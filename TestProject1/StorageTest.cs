using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calc.Storage;

namespace TestProject1
{
    public class StorageTest
    {
        [Fact]
        public async Task SaveAsync_ShouldSaveStepsToFile()
        {
            var session = new Session();
            var steps = new List<Step> { new Step(1, 10), new Step(2, 20) };
            await session.SaveAsync(steps);

            var loadedSteps = await session.LoadAsync();
            Assert.Equal(steps.Count, loadedSteps.Count);
            Assert.Equal(steps[0].Res, loadedSteps[0].Res);
            Assert.Equal(steps[1].Res, loadedSteps[1].Res);
        }

        [Fact]
        public async Task LoadAsync_ShouldReturnEmptyListWhenFileNotExists()
        {
            var session = new Session();
            var steps = await session.LoadAsync();
            Assert.Empty(steps);
        }
    }
}
