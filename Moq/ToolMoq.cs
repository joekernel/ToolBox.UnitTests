using Moq;
using ToolBox.Core.Interfaces;

namespace ToolBox.UnitTests.Moq
{
    public static class ToolMoq
    {
        public static ITool MockTool(double capacity, double weight)
        {
            var toolMoq = new Mock<ITool>();
            toolMoq.Setup(q => q.Capacity).Returns(capacity);
            toolMoq.Setup(q => q.Weight).Returns(weight);

            return toolMoq.Object;
        }
    }
}
