using System.Collections.Generic;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace RandomGraph.Console
{
    // 0 3 4 0 test.col
    public class Options
    {
        //[Option('r', "read", Required = true,
        //  HelpText = "Input files to be processed.")]
        //public IEnumerable<string> InputFiles { get; set; }

        [Value(0, Required = true, MetaName = "g", HelpText = "Random graph algoritham type.")]
        public RandomGraphType GraphAlgortiham { get; set; }

        [Value(1, Required = true, MetaName = "n", HelpText = "Number of the vertices in the graph.")]
        public int NumberOfVertices { get; set; }

        [Value(2, Required = true, MetaName = "e", HelpText = "Number of the expected edges in the graph.")]
        public int NumberOfEdges { get; set; }

        [Value(3, Required = true, MetaName = "f", HelpText = "Type of the graph output file.")]
        public ExportFileType ExportFileType { get; set; }

        [Value(4, Required = true, MetaName = "o", HelpText = "Type of the graph output file.")]
        public string ExportFileName { get; set; }

        // Omitting long name, default --verbose
        [Option(HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Usage(ApplicationAlias = "yourapp")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Normal scenario", new Options { GraphAlgortiham = RandomGraphType.ErdosRenyiEdges });
            }
        }
    }
}
