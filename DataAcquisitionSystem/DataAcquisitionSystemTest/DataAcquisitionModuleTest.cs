namespace DataAcquisitionSystemTest
{
    using DataAcquisitionSystem;
    public class DataAcquisitionModuleTest
    {
        [Fact]
        public void AddData_SetLimits_AddedToList()
        {
            DataAcquisitionModule module = new DataAcquisitionModule();
            module.LoadJSON();

            bool actualOutput = false;
            if (module.acquisitionDatas.Count > 0)
            {
                actualOutput = true;
            }

            Assert.True(actualOutput);
        }
    }
}
