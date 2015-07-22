namespace Fanex.GoldDeluxe.CoreSetting.Test.CommandResult
{
    using System.Collections.Generic;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class MultipleCommandResultsTest
    {
        [Test]
        public void IsSuccessful_AllCommandResultsListIsSuccess_ReturnTrue()
        {
            var command = CreateMultipleCommandResults();
            var result1 = Substitute.For<ICommandResults>();
            var result2 = Substitute.For<ICommandResults>();

            result1.IsSuccessful.Returns(true);
            result2.IsSuccessful.Returns(true);
            command.CommandResultsList = new List<ICommandResults> { result1, result2 };

            Assert.IsTrue(command.IsSuccessful);
        }

        [Test]
        public void IsSuccessful_HasOneCommandResultsListIsFail_ReturnFalse()
        {
            var command = CreateMultipleCommandResults();
            var result1 = Substitute.For<ICommandResults>();
            var result2 = Substitute.For<ICommandResults>();

            result1.IsSuccessful.Returns(true);
            result2.IsSuccessful.Returns(false);
            command.CommandResultsList = new List<ICommandResults> { result1, result2 };

            Assert.IsFalse(command.IsSuccessful);
        }

        private MultipleCommandResults CreateMultipleCommandResults()
        {
            return new MultipleCommandResults();
        }
    }
}
