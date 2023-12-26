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
        public List<AcquisitionData> acquisitionDatas;

        public delegate void DataAcquisitionEventHandler(object sender, DataAcquisitionEventArgs e);

        // Declare the event.
        public event DataAcquisitionEventHandler RefreshEvent;

        /// <summary>
        /// Initializes an intance of <see cref="DataAcquisitionModule"/> class.
        /// </summary>
        public DataAcquisitionModule() 
        {
           acquisitionDatas = new List<AcquisitionData>();
        }
        
        /// <summary>
        /// Deserialize data.
        /// </summary>
        public void LoadJSON()
        {
            try
            {
                using (StreamReader reader = new StreamReader("AcquisitionData.txt"))
                {
                    var data = reader.ReadToEnd();
                    acquisitionDatas = JsonSerializer.Deserialize<List<AcquisitionData>>(data);
                }
            }
            catch
            {
                throw;
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

        /// <summary>
        /// Fire the refresh event.
        /// </summary>
        public void OnRefresh()
        {
            RefreshEvent.Invoke(this, new DataAcquisitionEventArgs() { AcquisitionDatas = acquisitionDatas});
        }
    }
}
