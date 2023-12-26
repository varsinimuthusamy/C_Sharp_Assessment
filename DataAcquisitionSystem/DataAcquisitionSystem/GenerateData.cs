using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataAcquisitionSystem
{
    using System.Timers;

    /// <summary>
    /// Generates data.
    /// </summary>
    public class GenerateData
    {
        private bool _flag = true;
        private ComplianceModule _module;
        private DataAcquisitionModule _dataAcquisitionModule;
        private Timer _atimer;

        /// <summary>
        /// Initializes an instance of <see cref="GenerateData"/> class.
        /// </summary>
        /// <param name="complianceModule"></param>
        /// <param name="dataAcquisitionModule"></param>
        public GenerateData(ComplianceModule complianceModule, DataAcquisitionModule dataAcquisitionModule)
        {
            _flag = false;
            _module = complianceModule;
            _dataAcquisitionModule = dataAcquisitionModule;
            _atimer = new Timer(_dataAcquisitionModule.Format.Rate * 1000);
            _atimer.AutoReset = true;
            _atimer.Enabled = true;
            _atimer.Elapsed += Timer_Elapsed;
            _atimer.Start();
        }

        /// <summary>
        /// Represents current value.
        /// </summary>
        /// <returns></returns>
        public int Current()
        {
            Random random = new Random();
            return random.Next(0,100);
        }

        /// <summary>
        /// Represents temperature value.
        /// </summary>
        /// <returns></returns>
        public int Temperature()
        {
            Random random = new Random();
            return random.Next(0,100);
        }

        /// <summary>
        /// Stop Timer.
        /// </summary>
        public void StopTimer()
        {
            _atimer.Stop();
        }

        /// <summary>
        /// Represents Timer event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (_flag)
            {
                _module.Parameter = Parameters.Temperature;
                _module.ParameterValue = Temperature();
                _flag = false;
            }
            else
            {
                _module.Parameter = Parameters.Current;
               _module.ParameterValue = Current();
            }

            _dataAcquisitionModule.OnRefresh();
        }
    }
}
