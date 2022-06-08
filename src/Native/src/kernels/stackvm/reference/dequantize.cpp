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
#include <nncase/kernels/cpu/reference/runtime_types.h>
#include <nncase/kernels/kernel_utils.h>
#include <nncase/kernels/stackvm/tensor_ops.h>
#include <nncase/runtime/allocator.h>
#include <nncase/runtime/host_buffer.h>
#include <nncase/runtime/runtime_op_utility.h>
#include <nncase/runtime/util.h>

using namespace nncase;
using namespace nncase::runtime;
using namespace nncase::runtime::stackvm;
using namespace nncase::kernels;
using namespace nncase::kernels::cpu;
using namespace nncase::kernels::cpu::reference;

namespace {
template <class TQint, class TFloat>
result<void>
dequantize_impl(const TQint *input, TFloat *output, const dims_t &in_shape,
                const strides_t &in_strides, const strides_t &out_strides,
                float scale, float bias,
                NNCASE_UNUSED kernel_context &context) noexcept {
    return apply(in_shape, [&](const dims_t &index) -> result<void> {
        auto value = (float)input[offset(in_strides, index)];
        value = value * scale + bias;
        output[offset(out_strides, index)] = (TFloat)value;
        return ok();
    });
}
} // namespace

#define DEQUANTIZE_IMPL(qint_t, float_t)                                       \
    if (cmp_type<qint_t>(in_type) && cmp_type<float_t>(out_type))              \
    return dequantize_impl(reinterpret_cast<const qint_t *>(input),            \
                           reinterpret_cast<float_t *>(output), in_shape,      \
                           in_strides, out_strides, scale, bias, context)

result<void> dequantize_impl(datatype_t in_type, datatype_t out_type,
                             const gsl::byte *input, gsl::byte *output,
                             const dims_t &in_shape,
                             const strides_t &in_strides,
                             const strides_t &out_strides, float scale,
                             float bias, kernel_context &context) noexcept {
    DEQUANTIZE_IMPL(uint8_t, float);
    DEQUANTIZE_IMPL(int8_t, float);
    return err(std::errc::not_supported);
}

result<value_t> nncase::kernels::stackvm::dequantize(typecode_t target_type,
                                                     value_t input,
                                                     value_t dequant_param,
                                                     value_t output,
                                                     kernel_context &context) {
    try_input(input_mem, input);
    try_output(out_mem, output, target_type, input_tensor->shape());
    try_var(deq_param, value_as_quant_param(dequant_param));

    try_(dequantize_impl(input_tensor->dtype(), output_tensor->dtype(), input_mem,
                         out_mem, input_tensor->shape(), input_tensor->strides(),
                         output_tensor->strides(), deq_param.scale,
                         (float)deq_param.zero_point, context));
    return ok(output);
}