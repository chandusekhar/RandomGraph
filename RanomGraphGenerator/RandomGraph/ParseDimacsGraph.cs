using System.Security.Cryptography.X509Certificates;

namespace RandomGraph
{
    public class ParseDimacsGraph : ParseGraphBase
    {
        public ParseDimacsGraph(IDataLoader dataLoader) : base(dataLoader)
        {
        }
    }

    public abstract class ParseGraphBase
    {
        public IDataLoader DataLoader { get; set; }

        protected ParseGraphBase(IDataLoader dataLoader)
        {
            DataLoader = dataLoader;
        }
    }
}
