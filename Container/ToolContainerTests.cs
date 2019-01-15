using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using ToolBox.Core.Exceptions;
using ToolBox.UnitTests.Moq;

namespace ToolBox.UnitTests
{
    [TestFixture]
    public class ToolContainerTests
    {
        private static readonly int _maxContainerCapacity = 100;
        private static readonly int _maxContainerWeight = 50;

        [TestCase(90, 30)]
        [TestCase(99, 45)]
        [TestCase(1, 4)]
        public void AddProperItem_ContainerEmpty_ItemAdded(double capacity, double weight)
        {
            var container = ToolContainerMoq.MockEmptyContainer(_maxContainerCapacity, _maxContainerWeight);
            var item = ToolMoq.MockTool(capacity, weight);

            container.AddItem(item);

            container.Items.Should().ContainSingle().And.Subject.First().Should().BeSameAs(item);
        }

        [TestCase(10, 100)]
        [TestCase(50, 100.01)]
        [TestCase(90, 356)]
        public void AddTooHeavyItem_ContainerEmpty_ContainerWeightOverloadExceptionThrown(double capacity, double weight)
        {
            var container = ToolContainerMoq.MockEmptyContainer(_maxContainerCapacity, _maxContainerWeight);
            var item = ToolMoq.MockTool(capacity, weight);

            Action itemAddition = () => container.AddItem(item);

            itemAddition.Should().Throw<ContainerWeightOverloadException>();
        }
    }
}
