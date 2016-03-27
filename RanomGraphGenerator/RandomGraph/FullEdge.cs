namespace RandomGraph
{
    class FullEdge : Edge
    {
        /// <summary>
        /// The ID of the source vertex which has a connection (edge)
        /// to another vertex.
        /// </summary>
        public int SourceVertexID { get; private set; }

        /// <summary>
        /// Initialize full edge.
        /// </summary>
        /// <param name="sourceVertexID">The ID of the source vertex.</param>
        /// <param name="connectedVertexID">The ID of the connected vertex.</param>
        /// <param name="weight">The weight of the connection (edge).</param>
        public FullEdge(int sourceVertexID, int connectedVertexID, int weight) 
            : base(connectedVertexID, weight)
        {
            SourceVertexID = sourceVertexID;
        }

        /// <summary>
        /// Initialize full edge.
        /// Weight will be set to default value <see cref="Edge.DefaultWeight">1</see>./>
        /// </summary>
        /// <param name="sourceVertexID">The ID of the source vertex.</param>
        /// <param name="connectedVertexID">The ID of the connected vertex.</param>
        public FullEdge(int sourceVertexID, int connectedVertexID) 
            : base(connectedVertexID)
        {
            SourceVertexID = sourceVertexID;
        }
    }
}
