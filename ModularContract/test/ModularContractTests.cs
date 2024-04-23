using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Xunit;

namespace AElf.Contracts.ModularContract
{
    // This class is unit test class, and it inherit TestBase. Write your unit test code inside it
    public class ModularContractTests : TestBase
    {
        [Fact]
        public async Task Update_ShouldUpdateMessageAndFireEvent()
        {
            // Arrange
            var inputValue = "Hello, World!";
            var input = new StringValue { Value = inputValue };

            // Act
            await ModularContractStub.Update.SendAsync(input);

            // Assert
            var updatedMessage = await ModularContractStub.Read.CallAsync(new Empty());
            updatedMessage.Value.ShouldBe(inputValue);
        }

        [Fact]
        public async Task TestPausible()
        {
            // Arrange
            var inputValue = "Hello, World!";
            var input = new StringValue { Value = inputValue };

            // Act
            await ModularContractStub.Pause.SendAsync(new Empty());

            // Assert
            var paused = await ModularContractStub.IsPaused.CallAsync(new Empty());
            paused.Value.ShouldBe(true);
        }
    }
}