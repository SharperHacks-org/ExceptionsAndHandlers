// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1848:Use the LoggerMessage delegates", Justification = "Low complexity required.")]
[assembly: SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = "Specificity not important here.")]
[assembly: SuppressMessage("Style", "IDE0160:Convert to block scoped namespace", Justification = "<Pending>", Scope = "namespace", Target = "~N:Example")]
