![SharperHacks logo](SHLLC-Logo.jpg)
# ExceptionsAndHandlers Library for .NET
## SharperHacks.CoreLibs.ExceptionsAndHandlers

Defines exception handling classes and methods.

Licensed under the Apache License, Version 2.0. See [LICENSE](LICENSE).

Contact: coders@sharperhacks.org

Nuget: https://www.nuget.org/packages/SharperHacks.CoreLibs.ExceptionsAndHandlers

### Targets
- net7.0
- net8.0

### Classes

#### ExceptionT
Generic exception, making it easy to throw more specific exceptions than with simple 
Exception. Use to the "warning CA2201: Exception type System.Exception is not sufficiently 
specific" warning.

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