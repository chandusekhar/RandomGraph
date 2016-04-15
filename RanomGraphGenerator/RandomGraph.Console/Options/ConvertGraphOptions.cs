using CommandLine;

namespace RandomGraph.Console.Options
{
    // convert -f 1 -o test.txt -p 0 -i Graphs\myciel3.col
    [Verb("convert", HelpText = "Convert file with the graph to another format.")]
    class ConvertGraphOptions : OptionsBase
    {
        [Option('p', HelpText = "Type of the graph in input file - graph to be converted.", Required = true)]
        public GraphFileType ImportGraphFileType { get; set; }

        [Option('i', HelpText = "Input file with graph to be processed.", Required = true)]
        public string InputGraphFileName { get; set; }
    }
}
