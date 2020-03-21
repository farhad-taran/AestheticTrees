using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class Challenge
    {
        [Theory]
        [InlineData("4,5,6,5", 1)]
        [InlineData("7,5,5,1,2,1", 1)]
        [InlineData("1,2,3,4,5,6,7,8,9,10", 4)]
        [InlineData("1,2,3,4,5,6,7,8,9", 4)]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11", 5)]
        [InlineData("9,8,7,6,5,4,3,2,1,0", 4)]
        [InlineData("9,8,7,6,5,4,3,2,1", 4)]
        [InlineData("5,4,3,2,6", 1)]
        [InlineData("3,7,4,5", 0)]
        [InlineData("3,7,4,4", 1)]
        [InlineData("4,4,3,7", 1)]
        [InlineData("3,3,4,5", 1)]
        [InlineData("8,7,4,5", 1)]
        [InlineData("8,7,4,3", 1)]
        [InlineData("1,1,1,1,1,1", 3)]
        [InlineData("1,1,1,1,1", 2)]
        [InlineData("1,1,1,1", 2)]
        [InlineData("1,1,1", 1)]
        [InlineData("1,1", 1)]
        [InlineData("1", 0)]
        public void Test(string treeString, int expected)
        {
            var trees = treeString.Split(",").Select(int.Parse).ToArray();

            var result = Solution(trees);

            Assert.Equal(expected, result);
        }

        public static int Solution(int[] trees)
        {
            return DoRecursion(trees, 0, 2);
        }

        public static int DoRecursion(int[] trees, int iterations, int index)
        {
            if (trees.Any() == false || trees.Length == 0)
            {
                return 0;
            }

            if (trees.All(o => o == trees[0]))
            {
                return trees.Length / 2;
            }

            if (index >= trees.Length)
            {
                return iterations;
            }

            var previousToPrevious = trees[index - 2];
            var previous = trees[index - 1];
            var current = trees[index];
            var next = index + 1 > trees.Length - 1 ? current > 0 ? current - 1 : current + 1 : trees[index + 1];

            var nextIndex = index + 2;

            if (previousToPrevious > previous && previous < current && current > next)
            {
                return DoRecursion(trees, iterations, nextIndex);
            }

            if (previousToPrevious < previous && previous > current && current < next)
            {
                return DoRecursion(trees, iterations, nextIndex);
            }

            iterations = iterations + 1;

            return DoRecursion(trees, iterations, nextIndex);
        }
    }
}