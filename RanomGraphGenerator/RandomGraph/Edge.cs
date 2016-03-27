namespace RandomGraph
{
    public class Edge
    {
        /// <summary>
        /// Default value of the edge weight if it's not set.
        /// </summary>
        private const int DefaultWeight = 1;

        /// <summary>
        /// The ID of the vertex which is connected.
        /// </summary>
        public int VertexID { get; private set; }

        /// <summary>
        /// The weigh of the edge between vertiecs.
        /// </summary>
        public int Weight { get; private set; }

        /// <summary>
        /// Initialize the edge as pair of connected vertex 
        /// and the weight of the edge between them.
        /// </summary>
        /// <param name="connectedVertexID">The ID of the connected vertex.</param>
        /// <param name="weight">The weight og the edge.</param>
        public Edge(int connectedVertexID, int weight)
        {
            VertexID = connectedVertexID;
            Weight = weight;
        }

        /// <summary>
        /// Initilize the edge as the ID of the connected vertex.
        /// The weight of the edge will be by default set to <see cref="DefaultWeight">1</see>./>.
        /// </summary>
        /// <param name="connectedVertexID">The ID of the connected vertex.</param>
        public Edge(int connectedVertexID)
        {
            VertexID = connectedVertexID;
            Weight = DefaultWeight;
        }
    }
}
