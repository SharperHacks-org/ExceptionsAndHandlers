![SharperHacks logo](https://raw.githubusercontent.com/SharperHacks-org/Assets/main/Images/SHLLC-Logo.png)

# ExceptionsAndHandlers Library for .NET
## SharperHacks.CoreLibs.ExceptionsAndHandlers

Defines exception handling classes and methods.

Licensed under the Apache License, Version 2.0. See [LICENSE](LICENSE).

Contact: coders@sharperhacks.org

Nuget: https://www.nuget.org/packages/SharperHacks.CoreLibs.ExceptionsAndHandlers

### Targets
- net8.0
- net9.0
- net10.0

### Classes

#### ExceptionT
Generic exception, making it easy to throw more specific exceptions than with simple 
Exception. Use to avoid the "warning CA2201: Exception type System.Exception is not 
sufficiently specific" warning.

Example:
```
class X 
{
    void DoSomething()
    {
       ...
       throw Exception<X>("X won't fit in a Z shaped opening.");
    }
}
```
#### UnhandledExceptionHandler
Simple, disposable unhandled exception event handler.