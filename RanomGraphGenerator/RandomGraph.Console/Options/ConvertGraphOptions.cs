using CommandLine;

namespace RandomGraph.Console.Options
{
    // convert input.txt -i 0 -o 0
    [Verb("convert", HelpText = "Convert file with the graph to another format.")]
    class ConvertGraphOptions : OptionsBase
    {
        [Option('p', HelpText = "Type of the graph for output file.", Required = true)]
        GraphFileType ImportGraphFileType { get; set; }

        [Option('i', HelpText = "Input file with graph to be processed.", Required = true)]
        string InputGraphFileName { get; set; }
    }
}
