using System.Reflection;

namespace Wallets.Shared;

public static class AssemblyMarker
{
    private static readonly Lazy<Assembly> _currencyAssembly =
        new Lazy<Assembly>(() => typeof(AssemblyMarker).Assembly);

    public static Assembly ApplicationAssembly => _currencyAssembly.Value;
}

