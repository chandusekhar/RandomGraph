namespace RandomGraph
{
    public struct Edge
    {
        /// <summary>
        /// Default value of the edge weight if it's not set.
        /// </summary>
        private const int DefaultWeight = 1;

        /// <summary>
        /// The ID of the vertex which is connected.
        /// </summary>
        public int VertexID { get; set; }

        /// <summary>
        /// The weigh of the edge between vertiecs.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Initialize the edge as pair of connected vertex 
        /// and the weight of the edge between them.
        /// </summary>
        /// <param name="vertexID"></param>
        /// <param name="weight"></param>
        public Edge(int vertexID, int weight)
        {
            VertexID = vertexID;
            Weight = weight;
        }

        /// <summary>
        /// Initilize the edge as the ID of the connected vertex.
        /// The weight of the edge will be by default set to <see cref="DefaultWeight">1</see>./>.
        /// </summary>
        /// <param name="vertexID"></param>
        public Edge(int vertexID)
        {
            VertexID = vertexID;
            Weight = DefaultWeight;
        }
    }
}
