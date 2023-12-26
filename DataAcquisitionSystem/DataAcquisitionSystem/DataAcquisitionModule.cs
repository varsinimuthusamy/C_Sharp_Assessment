using Newtonsoft.Json;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represnts Data Acquisition Module.
    /// </summary>
    public class DataAcquisitionModule
    {
        /// <summary>
        /// Represents format.
        /// </summary>
        public JSONFormat Format { get; set; }

        /// <summary>
        /// Represents list of acquisitionDatas.
        /// </summary>
        public List<AcquisitionData> acquisitionDatas;

        /// <summary>
        /// Represents delegate.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
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
                using (StreamReader reader = new StreamReader("DataAcquisition.json"))
                {
                    var data = reader.ReadToEnd();
                    Format = JsonConvert.DeserializeObject<JSONFormat>(data);
                    foreach (var item in Format.Parameters)
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
        /// Save JSON.
        /// </summary>
        public void SaveJSON(AcquisitionData acquisitionData)
        {
            using (StreamWriter writer = new StreamWriter("DataAcquisition.json"))
            {
                foreach (var item in acquisitionDatas)
                {
                    if (item.Parameter == acquisitionData.Parameter)
                    {
                        item.Parameter = acquisitionData.Parameter;
                        item.HighLimit = acquisitionData.HighLimit;
                        item.LowLimit = acquisitionData.LowLimit;
                    }
                }
                Format.Parameters = acquisitionDatas;
                var result = JsonConvert.SerializeObject(Format);
                writer.Write(result);
            }
        }

        /// <summary>
        /// Fire the refresh event.
        /// </summary>
        public void OnRefresh()
        {
            RefreshEvent.Invoke(this, new DataAcquisitionEventArgs() { AcquisitionDatas = acquisitionDatas });
        }
    }
}
