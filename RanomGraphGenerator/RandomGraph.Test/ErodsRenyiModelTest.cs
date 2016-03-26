using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomGraph.Test
{
    [TestClass]
    public class ErodsRenyiModelTest
    {
        [TestMethod]
        public void GenerateGraph_VerticesAndEdges_HasCorrectNumberOfVertices()
        {
            const int numberOfVertices = 5;
            const int numberOfEdges = 10;

            var erodsRenyiModel = new ErodsRenyiModel(numberOfVertices, numberOfEdges);
            var graph = erodsRenyiModel.GenerateGraph();

            Assert.AreEqual(numberOfVertices, graph.Keys.Count);
        }

        [TestMethod]
        public void GenerateGraph_VerticesAndEdgeProbability_HasCorrectNumberOfVertices()
        {
            const int numberOfVertices = 5;
            const double edgeProbability = 0.5;

            var erodsRenyiModel = new ErodsRenyiModel(numberOfVertices, edgeProbability);
            var graph = erodsRenyiModel.GenerateGraph();

            Assert.AreEqual(numberOfVertices, graph.Keys.Count);
        }
    }
}
