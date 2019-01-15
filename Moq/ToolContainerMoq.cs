using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ToolBox.Core.Interfaces;

namespace ToolBox.UnitTests.Moq
{
    public static class ToolContainerMoq
    {
        public static IContainer MockEmptyContainer(double maxCapacity,double maxWeight)
        {
            var containerMoq = new Mock<IContainer>();
            containerMoq.Setup(x => x.ContainerMaxCapacity).Returns(maxCapacity);
            containerMoq.Setup(x => x.ContainerMaxWeight).Returns(maxWeight);

            return containerMoq.Object;
        }
    }
}
