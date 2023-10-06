﻿namespace FOSStrich.Search;

public class VectorTestsAndPopulation
{
    [Fact]
    public void AndPopulation() =>
        SafetyAndCompression.RunAll(vector1Compression =>
            SafetyAndCompression.RunAll(vector2Compression =>
            {
                int[] fillCounts = new[] { 0, 1, 5, 10, 20, 30, 40, 50, 100, 200, 300, 400, 450, 460, 470, 480, 490, 495, 499, 500 };

                foreach (int fillCount1 in fillCounts)
                {
                    foreach (int fillCount2 in fillCounts)
                    {
                        var vector1 = new Vector(vector1Compression.Compression);
                        int[] bitPositions1 = vector1.SetBitsRandom(499, fillCount1, true);
                        var vector2 = new Vector(vector2Compression.Compression);
                        int[] bitPositions2 = vector2.SetBitsRandom(499, fillCount2, true);

                        var bitPositions = new HashSet<int>(bitPositions1);
                        bitPositions.IntersectWith(bitPositions2);

                        int andPopulation = vector1.AndPopulation(vector2);

                        andPopulation.Should().Be(bitPositions.Count);
                    }
                }
            }));

    [Fact]
    public void Exceptions()
    {
        Action act;

        act = () =>
        {
            var vector = new Vector(VectorCompression.None);
            vector.AndPopulation(null);
        };
        act.Should().ThrowExactly<ArgumentNullException>(because: "AndPopulationArgumentNull");
    }
}