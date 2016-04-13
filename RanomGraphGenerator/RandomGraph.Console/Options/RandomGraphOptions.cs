using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace RandomGraph.Console.Options
{
    // rnd 0 3 4 0 test.col
    [Verb("rnd", HelpText = "Generate random graph generator.")]
    class RandomGraphOptions : OptionsBase
    {
        [Value(0, Required = true, MetaName = "g", HelpText = "Random graph algoritham type.")]
        public RandomGraphType GraphAlgortiham { get; set; }

        [Value(1, Required = true, MetaName = "n", HelpText = "Number of the vertices in the graph.")]
        public int NumberOfVertices { get; set; }

        [Value(2, Required = true, MetaName = "e", HelpText = "Number of the expected edges in the graph.")]
        public int NumberOfEdges { get; set; }

        // Omitting long name, default --verbose
        [Option(HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Usage(ApplicationAlias = "Random graph generator")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Normal scenario", new RandomGraphOptions { GraphAlgortiham = RandomGraphType.ErdosRenyiEdges });
            }
        }
    }
}
