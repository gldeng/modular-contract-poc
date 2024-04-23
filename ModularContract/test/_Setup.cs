using AElf.Cryptography.ECDSA;
using AElf.Testing.TestBase;

namespace AElf.Contracts.ModularContract
{
    // The Module class load the context required for unit testing
    public class Module : ContractTestModule<ModularContract>
    {
        
    }
    
    // The TestBase class inherit ContractTestBase class, it defines Stub classes and gets instances required for unit testing
    public class TestBase : ContractTestBase<Module>
    {
        // The Stub class for unit testing
        internal readonly ModularContractContainer.ModularContractStub ModularContractStub;
        // A key pair that can be used to interact with the contract instance
        private ECKeyPair DefaultKeyPair => Accounts[0].KeyPair;

        public TestBase()
        {
            ModularContractStub = GetModularContractContractStub(DefaultKeyPair);
        }

        private ModularContractContainer.ModularContractStub GetModularContractContractStub(ECKeyPair senderKeyPair)
        {
            return GetTester<ModularContractContainer.ModularContractStub>(ContractAddress, senderKeyPair);
        }
    }
    
}