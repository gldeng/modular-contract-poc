using AElf.Sdk.CSharp;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.ModularContract
{
    // Contract class must inherit the base class generated from the proto file
    public class ModularContract : ModularContractContainer.ModularContractBase
    {
        public override Empty Pause(Empty input)
        {
            State.PausibleState.Paused.Value = true;
            return new Empty();
        }

        public override BoolValue IsPaused(Empty input)
        {
            return new BoolValue
            {
                Value = State.PausibleState.Paused.Value
            };
        }

        // A method that modifies the contract state
        public override Empty Update(StringValue input)
        {
            // Set the message value in the contract state
            State.Message.Value = input.Value;
            // Emit an event to notify listeners about something happened during the execution of this method
            Context.Fire(new UpdatedMessage
            {
                Value = input.Value
            });
            return new Empty();
        }

        // A method that read the contract state
        public override StringValue Read(Empty input)
        {
            // Retrieve the value from the state
            var value = State.Message.Value;
            // Wrap the value in the return type
            return new StringValue
            {
                Value = value
            };
        }
    }
}