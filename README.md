Hi! When I upgraded Microsoft.CodeAnalysis.CSharp from v1.1.0 to v1.1.1, I noticed a 5x slowdown.

To show what's going on, I've created a demo solution that you can download from this  repository.

On my machine, UsingCodeAnalysis110 takes approximately 0.25 seconds to complete whereas UsingCodeAnalysis111 takes 1.6 seconds.

Any help in this regard would be greatly appreciated....
