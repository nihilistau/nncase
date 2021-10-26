using System;
using System.Collections.Generic;
using System.Linq;
using Nncase.IR;
using Nncase.IR.Math;
using Nncase.Transform.Pattern.Math;

namespace Nncase.Transform.Pattern
{

    public abstract partial record ExprPattern()
    {
        public static implicit operator ExprPattern(Expr expr) => expr switch
        {
            (Var var) => new VarPattern(var),
            (Const con) => new ConstPattern(con),
            (Function function) => new FunctionPattern(function),
            (Call call) => new CallPattern(call),
            (IR.Tuple tuple) => new TuplePattern(tuple),
            (Op op) => op switch
            {
                Binary binary => new BinaryPattern(binary),
                Unary unary => new UnaryPattern(unary),
                _ => throw new NotImplementedException($"Can't Convert OP {expr.GetType().Name} To ExprPattern")
            },
            _ => throw new NotImplementedException($"Can't Convert The Expr {expr.GetType().Name} To ExprPattern")
        };

        public TypePattern? CheckedTypePat { get; set; }

        public bool MatchCheckedType(Expr expr)
        {
            if (expr.CheckedType is not null && CheckedTypePat is not null)
            {
                return CheckedTypePat.MatchLeaf(expr.CheckedType);
            }
            return true;
        }

        public virtual bool MatchLeaf(Expr expr) => (this, expr) switch
        {
            (VarPattern varPat, Var var) => varPat.MatchLeaf(var),
            (ConstPattern conPat, Const con) => conPat.MatchLeaf(con),
            (FunctionPattern functionPat, Function function) => functionPat.MatchLeaf(function),
            (CallPattern callPat, Call call) => callPat.MatchLeaf(call),
            (TuplePattern tuplePat, IR.Tuple tuple) => tuplePat.MatchLeaf(tuple),
            (OpPattern opPat, Op op) => opPat.MatchLeaf(op),
            (WildCardPattern wildcardPat, _) => wildcardPat.MatchLeaf(expr),
            (_, _) => false
        };

        public ExprPattern IsSomeType(Func<IRType, bool> Cond)
        {
            CheckedTypePat = new TypePattern(Cond);
            return this;
        }

        public ExprPattern IsAny() => IsSomeType(x => x == AnyType.Default);

        public ExprPattern IsTensor() => IsSomeType(x => x is TensorType);

        public ExprPattern IsScalar() => IsSomeType(x => x switch
             {
                 TensorType xt => xt.IsScalar,
                 _ => false
             });
    };

}