// Copyright and trademark notices at the end of this file.

using Example;

using Microsoft.Extensions.Logging;

using SharperHacks.CoreLibs.ExceptionsAndHandlers;

using ILoggerFactory factory = LoggerFactory.Create(
    builder => builder
        .AddConsole()
        .AddDebug()
        .SetMinimumLevel(LogLevel.Trace)
);

var logger = factory.CreateLogger("Program");

Console.WriteLine("Note that we are using console logging to show what would be logged.\r\n"
    + "The final unhandled exception is therefore logged to the console by the app,\r\n"
    + "followed by the runtime unhandled exception spew prior to terminate.\r\n");

using var unhandledExceptionHandler = new UnhandledExceptionHandler(logger);

try
{
    Class1.Throw();
}
catch (Exception ex)
{
    logger.LogWarning(ex, "Exception handled.");
}

try
{
    Class1.Throw("Message one.");
}
catch (Exception ex)
{
    logger.LogWarning(ex, "Exception handled.");
}

try
{
    Class1.ThrowWithClass2InnerException();
}
catch (Exception ex)
{
    logger.LogError(ex, "Exception handled");
}

throw new Exception<Program>("This exception is unhandled.");

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
