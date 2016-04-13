using System;
using CommandLine;
using RandomGraph.Console.Options;

namespace RandomGraph.Console
{
    static class Program
    {
        static int Main(string[] args)
        {
            // input: 0 3 4 0 test.col
            var result = Parser.Default.ParseArguments<RandomGraphOptions>(args);
            var exitCode = result.MapResult(options =>
            {
                if (options.Verbose)
                {
                    System.Console.WriteLine("Filenames: {0}", 1);
                }
                else
                {
                    System.Console.WriteLine("Processing...");

                    IRandomGraph randomGraph = null;
                    if (options.GraphAlgortiham == RandomGraphType.ErdosRenyiEdges)
                    {
                        randomGraph = new ErdosRenyiModel(options.NumberOfVertices, options.NumberOfEdges);
                    }
                    //else if (options.GraphAlgortiham == RandomGraphType.ErdosRenyiPercent)
                    //{
                    //    randomGraph = new ErdosRenyiModel(int.Parse(args[1]), double.Parse(args[2]));
                    //}

                    if (randomGraph == null) throw new ApplicationException("The application does not support random graph model.");

                    IExportGraph exportFile = null;
                    var dataWriter = new FileWriter(options.ExportFileName);
                    if (options.ExportFileType == GraphFileType.Dimacs)
                    {
                        exportFile = new DimacsFileExport(dataWriter);
                    }
                    if (exportFile == null) throw new ApplicationException("The application does not support file export type.");

                    var graph = randomGraph.GenerateGraph();
                    exportFile.ExportGraph(graph);
                }
                return 0;
            },
            errors => 1);
            return exitCode;
        }
    }
}
