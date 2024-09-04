#if NETSTANDARD2_0
namespace NorthSouthSystems.BitVectors;

/// <summary>
/// Polyfills for BitOperations that are available in .NET but not in .NET Framework (any version) or .NET Standard 2.0.
/// </summary>
public static class BitOperations
{
    public static int PopCount(ulong word) =>
          PopCount((uint)((word >> 32) & uint.MaxValue))
        + PopCount((uint)(word & uint.MaxValue));

    /// <summary>
    /// Compute the number of bits set to 1 for an unsigned integer value.
    /// </summary>
    /// <remarks>
    /// Originally found at <a href="http://www.hackersdelight.org/HDcode/newCode/pop_arrayHS.c.txt">Hacker's Delight</a>.
    /// </remarks>
    public static int PopCount(uint word)
    {
        word -= (word >> 1) & 0x5555_5555u;
        word = (word & 0x3333_3333u) + ((word >> 2) & 0x3333_3333u);
        word = (word + (word >> 4)) & 0x0F0F_0F0Fu;
        word += word >> 8;
        word += word >> 16;
        return (int)(word & 0x0000_003Fu);
    }
}
#endif