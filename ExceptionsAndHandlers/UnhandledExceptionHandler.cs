// Copyright and trademark notices at the end of this file.

using Microsoft.Extensions.Logging;

namespace SharperHacks.CoreLibs.ExceptionsAndHandlers;

// ToDo: Add thread/app scope or make this static and create a thread variant?

/// <summary>
/// Simple, disposable unhandled exception event handler.
/// </summary>
public sealed class UnhandledExceptionHandler : IDisposable
{
    private ILogger _log;

    private bool _disposedValue;

    private AppDomain _appDomain;
    private UnhandledExceptionEventHandler _unhandledExceptionEventHandler;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger">Required ILogger.</param>
    /// <exception cref="ArgumentNullException"/>
    public UnhandledExceptionHandler(ILogger logger)
    {
        _log = logger ?? throw new ArgumentNullException(nameof(logger));

        _unhandledExceptionEventHandler = new UnhandledExceptionEventHandler(ExceptionHandler);

        _appDomain = AppDomain.CurrentDomain;
        _appDomain.UnhandledException += _unhandledExceptionEventHandler;

#pragma warning disable CA1848 // Use the LoggerMessage delegates
        _log.LogInformation("ExceptionEventHandler successfully registered.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
    }

    /// <summary>
    /// Exception handler.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
    {       
        var exception = args.ExceptionObject as Exception;

#pragma warning disable CA1848 // Use the LoggerMessage delegates
        _log.LogCritical(exception, "Fatal error: Unhandled exception caught.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
    }

    #region IDisposable

    private void Dispose(bool disposing)
    {
        if (disposing && !_disposedValue)
        {
            _appDomain.UnhandledException -= _unhandledExceptionEventHandler;

#pragma warning disable CA1848 // Use the LoggerMessage delegates
            _log.LogInformation("ExceptionEventHandler successfully unregistered.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates

            _disposedValue = true;
        }
    }

    /// <inheritdoc cref="IDisposable.Dispose()"/>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Finalizer.
    /// </summary>
    ~UnhandledExceptionHandler() => Dispose(disposing: false);

    #endregion IDisposable
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
