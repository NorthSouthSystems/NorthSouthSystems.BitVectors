﻿#if NETSTANDARD2_0
namespace NorthSouthSystems.BitVectors;

/// <summary>
/// Provides a method for computing the population (number of bits set to 1) of an
/// unsigned integer.
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
        word = word - ((word >> 1) & 0x55555555u);
        word = (word & 0x33333333u) + ((word >> 2) & 0x33333333u);
        word = (word + (word >> 4)) & 0x0F0F0F0Fu;
        word = word + (word >> 8);
        word = word + (word >> 16);
        return (int)(word & 0x0000003Fu);
    }
}
#endif