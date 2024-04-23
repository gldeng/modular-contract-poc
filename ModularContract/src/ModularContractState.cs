using AElf.Sdk.CSharp.State;

namespace AElf.Contracts.ModularContract
{
    // The state class is access the blockchain state
    public class ModularContractState : ContractState
    {
        // A state that holds string value
        public StringState Message { get; set; }
        public PausibleState PausibleState { get; set; }
    }
}