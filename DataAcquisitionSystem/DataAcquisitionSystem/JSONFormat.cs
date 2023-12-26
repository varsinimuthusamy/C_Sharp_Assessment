namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents JSON format.
    /// </summary>
    public class JSONFormat
    {
        /// <summary>
        /// Represents rate.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Represents Parameters.
        /// </summary>
        public List<AcquisitionData> Parameters { get; set; }
    }
}
