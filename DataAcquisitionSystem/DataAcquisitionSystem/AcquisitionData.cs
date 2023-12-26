namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents Acquisition Data.
    /// </summary>
    public class AcquisitionData : EventArgs
    {
        /// <summary>
        /// Initialises an instance of <see cref="AcquisitionData"/> class.
        /// </summary>
        public AcquisitionData()
        {
            HighLimit = 0;
            LowLimit = 0;
        }

        /// <summary>
        /// Initialises an instance of <see cref="AcquisitionData"/> class.
        /// </summary>
        /// <param name="data">Data.</param>
        public AcquisitionData(AcquisitionData data)
        {
            Parameter = data.Parameter;
            HighLimit = data.HighLimit;
            LowLimit = data.LowLimit;
        }

        /// <summary>
        /// Initialises an instance of <see cref="AcquisitionData"/> class.
        /// </summary>
        /// <param name="data">Data.</param>
        public AcquisitionData(Parameters parameter, int maxValue, int minValue)
        {
            Parameter = parameter;
            HighLimit = maxValue;
            LowLimit = minValue;
        }

        /// <summary>
        /// Represents Parameter.
        /// </summary>
        public Parameters Parameter { get; set; }

        /// <summary>
        /// Represnts higher limit of parameter.
        /// </summary>
        public int HighLimit { get; set; }

        /// <summary>
        /// Represnts lower limit of parameter.
        /// </summary>
        public int LowLimit { get; set; }
    }
}
