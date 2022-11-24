using Nncase.IR;
using Nncase.Utilities;

namespace Nncase.TestFixture;

/// <summary>
/// dump output shape group by op
/// </summary>
public static class RuntimeDumpAnalysis
{
    public static void ReadOutShapeList(string dumpResultRoot)
    {
        var data = MakeData(dumpResultRoot);
        PrintOutShapeList(data);
    }

    public static IEnumerable<IGrouping<string, (string, int)>> MakeData(string dumpResultRoot)
    {
        using var stream = new StreamReader(Path.Join(dumpResultRoot, "!out_shape_list"));
        return GroupByOp(stream.ReadToEnd());
    }
    
    private static IEnumerable<IGrouping<string, (string, int)>> GroupByOp(string str)
    {
        return str.Trim().Split("\n")
            .Select((x, i) => (x, i))
            .GroupBy(item => item.Item1.Split(":")[0]);
    }
    
    public static void PrintOutShapeList(IEnumerable<IGrouping<string, (string, int)>> data)
    {
        foreach (var valueTuples in data)
        {
            Console.WriteLine($"op:{valueTuples.Key} count:{valueTuples.Length()}");
            foreach ((string x, int i) in valueTuples)
            {
                Console.WriteLine($"index:{i} shape:{x.Split(":")[1]}");
            }
        }
    }
}

/// <summary>
/// compare Result between Runtime and Evaluator
/// Runtime Data: read from dir/fileName
/// Evaluator Data: make call from Param Data in Runtime and run evaluate 
/// </summary>
public static class RuntimeResultAnalysis
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dir">dump data dir</param>
    /// <param name="resultPath">resultPath for write cos</param>
    /// <param name="ctor">call constructor</param>
    public static void MatmulRun(string dir, string resultPath, Func<IEnumerable<Expr>, Call> ctor)
    {
        var e = new TextDataExtractor();
        var data = e.MatmulExtract(dir);
        var cosList = data.Select(d => RuntimeResultAnalysis.Run(d.FileName, dir, ctor).Head()).ToArray();
        DumpUtility.WriteResult(resultPath, cosList);
    }
    
    public static float[] Run(string fileName, string dir, Func<IEnumerable<Expr>, Call> f)
    {
        // 1. get params
        var e = new TextDataExtractor();
        var number = DumpPathExtractor.GetCount(fileName);
        var param = e.GetParams(dir, number).OrderBy(x => x.FileName.Last()).Select(x => x.Value);
        var expect = e.GetComputeResult(dir, number);
        // 2. construct call
        var call = MakeCall(param, f);
        // 3. evaluate and run
        var result = call.Evaluate();
        var cos = Comparator.CosSimilarity(result, expect.Value);
        return cos;
    }

    public static Call MakeCall(IEnumerable<IValue> parameters, Func<IEnumerable<Expr>, Call> f) => f(parameters.Select(Const.FromValue));
}