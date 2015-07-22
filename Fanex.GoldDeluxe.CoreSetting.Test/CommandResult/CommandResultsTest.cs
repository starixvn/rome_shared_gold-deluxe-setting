namespace Fanex.GoldDeluxe.CoreSetting.Test.CommandResult
{
    using System.Collections.Generic;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.NAP.Framework.Data;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CommandResultsTest
    {
        [Test]
        public void IsSuccessful_AllResultsIsSuccess_ReturnTrue()
        {
            var command = CreateCommandResults();
            var result1 = Substitute.For<ICommandResult>();
            var result2 = Substitute.For<ICommandResult>();

            result1.IsSuccessful.Returns(true);
            result2.IsSuccessful.Returns(true);
            command.Results = new List<ICommandResult> { result1, result2 };

            Assert.IsTrue(command.IsSuccessful);
        }

        [Test]
        public void IsSuccessful_HasOneResultIsFail_ReturnFalse()
        {
            var command = CreateCommandResults();
            var result1 = Substitute.For<ICommandResult>();
            var result2 = Substitute.For<ICommandResult>();

            result1.IsSuccessful.Returns(true);
            result2.IsSuccessful.Returns(false);
            command.Results = new List<ICommandResult> { result1, result2 };

            Assert.IsFalse(command.IsSuccessful);
        }

        private CommandResults CreateCommandResults()
        {
            return new CommandResults();
        }
    }
}
