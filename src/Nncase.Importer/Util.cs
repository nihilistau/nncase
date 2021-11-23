using System.Collections.Generic;
using Nncase.IR;
using F = Nncase.IR.F;
using System.Linq;

namespace Nncase
{
    public class Util
    {
        public static Expr ShapeIndex(in Expr shape, int index)
        {
            return F.Tensors.Slice(shape, new[] { index }, new[] { index + 1 }, 1);
        }

        public static (Expr, Expr) GetHW(in Expr input)
        {
            var shape = F.Tensors.ShapeOp(input);
            return (ShapeIndex(shape, 2), ShapeIndex(shape, 3));
        }

        public static Expr ConcatPadding(Expr[] padH, Expr[] padW)
        {
            // return [[padh_before, padh_after],
            //         [padw_before, padw_after]]
            return F.Tensors.Stack(new Tuple(
              F.Tensors.Concat(new Tuple(padH), 0),
              F.Tensors.Concat(new Tuple(padW), 0)), 0);
        }
    }
}