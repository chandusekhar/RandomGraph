using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RandomGraph.Test
{
    [TestClass]
    public class MetisFileExportTest
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

        private static readonly string ExportMetisFile = "3 6"
                                                       + $"{Environment.NewLine}1 1 1 2 4"
                                                       + $"{Environment.NewLine}2 0 3 2 1"
                                                       + $"{Environment.NewLine}1 0 1 1 3";

        [TestMethod]
        public void ExportMetisGraph_WriteData_Called()
        {
            var writerMock = new Mock<IDataWriter>();
            writerMock.Setup(metod => metod.WriteData(It.IsAny<string>()));

            var metisFileExport = new FullWeightedMetisFileExport(writerMock.Object);
            var dummyGraph = GetDummyGraph();
            metisFileExport.ExportGraph(dummyGraph);

            writerMock.Verify(method => method.WriteData(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void ExportmetisGraph_WriteData_CorrectFormat()
        {
            var writerMock = new Mock<IDataWriter>();
            writerMock.Setup(metod => metod.WriteData(It.IsAny<string>()));

            var metisFileExport = new FullWeightedMetisFileExport(writerMock.Object);
            var dummyGraph = GetDummyGraph();
            metisFileExport.ExportGraph(dummyGraph);

            writerMock.Verify(method => method.WriteData(ExportMetisFile), Times.Once);
        }
    }
}
