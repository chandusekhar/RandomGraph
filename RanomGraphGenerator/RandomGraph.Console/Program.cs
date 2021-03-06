﻿using System;
using System.Collections.Generic;
using CommandLine;
using log4net.Config;
using RandomGraph.Console.Options;

namespace RandomGraph.Console
{
    static class Program
    {
        static int Main(string[] args)
        {
            XmlConfigurator.Configure();

            Action<Dictionary<Vertex, List<Edge>>, OptionsBase> exportAct = (graph, options) =>
                {
                    IExportGraph exportFile = null;
                    var dataWriter = new FileWriter(options.ExportGraphFileName);
                    if (options.ExportGraphFileType == GraphFileType.Dimacs)
                    {
                        exportFile = new DimacsFileExport(dataWriter);
                    }
                    else if (options.ExportGraphFileType == GraphFileType.FullWeightedMetis)
                    {
                        exportFile = new FullWeightedMetisFileExport(dataWriter);
                    }
                    else if (options.ExportGraphFileType == GraphFileType.UnweightedMetis)
                    {
                        exportFile = new UnweightedMetisFileExport(dataWriter);
                    }
                    else if (options.ExportGraphFileType == GraphFileType.D3Json)
                    {
                        exportFile = new D3JsonFileExport(dataWriter);
                    }

                    if (exportFile == null) throw new ApplicationException("The application does not support file export type.");

                    exportFile.ExportGraph(graph);
                };

            Func<RandomGraphOptions, Dictionary<Vertex, List<Edge>>> randomGraphFunc = options =>
                {
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

                    var graph = randomGraph.GenerateGraph();
                    return graph;
                };

            Func<ConvertGraphOptions, Dictionary<Vertex, List<Edge>>> parseGraphFromFileFunc =
                options =>
                {
                    var fileLoader = new FileLoader(options.InputGraphFileName);

                    ParseGraphBase graphParser = null;
                    if (options.ImportGraphFileType == GraphFileType.Dimacs)
                    {
                        graphParser = new ParseDimacsGraph(fileLoader);
                    }

                    if (graphParser == null) throw new ApplicationException("The application does not support input graph model.");

                    var graph = graphParser.ParseGraph();
                    return graph;
                };

            var result = Parser.Default.ParseArguments<RandomGraphOptions, ConvertGraphOptions>(args);
            var exitCode = result
                .MapResult(
                (RandomGraphOptions options) =>
                    {
                        if (options.Verbose)
                        {
                            System.Console.WriteLine("Filenames: {0}", 1);
                        }
                        else
                        {
                            System.Console.WriteLine("Processing...");

                            var graph = randomGraphFunc(options);
                            exportAct(graph, options);
                        }
                        return 0;
                    },
                    (ConvertGraphOptions options) =>
                    {
                        var graph = parseGraphFromFileFunc(options);
                        exportAct(graph, options);

                        return 0;
                    },
                    errors => 1);
            return exitCode;
        }
    }
}
