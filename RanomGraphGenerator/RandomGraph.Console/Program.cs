using System;

namespace RandomGraph.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            // input: 0 3 4 0 test.col

            var randomGraphType = (RandomGraphType)Enum.Parse(typeof(RandomGraphType), args[0]);
            
            IRandomGraph randomGraph = null;
            if (randomGraphType == RandomGraphType.ErdosRenyiEdges)
            {
                randomGraph = new ErdosRenyiModel(int.Parse(args[1]), int.Parse(args[2]));
            } else if (randomGraphType == RandomGraphType.ErdosRenyiPercent)
            {
                randomGraph = new ErdosRenyiModel(int.Parse(args[1]), double.Parse(args[2]));
            }

            if (randomGraph == null) throw new ApplicationException("The application does not support random graph model.");

            var exportFileType = (ExportFileType)Enum.Parse(typeof(ExportFileType), args[3]);

            IExportGraph exportFile = null;
            var dataWriter = new FileWriter(args[4]);
            if (exportFileType == ExportFileType.Dimacs)
            {
                exportFile = new DimacsFileExport(dataWriter);
            }
            if (exportFile == null) throw new ApplicationException("The application does not support file export type.");

            var graph = randomGraph.GenerateGraph();
            exportFile.ExportGraph(graph);
        }
    }
}
