using AElf.Sdk.CSharp.State;

namespace AElf.Contracts.ModularContract;

public class PausibleState : StructuredState
{
    public BoolState Paused { get; set; }
}