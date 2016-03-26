using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RandomGraph
{
    public class ErdosRenyiModel
    {
        private readonly int _numberOfVertices;
        private readonly int? _numberOfEdges;
        private readonly double? _edgeProbability;
        private readonly Random _rnd;

        /// <summary>
        /// The Erdős–Rényi (or Edgar Gilbert) model for generating random grphs.
        /// In the G(V, p) model, a graph is constructed by connecting nodes randomly. 
        /// Each edge is included in the graph with probability p independent from every other edge.
        /// </summary>
        /// <param name="numberOfVertices">The number of vertices.</param>
        /// <param name="edgeProbability">The probability by wich an edge is included in the graph.</param>
        public ErdosRenyiModel(int numberOfVertices, double edgeProbability) : this()
        {
            _numberOfVertices = numberOfVertices;
            _edgeProbability = edgeProbability;
        }

        /// <summary>
        /// The Erdős–Rényi (or  Edgar Gilbert) model for generating random grphs.
        /// In the G(V, E) model, a graph is chosen uniformly at random from 
        /// the collection of all graphs which have V nodes and E edges.
        /// </summary>
        /// <param name="numberOfVertices">The number of vertices.</param>
        /// <param name="numberOfEdges">The number od edges.</param>
        public ErdosRenyiModel(int numberOfVertices, int numberOfEdges) : this()
        {
            _numberOfVertices = numberOfVertices;
            _numberOfEdges = numberOfEdges;
        }

        private ErdosRenyiModel()
        {
            _rnd = new Random(Environment.TickCount);
        }

        public Dictionary<Vertex, List<Edge>> GenerateGraph()
        {
            Dictionary<Vertex, List<Edge>> graph;

            if (_edgeProbability == null)
            {
                graph = GetGraphByVertexAndEdges();
            }
            else
            {
                graph = GetGraphByVerticesAndProbability();
            }

            return graph;
        }

        private Dictionary<Vertex, List<Edge>> GetGraphByVerticesAndProbability()
        {
            var graph = new Dictionary<Vertex, List<Edge>>();

            for (int i = 0; i < _numberOfVertices; i++)
            {
                var vertex = new Vertex(i);
                var edges = new List<Edge>();
                graph.Add(vertex, edges);
                for (int j = 0; j < i; j++)
                {
                    if (_rnd.NextDouble() < _edgeProbability)
                    {
                        edges.Add(new Edge(j));
                    }
                }
            }

            return graph;
        }

        private Dictionary<Vertex, List<Edge>> GetGraphByVertexAndEdges()
        {
            var graph = new Dictionary<Vertex, List<Edge>>();

            Debug.Assert(_numberOfEdges != null, "_numberOfEdges != null");
            var allPossibleEdges = new List<FullEdge>(_numberOfEdges.Value);

            for (int i = 0; i < _numberOfVertices; i++)
            {
                graph.Add(new Vertex(i), new List<Edge>());
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    var possibleEdge = new FullEdge(i, j);
                    allPossibleEdges.Add(possibleEdge);
                }
            }

            var currentVertex = 0;
            var edges = graph.Single(k => k.Key.ID == currentVertex).Value;
            foreach (var possibleEdge in allPossibleEdges.Shuffle(_rnd).Take(_numberOfEdges.Value).OrderBy(v => v.SourceVertexID))
            {
                if (possibleEdge.SourceVertexID != currentVertex)
                {
                    currentVertex = possibleEdge.SourceVertexID;
                    edges = graph.Single(k => k.Key.ID == possibleEdge.SourceVertexID).Value;
                }
                edges.Add(possibleEdge);
            }

            return graph;
        }
    }
}
