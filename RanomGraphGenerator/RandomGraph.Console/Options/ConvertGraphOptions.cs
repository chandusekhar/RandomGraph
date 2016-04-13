using CommandLine;

namespace RandomGraph.Console.Options
{
    [Verb("convert", HelpText = "Convert file with the graph to another format.")]
    class ConvertGraphOptions
    {
        [Value(0, MetaName = "input file", HelpText = "Input file with graph to be processed.", Required = true)]
        string FileName { get; set; }

        [Option('i', "input", HelpText = "Input file with graph to be converted.")]
        GraphFileType ImportGraphFileType { get; set; }

        [Option('o', "output", HelpText = "Output file with converted graph.")]
        GraphFileType ExportGraphFileType { get; set; }
    }
}
