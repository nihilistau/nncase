from typing import List, Dict, Union, Tuple
import os
import nncase
import numpy as np
import test_utils
import preprocess_utils


class Inference:
    def run_inference(self, dict_args, cfg, case_dir, import_options, compile_options, model_content, preprocess_opt):
        infer_output_paths = self.nncase_infer(
            cfg, case_dir, import_options,
            compile_options, model_content, dict_args, preprocess_opt)
        return infer_output_paths

    def nncase_infer(self, cfg, case_dir: str,
                     import_options: nncase.ImportOptions,
                     compile_options: nncase.CompileOptions,
                     model_content: Union[List[bytes], bytes],
                     kwargs: Dict[str, str],
                     preprocess: Dict[str, str]
                     ) -> List[Tuple[str, str]]:
        infer_dir = self.kwargs_to_path(
            os.path.join(case_dir, 'infer'), kwargs)
        compile_options = self.get_infer_compile_options(
            infer_dir, cfg, compile_options, kwargs, preprocess)
        self.compiler = nncase.Compiler(compile_options)
        self.import_model(self.compiler, model_content, import_options)
        self.set_quant_opt(cfg, kwargs, preprocess, self.compiler)
        self.compiler.compile()
        kmodel = self.compiler.gencode_tobytes()
        os.makedirs(infer_dir, exist_ok=True)
        with open(os.path.join(infer_dir, 'test.kmodel'), 'wb') as f:
            f.write(kmodel)
        sim = nncase.Simulator()
        sim.load_model(kmodel)
        self.set_infer_input(preprocess, case_dir, sim)
        sim.run()
        infer_output_paths = self.dump_infer_output(infer_dir, preprocess, sim)
        return infer_output_paths

    def get_infer_compile_options(self, infer_dir: str, cfg, compile_options: nncase.CompileOptions,
                                  kwargs: Dict[str, str],
                                  preprocess: Dict[str, str]):
        compile_options.target = kwargs['target']
        compile_options.dump_dir = infer_dir
        compile_options.dump_asm = cfg.compile_opt.dump_asm
        compile_options.dump_ir = cfg.compile_opt.dump_ir
        compile_options.dump_quant_error = cfg.compile_opt.dump_quant_error
        compile_options.dump_import_op_range = cfg.compile_opt.dump_import_op_range
        compile_options.is_fpga = cfg.compile_opt.is_fpga
        compile_options.use_mse_quant_w = cfg.compile_opt.use_mse_quant_w
        compile_options.quant_type = cfg.compile_opt.quant_type
        compile_options.w_quant_type = cfg.compile_opt.w_quant_type
        compile_options = preprocess_utils.update_compile_options(compile_options, preprocess)
        compile_options.tcu_num = cfg.compile_opt.tcu_num
        compile_options.shape_bucket_options = nncase.ShapeBucketOptions()
        compile_options.shape_bucket_options.enable = False
        compile_options.shape_bucket_options.range_info = {}
        compile_options.shape_bucket_options.segments_count = 2
        compile_options.shape_bucket_options.fix_var_map = {}
        return compile_options

    def set_infer_input(self, preprocess, case_dir, sim):
        for idx, value in enumerate(self.inputs):
            data = self.transform_input(
                value['data'], preprocess['input_type'], "infer")[0]
            dtype = preprocess['input_type']
            if preprocess['preprocess'] and dtype != 'float32':
                if not test_utils.in_ci():
                    data.tofile(os.path.join(case_dir, f'input_{idx}_{dtype}.bin'))
                    self.totxtfile(os.path.join(case_dir, f'input_{idx}_{dtype}.txt'), data)

            sim.set_input_tensor(idx, nncase.RuntimeTensor.from_numpy(data))

    def dump_infer_output(self, infer_dir, preprocess, sim):
        infer_output_paths = []
        for i in range(sim.outputs_size):
            output = sim.get_output_tensor(i).to_numpy()
            if preprocess['preprocess']:
                if(preprocess['output_layout'] == 'NHWC' and self.model_type in ['caffe', 'onnx']):
                    output = np.transpose(output, [0, 3, 1, 2])
                elif (preprocess['output_layout'] == 'NCHW' and self.model_type in ['tflite']):
                    output = np.transpose(output, [0, 2, 3, 1])
                elif preprocess['output_layout'] not in ["NCHW", "NHWC"]:
                    tmp_perm = [int(idx) for idx in preprocess['output_layout'].split(",")]
                    output = np.transpose(
                        output, preprocess_utils.get_source_transpose_index(tmp_perm))
            infer_output_paths.append((
                os.path.join(infer_dir, f'nncase_result_{i}.bin'),
                os.path.join(infer_dir, f'nncase_result_{i}.txt')))
            output.tofile(infer_output_paths[-1][0])
            if not test_utils.in_ci():
                self.totxtfile(infer_output_paths[-1][1], output)
        return infer_output_paths
