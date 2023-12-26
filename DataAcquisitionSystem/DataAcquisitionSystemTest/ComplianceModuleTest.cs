namespace DataAcquisitionSystemTest
{
    using DataAcquisitionSystem;
    public class ComplianceModuleTest
    {
        [Fact]
        public void AddData_SetLimits_AddedToList()
        {
            ComplianceModule complianceModule = new ComplianceModule();
            complianceModule.SetLimits(Parameters.Current, 10, 100);

            var ActualOutput = complianceModule.GetAcquisitionDatas().Count;

            Assert.Equal(1, ActualOutput);
        }
    }
}