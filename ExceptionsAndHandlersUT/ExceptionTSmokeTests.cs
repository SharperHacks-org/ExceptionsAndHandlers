// Copyright and trademark notices at the end of this file.

using SharperHacks.CoreLibs.ExceptionsAndHandlers;

using System.Diagnostics.CodeAnalysis;

namespace ExceptionsAndHandlersUT;

[TestClass]
[ExcludeFromCodeCoverage]
public class ExceptionTSmokeTests
{
    const string _testMessage = "Test message";
    const string _innerExMessage = "Inner exception message";

    private void Validate(
        Exception ex, 
        string? message = null, 
        string? innerMessage = null)
    {
        var assemblyUnderTestName = $"SharperHacks.CoreLibs.{nameof(SharperHacks.CoreLibs.ExceptionsAndHandlers)}";
        var toStringResult = ex.ToString();
        Assert.IsTrue(toStringResult.StartsWith(assemblyUnderTestName));
        Assert.IsTrue(toStringResult.Contains(nameof(ExceptionTSmokeTests)));

        if (message is not null)
        {
            Assert.IsTrue(toStringResult.Contains(message));
        }
        else
        {
            Assert.IsTrue(toStringResult.EndsWith($"{nameof(ExceptionsAndHandlersUT)}.{nameof(ExceptionTSmokeTests)}."));
        }

        if (innerMessage is not null)
        {
            Assert.IsTrue(toStringResult.Contains(innerMessage));
        }
    }

    [TestMethod]
    public void DefaultConstructor()
    {
        var exception = new Exception<ExceptionTSmokeTests>();

        Console.WriteLine(exception);

        Validate(exception);
    }

    [TestMethod]
    public void MessageConstructor()
    {
        var exception = new Exception<ExceptionTSmokeTests>(_testMessage);
        
        Console.WriteLine(exception);

        Validate(exception, _testMessage);
    }

    [TestMethod]
    public void MessageInnerExceptionConstructor()
    {
        var innerException = new ArgumentException(_innerExMessage);
        var exception = new Exception<ExceptionTSmokeTests>(_testMessage, innerException);

        Console.WriteLine(exception);

        Validate(exception, _testMessage);
        Assert.IsTrue(exception.InnerException == innerException);
    }
}

// Copyright Joseph W Donahue and Sharper Hacks LLC (US-WA)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// SharperHacks is a trademark of Sharper Hacks LLC (US-Wa), and may not be
// applied to distributions of derivative works, without the express written
// permission of a registered officer of Sharper Hacks LLC (US-WA).
