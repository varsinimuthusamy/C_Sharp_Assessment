using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represnts Data Acquisition Module.
    /// </summary>
    internal class DataAcquisitionModule
    {
        private event EventHandler Refresh;
        /// <summary>
        /// Deserialize data.
        /// </summary>
        public void LoadJSON()
        {
            using (StreamReader reader = new StreamReader("AcquisitionData.txt"))
            {
                var data = reader.ReadToEnd();
                var result = JsonSerializer.Deserialize<List<AcquisitionData>>(data);
            }
        }

        /// <summary>
        /// Serialize data.
        /// </summary>
        /// <param name="acquisitionData"></param>
        public void SaveJSON(List<AcquisitionData> acquisitionData)
        {
            using (StreamWriter writer = new StreamWriter("AcquisitionData.txt"))
            {
                var result = JsonSerializer.Serialize(acquisitionData);
                writer.WriteLine(result);
            }
        }

        public void OnRefresh(EventArgs e)
        {
            Refresh.Invoke(this, e);
        }
    }
}
