/// Failsafe for dotnet. Dotnet throws when it tries to run tests for for a "test project" 
/// that doesn't have tests.
using Xunit;

namespace UnitTests.xUnit
{

    public class Dotnet_Failsafe
    {
        [Fact]
        public void Failsafe()
        {

        }
    }
}
