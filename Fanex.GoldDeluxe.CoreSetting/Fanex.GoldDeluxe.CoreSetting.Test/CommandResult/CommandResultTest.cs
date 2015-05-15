namespace Fanex.GoldDeluxe.CoreSetting.Test.CommandResult
{
    using NUnit.Framework;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.NAP.Framework.Data;

    [TestFixture]
    public class CommandResultTest
    {
        [TestCase("")]
        [TestCase("0")]
        public void IsSuccessful_Code_ReturnTrue(string code)
        {
            var command = CreateCommandResult();

            command.Code = code;

            Assert.IsTrue(command.IsSuccessful);
        }

        [TestCase("123")]
        [TestCase("abc")]
        public void IsSuccessful_Code_ReturnFalse(string code)
        {
            var command = CreateCommandResult();

            command.Code = code;

            Assert.IsFalse(command.IsSuccessful);
        }


        private CommandResult CreateCommandResult()
        {
            return new CommandResult();
        }
    }
}
