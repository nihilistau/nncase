﻿
//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4 template.
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reactive;

namespace Nncase.IR;

public partial class ExprRewriter<TContext>
{
    /// <inheritdoc/>
    protected sealed override Expr VisitLeafBaseFunction(BaseFunction expr, TContext context)
    {
        return RewriteLeafBaseFunction(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafCall(Call expr, TContext context)
    {
        return RewriteLeafCall(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafConst(Const expr, TContext context)
    {
        return RewriteLeafConst(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafFunction(Function expr, TContext context)
    {
        return RewriteLeafFunction(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafFusion(Fusion expr, TContext context)
    {
        return RewriteLeafFusion(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafIf(If expr, TContext context)
    {
        return RewriteLeafIf(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafMarker(Marker expr, TContext context)
    {
        return RewriteLeafMarker(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafNone(None expr, TContext context)
    {
        return RewriteLeafNone(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafOp(Op expr, TContext context)
    {
        return RewriteLeafOp(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafPrimFunctionWrapper(PrimFunctionWrapper expr, TContext context)
    {
        return RewriteLeafPrimFunctionWrapper(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafTensorConst(TensorConst expr, TContext context)
    {
        return RewriteLeafTensorConst(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafTuple(IR.Tuple expr, TContext context)
    {
        return RewriteLeafTuple(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafTupleConst(TupleConst expr, TContext context)
    {
        return RewriteLeafTupleConst(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafVar(Var expr, TContext context)
    {
        return RewriteLeafVar(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafBlock(TIR.Block expr, TContext context)
    {
        return RewriteLeafBlock(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafBuffer(TIR.Buffer expr, TContext context)
    {
        return RewriteLeafBuffer(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafLogicalBuffer(TIR.LogicalBuffer expr, TContext context)
    {
        return RewriteLeafLogicalBuffer(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafPhysicalBuffer(TIR.PhysicalBuffer expr, TContext context)
    {
        return RewriteLeafPhysicalBuffer(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafBufferLoad(TIR.BufferLoad expr, TContext context)
    {
        return RewriteLeafBufferLoad(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafBufferRegion(TIR.BufferRegion expr, TContext context)
    {
        return RewriteLeafBufferRegion(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafBufferStore(TIR.BufferStore expr, TContext context)
    {
        return RewriteLeafBufferStore(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafFor(TIR.For expr, TContext context)
    {
        return RewriteLeafFor(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafIfThenElse(TIR.IfThenElse expr, TContext context)
    {
        return RewriteLeafIfThenElse(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafLet(TIR.Let expr, TContext context)
    {
        return RewriteLeafLet(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafPrimFunction(TIR.PrimFunction expr, TContext context)
    {
        return RewriteLeafPrimFunction(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafSequential(TIR.Sequential expr, TContext context)
    {
        return RewriteLeafSequential(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafRange(TIR.Range expr, TContext context)
    {
        return RewriteLeafRange(expr, context);
    }

    /// <inheritdoc/>
    protected sealed override Expr VisitLeafIterVar(TIR.IterVar expr, TContext context)
    {
        return RewriteLeafIterVar(expr, context);
    }

    /// <summary>
    /// Rewrite leaf <see cref="BaseFunction"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBaseFunction(BaseFunction expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="Call"/>.
    /// </summary>
    protected virtual Expr RewriteLeafCall(Call expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="Const"/>.
    /// </summary>
    protected virtual Expr RewriteLeafConst(Const expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="Function"/>.
    /// </summary>
    protected virtual Expr RewriteLeafFunction(Function expr, TContext context) => RewriteLeafBaseFunction(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="Fusion"/>.
    /// </summary>
    protected virtual Expr RewriteLeafFusion(Fusion expr, TContext context) => RewriteLeafBaseFunction(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="If"/>.
    /// </summary>
    protected virtual Expr RewriteLeafIf(If expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="Marker"/>.
    /// </summary>
    protected virtual Expr RewriteLeafMarker(Marker expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="None"/>.
    /// </summary>
    protected virtual Expr RewriteLeafNone(None expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="Op"/>.
    /// </summary>
    protected virtual Expr RewriteLeafOp(Op expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="PrimFunctionWrapper"/>.
    /// </summary>
    protected virtual Expr RewriteLeafPrimFunctionWrapper(PrimFunctionWrapper expr, TContext context) => RewriteLeafBaseFunction(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TensorConst"/>.
    /// </summary>
    protected virtual Expr RewriteLeafTensorConst(TensorConst expr, TContext context) => RewriteLeafConst(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="IR.Tuple"/>.
    /// </summary>
    protected virtual Expr RewriteLeafTuple(IR.Tuple expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TupleConst"/>.
    /// </summary>
    protected virtual Expr RewriteLeafTupleConst(TupleConst expr, TContext context) => RewriteLeafConst(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="Var"/>.
    /// </summary>
    protected virtual Expr RewriteLeafVar(Var expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Block"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBlock(TIR.Block expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Buffer"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBuffer(TIR.Buffer expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.LogicalBuffer"/>.
    /// </summary>
    protected virtual Expr RewriteLeafLogicalBuffer(TIR.LogicalBuffer expr, TContext context) => RewriteLeafBuffer(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.PhysicalBuffer"/>.
    /// </summary>
    protected virtual Expr RewriteLeafPhysicalBuffer(TIR.PhysicalBuffer expr, TContext context) => RewriteLeafBuffer(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.BufferLoad"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBufferLoad(TIR.BufferLoad expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.BufferRegion"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBufferRegion(TIR.BufferRegion expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.BufferStore"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBufferStore(TIR.BufferStore expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.For"/>.
    /// </summary>
    protected virtual Expr RewriteLeafFor(TIR.For expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.IfThenElse"/>.
    /// </summary>
    protected virtual Expr RewriteLeafIfThenElse(TIR.IfThenElse expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Let"/>.
    /// </summary>
    protected virtual Expr RewriteLeafLet(TIR.Let expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.PrimFunction"/>.
    /// </summary>
    protected virtual Expr RewriteLeafPrimFunction(TIR.PrimFunction expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Sequential"/>.
    /// </summary>
    protected virtual Expr RewriteLeafSequential(TIR.Sequential expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Range"/>.
    /// </summary>
    protected virtual Expr RewriteLeafRange(TIR.Range expr, TContext context) => DefaultRewriteLeaf(expr, context);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.IterVar"/>.
    /// </summary>
    protected virtual Expr RewriteLeafIterVar(TIR.IterVar expr, TContext context) => DefaultRewriteLeaf(expr, context);

}

public partial class ExprRewriter
{
    /// <summary>
    /// Rewrite leaf <see cref="BaseFunction"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBaseFunction(BaseFunction expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafBaseFunction(BaseFunction expr, Unit context) => RewriteLeafBaseFunction(expr);

    /// <summary>
    /// Rewrite leaf <see cref="Call"/>.
    /// </summary>
    protected virtual Expr RewriteLeafCall(Call expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafCall(Call expr, Unit context) => RewriteLeafCall(expr);

    /// <summary>
    /// Rewrite leaf <see cref="Const"/>.
    /// </summary>
    protected virtual Expr RewriteLeafConst(Const expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafConst(Const expr, Unit context) => RewriteLeafConst(expr);

    /// <summary>
    /// Rewrite leaf <see cref="Function"/>.
    /// </summary>
    protected virtual Expr RewriteLeafFunction(Function expr) => RewriteLeafBaseFunction(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafFunction(Function expr, Unit context) => RewriteLeafFunction(expr);

    /// <summary>
    /// Rewrite leaf <see cref="Fusion"/>.
    /// </summary>
    protected virtual Expr RewriteLeafFusion(Fusion expr) => RewriteLeafBaseFunction(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafFusion(Fusion expr, Unit context) => RewriteLeafFusion(expr);

    /// <summary>
    /// Rewrite leaf <see cref="If"/>.
    /// </summary>
    protected virtual Expr RewriteLeafIf(If expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafIf(If expr, Unit context) => RewriteLeafIf(expr);

    /// <summary>
    /// Rewrite leaf <see cref="Marker"/>.
    /// </summary>
    protected virtual Expr RewriteLeafMarker(Marker expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafMarker(Marker expr, Unit context) => RewriteLeafMarker(expr);

    /// <summary>
    /// Rewrite leaf <see cref="None"/>.
    /// </summary>
    protected virtual Expr RewriteLeafNone(None expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafNone(None expr, Unit context) => RewriteLeafNone(expr);

    /// <summary>
    /// Rewrite leaf <see cref="Op"/>.
    /// </summary>
    protected virtual Expr RewriteLeafOp(Op expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafOp(Op expr, Unit context) => RewriteLeafOp(expr);

    /// <summary>
    /// Rewrite leaf <see cref="PrimFunctionWrapper"/>.
    /// </summary>
    protected virtual Expr RewriteLeafPrimFunctionWrapper(PrimFunctionWrapper expr) => RewriteLeafBaseFunction(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafPrimFunctionWrapper(PrimFunctionWrapper expr, Unit context) => RewriteLeafPrimFunctionWrapper(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TensorConst"/>.
    /// </summary>
    protected virtual Expr RewriteLeafTensorConst(TensorConst expr) => RewriteLeafConst(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafTensorConst(TensorConst expr, Unit context) => RewriteLeafTensorConst(expr);

    /// <summary>
    /// Rewrite leaf <see cref="IR.Tuple"/>.
    /// </summary>
    protected virtual Expr RewriteLeafTuple(IR.Tuple expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafTuple(IR.Tuple expr, Unit context) => RewriteLeafTuple(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TupleConst"/>.
    /// </summary>
    protected virtual Expr RewriteLeafTupleConst(TupleConst expr) => RewriteLeafConst(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafTupleConst(TupleConst expr, Unit context) => RewriteLeafTupleConst(expr);

    /// <summary>
    /// Rewrite leaf <see cref="Var"/>.
    /// </summary>
    protected virtual Expr RewriteLeafVar(Var expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafVar(Var expr, Unit context) => RewriteLeafVar(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Block"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBlock(TIR.Block expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafBlock(TIR.Block expr, Unit context) => RewriteLeafBlock(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Buffer"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBuffer(TIR.Buffer expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafBuffer(TIR.Buffer expr, Unit context) => RewriteLeafBuffer(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.LogicalBuffer"/>.
    /// </summary>
    protected virtual Expr RewriteLeafLogicalBuffer(TIR.LogicalBuffer expr) => RewriteLeafBuffer(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafLogicalBuffer(TIR.LogicalBuffer expr, Unit context) => RewriteLeafLogicalBuffer(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.PhysicalBuffer"/>.
    /// </summary>
    protected virtual Expr RewriteLeafPhysicalBuffer(TIR.PhysicalBuffer expr) => RewriteLeafBuffer(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafPhysicalBuffer(TIR.PhysicalBuffer expr, Unit context) => RewriteLeafPhysicalBuffer(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.BufferLoad"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBufferLoad(TIR.BufferLoad expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafBufferLoad(TIR.BufferLoad expr, Unit context) => RewriteLeafBufferLoad(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.BufferRegion"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBufferRegion(TIR.BufferRegion expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafBufferRegion(TIR.BufferRegion expr, Unit context) => RewriteLeafBufferRegion(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.BufferStore"/>.
    /// </summary>
    protected virtual Expr RewriteLeafBufferStore(TIR.BufferStore expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafBufferStore(TIR.BufferStore expr, Unit context) => RewriteLeafBufferStore(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.For"/>.
    /// </summary>
    protected virtual Expr RewriteLeafFor(TIR.For expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafFor(TIR.For expr, Unit context) => RewriteLeafFor(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.IfThenElse"/>.
    /// </summary>
    protected virtual Expr RewriteLeafIfThenElse(TIR.IfThenElse expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafIfThenElse(TIR.IfThenElse expr, Unit context) => RewriteLeafIfThenElse(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Let"/>.
    /// </summary>
    protected virtual Expr RewriteLeafLet(TIR.Let expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafLet(TIR.Let expr, Unit context) => RewriteLeafLet(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.PrimFunction"/>.
    /// </summary>
    protected virtual Expr RewriteLeafPrimFunction(TIR.PrimFunction expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafPrimFunction(TIR.PrimFunction expr, Unit context) => RewriteLeafPrimFunction(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Sequential"/>.
    /// </summary>
    protected virtual Expr RewriteLeafSequential(TIR.Sequential expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafSequential(TIR.Sequential expr, Unit context) => RewriteLeafSequential(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.Range"/>.
    /// </summary>
    protected virtual Expr RewriteLeafRange(TIR.Range expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafRange(TIR.Range expr, Unit context) => RewriteLeafRange(expr);

    /// <summary>
    /// Rewrite leaf <see cref="TIR.IterVar"/>.
    /// </summary>
    protected virtual Expr RewriteLeafIterVar(TIR.IterVar expr) => DefaultRewriteLeaf(expr);

    /// <inheritdoc />
    protected sealed override Expr RewriteLeafIterVar(TIR.IterVar expr, Unit context) => RewriteLeafIterVar(expr);

}
