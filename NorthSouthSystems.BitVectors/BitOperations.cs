#if NETSTANDARD2_0
namespace NorthSouthSystems.BitVectors;

/// <summary>
/// Polyfills for BitOperations that are available in .NET but not in .NET Framework (any version) or .NET Standard 2.0.
/// </summary>
public static class BitOperations
{
    /// <summary>
    /// Compute the number of leading bits set to 0 for an unsigned long value.
    /// </summary>
    /// <remarks>
    /// Originally found at <a href="https://andrewlock.net/counting-the-leading-zeroes-in-a-binary-number/">Andrew Lock's Blog</a>.
    /// </remarks>
    public static int LeadingZeroCount(ulong value)
    {
        // Smear
        value |= value >> 1;
        value |= value >> 2;
        value |= value >> 4;
        value |= value >> 8;
        value |= value >> 16;
        value |= value >> 32;

        // Count
        const int ulongSizeBits = sizeof(ulong) * 8;

        return ulongSizeBits - PopCount(value);
    }

    /// <summary>
    /// Compute the number of leading bits set to 0 for an unsigned integer value.
    /// </summary>
    /// <remarks>
    /// See LeadingZeroCount(ulong).
    /// </remarks>
    public static int LeadingZeroCount(uint value)
    {
        // Smear
        value |= value >> 1;
        value |= value >> 2;
        value |= value >> 4;
        value |= value >> 8;
        value |= value >> 16;

        // Count
        const int uintSizeBits = sizeof(uint) * 8;

        return uintSizeBits - PopCount(value);
    }

    /// <summary>
    /// Compute the number of trailing bits set to 0 for an unsigned long value.
    /// </summary>
    /// <remarks>
    /// See LeadingZeroCount(ulong).
    /// </remarks>
    public static int TrailingZeroCount(ulong value)
    {
        // Smear
        value |= value << 1;
        value |= value << 2;
        value |= value << 4;
        value |= value << 8;
        value |= value << 16;
        value |= value << 32;

        // Count
        const int ulongSizeBits = sizeof(ulong) * 8;

        return ulongSizeBits - PopCount(value);
    }

    /// <summary>
    /// Compute the number of trailing bits set to 0 for an unsigned integer value.
    /// </summary>
    /// <remarks>
    /// See LeadingZeroCount(ulong).
    /// </remarks>
    public static int TrailingZeroCount(uint value)
    {
        // Smear
        value |= value << 1;
        value |= value << 2;
        value |= value << 4;
        value |= value << 8;
        value |= value << 16;

        // Count
        const int uintSizeBits = sizeof(uint) * 8;

        return uintSizeBits - PopCount(value);
    }

    /// <summary>
    /// Compute the number of bits set to 1 for an unsigned long value.
    /// </summary>
    /// <remarks>
    /// Originally found at http://www.hackersdelight.org, which appears to have fallen into someone else's possesion.
    /// Found more recently at <a href="https://andrewlock.net/counting-the-leading-zeroes-in-a-binary-number/">Andrew Lock's Blog</a>
    /// when searching for a LeadingZeroCount polyfill.
    /// </remarks>
    public static int PopCount(ulong value)
    {
        value -= (value >> 1) & 0x5555_5555_5555_5555ul;
        value = ((value >> 2) & 0x3333_3333_3333_3333ul) + (value & 0x3333_3333_3333_3333ul);
        value = ((value >> 4) + value) & 0x0F0F_0F0F_0F0F_0F0Ful;
        value += value >> 8;
        value += value >> 16;
        value += value >> 32;
        return (int)(value & 0x0000_0000_0000_007Ful);
    }

    /// <summary>
    /// Compute the number of bits set to 1 for an unsigned integer value.
    /// </summary>
    /// <remarks>
    /// See PopCount(ulong).
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