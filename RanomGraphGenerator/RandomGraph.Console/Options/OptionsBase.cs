using CommandLine;

namespace RandomGraph.Console.Options
{
   abstract class OptionsBase
    {
        [Option('f', HelpText = "Type of the graph output file.", Required = true)]
        public GraphFileType ExportGraphFileType { get; set; }

        [Option('o', HelpText = "The file name of the graph output file.", Required = true)]
        public string ExportGraphFileName { get; set; }
    }
}
