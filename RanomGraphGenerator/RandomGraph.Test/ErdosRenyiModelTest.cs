using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomGraph.Test
{
    [TestClass]
    public class ErdosRenyiModelTest
    {
        [TestMethod]
        public void GenerateGraph_VerticesAndEdges_HasCorrectNumberOfVertices()
        {
            const int numberOfVertices = 5;
            const int numberOfEdges = 10;

            var erdosRenyiModel = new ErdosRenyiModel(numberOfVertices, numberOfEdges);
            var graph = erdosRenyiModel.GenerateGraph();

            Assert.AreEqual(numberOfVertices, graph.Keys.Count);
        }

        [TestMethod]
        public void GenerateGraph_VerticesAndEdgeProbability_HasCorrectNumberOfVertices()
        {
            const int numberOfVertices = 5;
            const double edgeProbability = 0.5;

            var erdosRenyiModel = new ErdosRenyiModel(numberOfVertices, edgeProbability);
            var graph = erdosRenyiModel.GenerateGraph();

            Assert.AreEqual(numberOfVertices, graph.Keys.Count);
        }
    }
}
