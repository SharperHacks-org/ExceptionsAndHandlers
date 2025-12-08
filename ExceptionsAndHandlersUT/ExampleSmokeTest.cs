// Copyright and trademark notices at the end of this file.

using SharperHacks.Diagnostics.OS;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace SharperHacks.CoreLibs.ExceptionsAndHandlersUT;

[TestClass]
[ExcludeFromCodeCoverage]
public class ExampleSmokeTest
{
    // ToDo: Decide if/how to support non-english languages.

    // This is captured output. If ExceptionsAndHandlers is modifed, it could
    // bleed through and break the example code. Visually inspect the bits for
    // correctness and paste the new output here.
    private const string _expectedResult =
@"Note that we are using console logging to show what would be logged.
The final unhandled exception is therefore logged to the console by the app,
followed by the runtime unhandled exception spew prior to terminate.

info: Program[0]
      ExceptionEventHandler successfully registered.
warn: Program[0]
      Exception handled.
      SharperHacks.CoreLibs.ExceptionsAndHandlers.Exception`1[Example.Class1]: Example.Class1.
         at Example.Class1.Throw() in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Class1.cs:line 9
         at Program.<Main>$(String[] args) in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Program.cs:line 26
warn: Program[0]
      Exception handled.
      SharperHacks.CoreLibs.ExceptionsAndHandlers.Exception`1[Example.Class1]: Example.Class1: Message one.
         at Example.Class1.Throw(String message) in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Class1.cs:line 11
         at Program.<Main>$(String[] args) in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Program.cs:line 35
fail: Program[0]
      Exception handled
      SharperHacks.CoreLibs.ExceptionsAndHandlers.Exception`1[Example.Class1]: Example.Class1: Caught exception.
       ---> SharperHacks.CoreLibs.ExceptionsAndHandlers.Exception`1[Example.Class2]: Example.Class2: Class two exception.
         at Example.Class2..ctor() in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Class2.cs:line 9
         at Example.Class1.ThrowWithClass2InnerException() in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Class1.cs:line 17
         --- End of inner exception stack trace ---
         at Example.Class1.ThrowWithClass2InnerException() in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Class1.cs:line 21
         at Program.<Main>$(String[] args) in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Program.cs:line 44
crit: Program[0]
      Fatal error: Unhandled exception caught.
      SharperHacks.CoreLibs.ExceptionsAndHandlers.Exception`1[Program]: Program: This exception is unhandled.
         at Program.<Main>$(String[] args) in {SHLLC/CoreLibs/ExceptionsAndHandlers}/ExceptionsAndHandlersExample/Program.cs:line 51
info: Program[0]
      ExceptionEventHandler successfully unregistered.";

    [TestMethod]
    public void RunMain()
    {
        var shellExec = new ShellExec("ExceptionsAndHandlersExample.exe", string.Empty);
        var exitCode = shellExec.RunSync();
        var captured = shellExec.Result;

        Console.WriteLine(captured);
        Console.WriteLine($"Exit code: 0x{exitCode:X} ({exitCode})");

        Assert.AreEqual(-532462766, exitCode);
        Assert.AreEqual(_expectedResult, captured.Trim());
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

