﻿// Copyright and trademark notices at the end of this file.

using SharperHacks.CoreLibs.ExceptionsAndHandlers;

namespace Example;

internal sealed class Class1
{
    internal static void Throw() => throw new Exception<Class1>();

    internal static void Throw(string message) => throw new Exception<Class1>(message);

    internal static void ThrowWithClass2InnerException()
    {
        try
        {
            var c2 = new Class2();
        }
        catch (Exception ex)
        {
            throw new Exception<Class1>("Caught exception.", ex);
        }
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

