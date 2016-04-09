using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RandomGraph.Test
{
    [TestClass]
    public class DimacsFileExportTest
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

        private static readonly string ExportDimacsFile = "c Random generated graph."
                                                        + $"{Environment.NewLine}p edge 3 6"
                                                        + $"{Environment.NewLine}a 1 1 1 2 4"
                                                        + $"{Environment.NewLine}a 2 0 3 2 1"
                                                        + $"{Environment.NewLine}a 1 0 1 1 3";

        [TestMethod]
        public void ExportDimacsGraph_WriteData_Called()
        {
            var writerMock = new Mock<IDataWriter>();
                writerMock.Setup(metod => metod.WriteData(It.IsAny<string>()));

            var dimacsFileExport = new DimacsFileExport(writerMock.Object);
            var dummyGraph = GetDummyGraph();
            dimacsFileExport.ExportGraph(dummyGraph);

            writerMock.Verify(method => method.WriteData(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void ExportDimacsGraph_WriteData_CorrectFormat()
        {
            var writerMock = new Mock<IDataWriter>();
            writerMock.Setup(metod => metod.WriteData(It.IsAny<string>()));

            var dimacsFileExport = new DimacsFileExport(writerMock.Object);
            var dummyGraph = GetDummyGraph();
            dimacsFileExport.ExportGraph(dummyGraph);

            writerMock.Verify(method => method.WriteData(ExportDimacsFile), Times.Once);
        }
    }
}
