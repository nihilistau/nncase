# Copyright 2019-2021 Canaan Inc.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
"""System test: test gather nd"""
# pylint: disable=invalid-name, unused-argument, import-outside-toplevel

import pytest
import tensorflow as tf
import numpy as np
from test_runner import TfliteTestRunner

def _make_module(in_shape, indice):
    class GatherModule(tf.Module):
        def __init__(self):
            super(GatherModule).__init__()

        @tf.function(input_signature=[tf.TensorSpec(in_shape, tf.float32)])
        def __call__(self, x):
            return tf.gather_nd(x, indice, batch_dims=0)
    return GatherModule()


in_shape_indice = [
    ([11], [[0], [7], [5]]),
    ([3, 5], [[[0, 2], [0, 4]]]),
    ([2, 3, 1], [[0], [1]]),
    ([2, 3, 1], [[[0], [0], [0]], [[0], [0], [0]]]),
    ([5, 7, 5], [1, 4, 3]),
    ([2, 2, 2], [[0, 1], [1, 0]]),
    ([2, 2, 2], [[1], [0]]),
    ([5, 4, 3, 2], [[1, 0, 2], [1, 2, 2]]),
    ([5, 5, 7, 7], [[1, 2, 3], [1, 2, 3]]),
    ([5, 5, 7, 7], [[1, 2, 3, 1], [1, 2, 3, 1]]),
    ([5, 4, 3, 2], [[1, 0, 2], [1, 2, 2]]),
]

@pytest.mark.parametrize('in_shape,indice', in_shape_indice)
def test_gather_nd(in_shape, indice, request):
    module = _make_module(in_shape, indice)
    runner = TfliteTestRunner(request.node.name)
    model_file = runner.from_tensorflow(module)
    runner.run(model_file)

if __name__ == "__main__":
    pytest.main(['-vv', 'test_gather_nd.py'])