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
    public class DataAcquisitionModule
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
                using (StreamReader reader = new StreamReader("DataAcquisition.txt"))
                {
                    var data = reader.ReadToEnd();
                    var result = JsonSerializer.Deserialize<JSONFormat>(data);
                    foreach (var item in result.Parameters)
                    {
                        acquisitionDatas.Add(item);
                    }
                }
            }
            catch
            {
                throw;
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
