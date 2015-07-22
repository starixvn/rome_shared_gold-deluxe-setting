namespace Fanex.GoldDeluxe.CoreSetting.Test.CommandResult
{
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using NUnit.Framework;

    [TestFixture]
    public class PTAndComCommandResultTest
    {
        [TestCase("1")]
        public void IsSuccessful_Code_ReturnTrue(string code)
        {
            var command = CreatePTAndComCommandResult();

            command.Code = code;

            Assert.IsFalse(command.IsSuccessful);
        }

        [TestCase("-1")]
        [TestCase("-100")]
        [TestCase("0")]
        public void IsSuccessful_Code_ReturnFalse(string code)
        {
            var command = CreatePTAndComCommandResult();

            command.Code = code;

            Assert.IsTrue(command.IsSuccessful);
        }

        private PTAndComCommandResult CreatePTAndComCommandResult()
        {
            return new PTAndComCommandResult();
        }
    }
}
