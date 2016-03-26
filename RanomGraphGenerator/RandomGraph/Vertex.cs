namespace RandomGraph
{
    public struct Vertex
    {
        /// <summary>
        /// Default value of the edge weight if it's not set.
        /// </summary>
        private const int DefaultWeight = 1;

        /// <summary>
        /// The vertex ID.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// The weight of the vertex.
        /// If not set defautl value is 1.
        /// </summary>
        public int Weight { get; private set; }

        /// <summary>
        /// Initialize vertex.
        /// </summary>
        /// <param name="id">The ID of the vertex.</param>
        /// <param name="weight">The weight of the vertex.</param>
        public Vertex(int id, int weight)
        {
            ID = id;
            Weight = weight;
        }

        /// <summary>
        /// Initialize vertex.
        /// Weight will be set by default to <see cref="DefaultWeight">1</see>.
        /// </summary>
        /// <param name="id">The ID of the vertex.</param>
        public Vertex(int id)
        {
            ID = id;
            Weight = DefaultWeight;
        }
    }
}
