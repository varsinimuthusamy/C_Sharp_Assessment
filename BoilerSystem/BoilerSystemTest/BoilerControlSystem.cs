using BoilerSystem;
namespace BoilerSystemTest
{
    public class BoilerControlSystem
    {
        [Fact]
        public void PrepurgeCycle_Addboiler_AddedtoBoilers()
        {
            BoilerOperation boilerOperation = new BoilerOperation();
            boilerOperation.PrePurgeCycle();
            var ActualOutput = boilerOperation.GetAllBoilers();
            Assert.Equal(1, ActualOutput.Count);
        }

        [Fact]
        public void IgnitionPhase_Addboiler_AddedtoBoilers()
        {
            BoilerOperation boilerOperation = new BoilerOperation();
            boilerOperation.IgnitionPhase();
            var ActualOutput = boilerOperation.GetAllBoilers();
            Assert.Equal(1, ActualOutput.Count);
        }

        [Fact]
        public void OperationalCycle_Addboiler_AddedtoBoilers()
        {
            BoilerOperation boilerOperation = new BoilerOperation();

            boilerOperation.OperationalCycle();
            var ActualOutput = boilerOperation.GetAllBoilers();

            Assert.Equal(1, ActualOutput.Count);
        }
    }
}