using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RandomGraph.Test
{
    [TestClass]
    public class D3JsonFileExportTest
    {
        private Dictionary<Vertex, List<Edge>> GetDummyGraph()
        {
            var dummyGraph = new Dictionary<Vertex, List<Edge>>
            {
                {new Vertex(0, 1), new List<Edge> {new Edge(1, 1), new Edge(2, 4)}},
                {new Vertex(1, 2), new List<Edge> {new Edge(0, 3), new Edge(2, 1)}},
                {new Vertex(2, 1), new List<Edge> {new Edge(0, 1), new Edge(1, 3)}}
            };

            return dummyGraph;
        }

        private static readonly string Export3DJSONFile = "{\"nodes\":[{\"name\":\"1\",\"group\":1},{\"name\":\"2\",\"group\":1},{\"name\":\"3\",\"group\":1}],\"links\":[{\"source\":0,\"target\":1,\"value\":1},{\"source\":0,\"target\":2,\"value\":1},{\"source\":1,\"target\":0,\"value\":1},{\"source\":1,\"target\":2,\"value\":1},{\"source\":2,\"target\":0,\"value\":1},{\"source\":2,\"target\":1,\"value\":1}]";

        [TestMethod]
        public void ExportDimacsGraph_WriteData_Called()
        {
            var writerMock = new Mock<IDataWriter>();
            writerMock.Setup(metod => metod.WriteData(It.IsAny<string>()));

            var d3JsonFileExport = new D3JsonFileExport(writerMock.Object);
            var dummyGraph = GetDummyGraph();
            d3JsonFileExport.ExportGraph(dummyGraph);

            writerMock.Verify(method => method.WriteData(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void ExportDimacsGraph_WriteData_CorrectFormat()
        {
            var writerMock = new Mock<IDataWriter>();
            writerMock.Setup(metod => metod.WriteData(It.IsAny<string>()));

            var d3JsonFileExport = new D3JsonFileExport(writerMock.Object);
            var dummyGraph = GetDummyGraph();
            d3JsonFileExport.ExportGraph(dummyGraph);

            writerMock.Verify(method => method.WriteData(Export3DJSONFile), Times.Once);
        }
    }
}
