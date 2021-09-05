/* Copyright 2019-2021 Canaan Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#include "../tflite_importer.h"
#include <nncase/ir/nn/activation.h>

using namespace nncase;
using namespace nncase::importer;
using namespace nncase::ir;

// DEFINE_TFLITE_LOWER(RELU)
//{
//    auto &input = get_tensor(op.inputs(), 0);
//    auto &output = get_tensor(op.outputs(), 0);
//    auto in_shape = get_shape(input.shape());
//
//    auto zero = graph_.emplace<constant>(0.f);
//    zero->name(get_tensor(op.outputs(), 0).name()->string_view());
//    auto max = graph_.emplace<binary>(binary_max, in_shape,
//    zero->output().shape(), value_range<float>::full());
//    max->name(get_tensor(op.outputs(), 0).name()->string_view());
//    max->input_b().connect(zero->output());
//    if (input.type() != tflite::TensorType_FLOAT32)
//    {
//        quant_param_t input_dequant_paras =
//        to_quant_param(input.quantization()); quant_param_t output_quant_paras
//        = to_quant_param(output.quantization()); auto input_dequant =
//        graph_.emplace<dequantize>(to_data_type(input.type()),
//        get_shape(input.shape()), dt_float32, input_dequant_paras); auto
//        output_quant = graph_.emplace<quantize>(dt_float32,
//        get_shape(output.shape()), to_data_type(output.type()),
//        output_quant_paras);
//        input_dequant->name(std::string(output.name()->string_view()) +
//        "/input_dequant");
//        output_quant->name(std::string(output.name()->string_view()) +
//        "/output_quant");
//
//        max->input_a().connect(input_dequant->output());
//        output_quant->input().connect(max->output());
//
//        link_input_tensor(&input_dequant->input(), op.inputs()->Get(0));
//        link_output_tensor(op.outputs()->Get(0), &output_quant->output());
//    }
//    else
//    {
//
//        link_input_tensor(&max->input_a(), op.inputs()->Get(0));
//        link_output_tensor(op.outputs()->Get(0), &max->output());
//    }
//}
//
// DEFINE_TFLITE_LOWER(PRELU)
//{
//    auto &input = get_tensor(op.inputs(), 0);
//    auto &slope = get_tensor(op.inputs(), 1);
//    auto &output = get_tensor(op.outputs(), 0);
//
//    auto in_shape = get_shape(input.shape());
//    auto slope_shape = get_shape(slope.shape());
//
//    auto zero = graph_.emplace<constant>(0.f);
//    zero->name(output.name()->string_view());
//
//    auto pos = graph_.emplace<binary>(binary_max, in_shape,
//    zero->output().shape(), value_range<float>::full()); auto neg =
//    graph_.emplace<binary>(binary_min, in_shape, zero->output().shape(),
//    value_range<float>::full()); auto mul = graph_.emplace<binary>(binary_mul,
//    neg->output().shape(), slope_shape, value_range<float>::full()); auto add
//    = graph_.emplace<binary>(binary_add, pos->output().shape(),
//    mul->output().shape(), value_range<float>::full());
//
//    pos->name(std::string(output.name()->string_view()) + "/pos");
//    neg->name(std::string(output.name()->string_view()) + "/neg");
//    mul->name(std::string(output.name()->string_view()) + "/mul");
//    add->name(std::string(output.name()->string_view()) + "/add");
//
//    link_input_tensor(&pos->input_a(), op.inputs()->Get(0));
//    pos->input_b().connect(zero->output());
//
//    link_input_tensor(&neg->input_a(), op.inputs()->Get(0));
//    neg->input_b().connect(zero->output());
//
//    mul->input_a().connect(neg->output());
//    link_input_tensor(&mul->input_b(), op.inputs()->Get(1));
//    add->input_a().connect(pos->output());
//    add->input_b().connect(mul->output());
//
//    link_output_tensor(op.outputs()->Get(0), &add->output());
//}
//
// DEFINE_TFLITE_LOWER(RELU6)
//{
//    auto &input = get_tensor(op.inputs(), 0);
//    auto in_shape = get_shape(input.shape());
//
//    auto zero = graph_.emplace<constant>(0.f);
//    auto six = graph_.emplace<constant>(6.f);
//    auto cl = graph_.emplace<clamp>(in_shape, zero->output().shape(),
//    six->output().shape());
//
//    zero->name(get_tensor(op.outputs(), 0).name()->string_view());
//    six->name(get_tensor(op.outputs(), 0).name()->string_view());
//    cl->name(get_tensor(op.outputs(), 0).name()->string_view());
//
//    cl->input_low().connect(zero->output());
//    cl->input_high().connect(six->output());
//
//    link_input_tensor(&cl->input(), op.inputs()->Get(0));
//    link_output_tensor(op.outputs()->Get(0), &cl->output());
//}
//
// DEFINE_TFLITE_LOWER(LEAKY_RELU)
//{
//    auto &input = get_tensor(op.inputs(), 0);
//    auto &output = get_tensor(op.outputs(), 0);
//    auto &options = *op.builtin_options_as_LeakyReluOptions();
//    auto in_shape = get_shape(input.shape());
//
//    auto alpha = graph_.emplace<constant>(options.alpha());
//    auto mul = graph_.emplace<binary>(binary_mul, in_shape,
//    alpha->output().shape(), value_range<float>::full()); auto max =
//    graph_.emplace<binary>(binary_max, in_shape, mul->output().shape(),
//    value_range<float>::full());
//    alpha->name(std::string(get_tensor(op.outputs(), 0).name()->string_view())
//    + "/alpha"); mul->name(std::string(get_tensor(op.outputs(),
//    0).name()->string_view()) + "/mul");
//    max->name(std::string(get_tensor(op.outputs(), 0).name()->string_view()) +
//    "/max");
//
//    if (input.type() != tflite::TensorType_FLOAT32)
//    {
//        quant_param_t input_dequant_paras =
//        to_quant_param(input.quantization()); quant_param_t output_quant_paras
//        = to_quant_param(output.quantization()); auto input_dequant =
//        graph_.emplace<dequantize>(to_data_type(input.type()),
//        get_shape(input.shape()), dt_float32, input_dequant_paras); auto
//        output_quant = graph_.emplace<quantize>(dt_float32,
//        get_shape(output.shape()), to_data_type(output.type()),
//        output_quant_paras);
//        input_dequant->name(std::string(output.name()->string_view()) +
//        "/input_dequant");
//        output_quant->name(std::string(output.name()->string_view()) +
//        "/output_quant"); mul->input_b().connect(alpha->output());
//        mul->input_a().connect(input_dequant->output());
//        max->input_b().connect(mul->output());
//        max->input_a().connect(input_dequant->output());
//        output_quant->input().connect(max->output());
//
//        link_input_tensor(&input_dequant->input(), op.inputs()->Get(0));
//        link_output_tensor(op.outputs()->Get(0), &output_quant->output());
//    }
//    else
//    {
//        mul->input_b().connect(alpha->output());
//        max->input_b().connect(mul->output());
//
//        link_input_tensor(&mul->input_a(), op.inputs()->Get(0));
//        link_input_tensor(&max->input_a(), op.inputs()->Get(0));
//        link_output_tensor(op.outputs()->Get(0), &max->output());
//    }
//}

DEFINE_TFLITE_LOWER(LOGISTIC) {
    auto [input] = get_input_exprs(op, 0);
    nn::sigmoid node(input);
    set_output_expr(op, 0, node);
}
