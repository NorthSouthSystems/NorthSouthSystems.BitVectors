#if NETSTANDARD2_0
namespace NorthSouthSystems.BitVectors;

/// <summary>
/// Polyfills for BitOperations that are available in .NET but not in .NET Framework (any version) or .NET Standard 2.0.
/// </summary>
public static class BitOperations
{
    public static int PopCount(ulong value) =>
          PopCount((uint)((value >> 32) & uint.MaxValue))
        + PopCount((uint)(value & uint.MaxValue));

    /// <summary>
    /// Compute the number of bits set to 1 for an unsigned integer value.
    /// </summary>
    /// <remarks>
    /// Originally found at <a href="http://www.hackersdelight.org/HDcode/newCode/pop_arrayHS.c.txt">Hacker's Delight</a>.
    /// Found again at <a href="https://andrewlock.net/counting-the-leading-zeroes-in-a-binary-number/">Andrew Lock's Blog</a>
    /// when searching for a LeadingZeroCount polyfill.
    /// </remarks>
    public static int PopCount(uint value)
    {
        value -= (value >> 1) & 0x5555_5555u;
        value = ((value >> 2) & 0x3333_3333u) + (value & 0x3333_3333u);
        value = ((value >> 4) + value) & 0x0F0F_0F0Fu;
        value += value >> 8;
        value += value >> 16;
        return (int)(value & 0x0000_003Fu);
    }
}
#endif