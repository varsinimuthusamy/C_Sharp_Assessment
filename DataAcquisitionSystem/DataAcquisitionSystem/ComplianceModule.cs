using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents compliance module.
    /// </summary>
    internal class ComplianceModule
    {
        /// <summary>
        /// Represents list of AcquisitionData.
        /// </summary>
        private readonly List<AcquisitionData> _acquisitionDatas;

        /// <summary>
        /// Represents AcquisitionData.
        /// </summary>
        private readonly AcquisitionData _acquisitionData;

        /// <summary>
        /// Initializes an instance of <see cref="ComplianceModule"/> class.
        /// </summary>
        public ComplianceModule()
        {
            _acquisitionData = new AcquisitionData();
            _acquisitionDatas = new List<AcquisitionData>();
        }

        /// <summary>
        /// Sets limits for parameter.
        /// </summary>
        /// <param name="parameter">Paramter.</param>
        /// <param name="max">Max value.</param>
        /// <param name="min">Min value.</param>
        public void SetLimits(Parameters parameter, int max, int min)
        {
            _acquisitionData.Parameter = parameter;
            _acquisitionData.HighLimit = max;
            _acquisitionData.LowLimit = min;
            _acquisitionDatas.Add(_acquisitionData);
        }

        /// <summary>
        /// Checks valid limits.
        /// </summary>
        /// <param name="acquisitionDatasfromJSON">acquisitionDatasfromJSON</param>
        public void CheckValidLimits(object sender , DataAcquisitionEventArgs e )
        {
            List<AcquisitionData> acquisitionDatasfromJSON = e.AcquisitionDatas;
            LoggingSystem loggingSystem = new LoggingSystem();
            foreach (var acquisitionData in acquisitionDatasfromJSON)
            {
                foreach(var acquisitionDatafromUser in _acquisitionDatas)
                {
                    if(acquisitionDatafromUser.Parameter == acquisitionData.Parameter)
                    {
                        if (acquisitionDatafromUser.HighLimit > acquisitionData.HighLimit && acquisitionDatafromUser.LowLimit < acquisitionData.LowLimit)
                        {
                            loggingSystem.SaveToFile($"parameter : {acquisitionData.Parameter} HighLimit : {acquisitionData.HighLimit} LowLimit : {acquisitionData.LowLimit}");
                        }
                        else
                        {
                            loggingSystem.SaveToFile($"parameter : {acquisitionData.Parameter} exceeds limts");
                        }
                    }
                }
            }
            
            
        }
    }
}
