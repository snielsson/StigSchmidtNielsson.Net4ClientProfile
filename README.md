# Stig Schmidt Nielsson's utilities for .Net projects based on .Net 4 client profile and above.
This solution is primarily intended for Stig Schmidt Nielsson's own projects and consulting work, but anyone is free to use this code under the terms of the MIT license.

The solution includes a number of projects, where each project is made available as a nuget package on nuget.org.

To avoid polluting intellisense with unused extension methods, extension methods are divided into many fine grained projects, where each project typically contains extensions methods for only a single type.

The following projects and nuget packages are available:

## StigSchmidtNielsson.Extensions.IEnumerable

General purpose extension methods on the IEnumerable and IEnumerable&lt;T&gt; interface. This includes Page for using LINQ to do efficient paging on IEnumerables without using skip and take.
