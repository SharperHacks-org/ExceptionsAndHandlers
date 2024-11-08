// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.ExceptionsAndHandlers;

/// <summary>
/// Generic exception, making it easy to throw more specific exceptions than with simple 
/// Exception.Use to avoid the "warning CA2201: Exception type System.Exception is not 
/// sufficiently specific" warning.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Exception<T> : Exception
{
    /// <inheritdoc cref="Exception.Exception()"/>
    public Exception() : base(BuildMessage()) { }

    /// <inheritdoc cref="Exception.Exception(string)"/>
    public Exception(string message) : base(BuildMessage(message)) { }

    /// <inheritdoc cref="Exception.Exception(string, Exception)"/>
    public Exception(string message, Exception innerException)
        : base(BuildMessage(message), innerException) { }

    /// <summary>
    /// Produces a string that contains full name of type of T.
    /// </summary>
    /// <param name="message"></param>
    /// <returns>string</returns>
    protected static string BuildMessage(string? message = null)
    {
        var nameOfT = typeof(T).FullName
            ?? $"SharperHacks.CoreLibs.{nameof(ExceptionsAndHandlers)}.Exception<unknown>";

        return message is null
            ? $"{nameOfT}."
            : $"{nameOfT}: {message}";
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
