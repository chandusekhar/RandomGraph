﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RandomGraph.Test
{
    [TestClass]
    public class DimacsGraphParserTest
    {
        private readonly List<string> _dummyFile = new List<string>() { "c FILE: myciel3bi.col",
                                                                        "c SOURCE: Michael Trick (trick@cmu.edu)",
                                                                        "c DESCRIPTION: Graph based on Mycielski transformation.",
                                                                        "c              Triangle free (clique number 2) but increasing",
                                                                        "c              coloring number",
                                                                        "p edge 11 20",
                                                                        "e 1 2",
                                                                        "e 1 4",
                                                                        "e 1 7",
                                                                        "e 1 9",
                                                                        "e 2 1",
                                                                        "e 2 3",
                                                                        "e 2 6",
                                                                        "e 2 8",
                                                                        "e 3 2",
                                                                        "e 3 5",
                                                                        "e 3 7",
                                                                        "e 3 10",
                                                                        "e 4 1",
                                                                        "e 4 5",
                                                                        "e 4 6",
                                                                        "e 4 10",
                                                                        "e 5 3",
                                                                        "e 5 4",
                                                                        "e 5 8",
                                                                        "e 5 9",
                                                                        "e 6 2",
                                                                        "e 6 4",
                                                                        "e 6 11",
                                                                        "e 7 1",
                                                                        "e 7 3",
                                                                        "e 7 11",
                                                                        "e 8 2",
                                                                        "e 8 5",
                                                                        "e 8 11",
                                                                        "e 9 1",
                                                                        "e 9 5",
                                                                        "e 9 11",
                                                                        "e 10 3",
                                                                        "e 10 4",
                                                                        "e 10 11",
                                                                        "e 11 6",
                                                                        "e 11 7",
                                                                        "e 11 8",
                                                                        "e 11 9",
                                                                        "e 11 10"};

        [TestMethod]
        public void DimacsGraphParser_GraphParsed_Success()
        {
            var loaderMock = new Mock<IDataLoader>();
            loaderMock.Setup(m => m.LoadData()).Returns(_dummyFile);

            var graphParser = new ParseDimacsGraph(loaderMock.Object);
            var graph = graphParser.ParseGraph();

            Assert.IsNotNull(graph);
            Assert.AreEqual(11, graph.Keys.Count);
            Assert.AreEqual(80, graph.SelectMany(v => v.Value).Count());
        }
    }
}
