namespace DataAcquisitionSystem
{
    public class ParametersList
    {
        /// <summary>
        /// Initializes an intance of <see cref="ParametersList"/> class.
        /// </summary>
        public ParametersList()
        {
            Parameters = new List<AcquisitionData>();
        }

        /// <summary>
        /// Represents Parameters.
        /// </summary>
        public List<AcquisitionData> Parameters { get; set; }
    }
}
