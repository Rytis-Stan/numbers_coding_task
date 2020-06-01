using NumbersCodingTask.Pathfinding;
using NUnit.Framework;

namespace NumbersCodingTask.Tests.Pathfinding
{
    [TestFixture]
    public class PathFinderTests
    {
        [TestCase(new[] { 0 }, "[0]")]
        [TestCase(new[] { 1, 0 }, "[0] -> [1]")]
        [TestCase(new[] { 1, 1, 0 }, "[0] -> [1] -> [2]")]
        [TestCase(new[] { 2, 0, 0 }, "[0] -> [2]")]
        [TestCase(new[] { 2, 0, 1, 0 }, "[0] -> [2] -> [3]")]
        [TestCase(new[] { 2, 2, 1, 0 }, "[0] -> [1] -> [3]")]
        [TestCase(new[] { 2, -2, 1, 0 }, "[0] -> [2] -> [3]")]
        [TestCase(new[] { 1, 2, -2, 1, 0 }, "[0] -> [1] -> [3] -> [4]")]
        [TestCase(new[] { 3, -1, -2, 1, 0 }, "[0] -> [3] -> [4]")]
        [TestCase(new[] { 1, 2, 0, 3, 0, 2, 0 }, "[0] -> [1] -> [3] -> [6]")] // Winnable example from task specification
        public void FindsShortestPathIsWhenAtLeastOnePathExists(int[] numbers, string expectedPath)
        {
            Assert.That(
                new PathVisualization(new PathFinder().ShortestPathFor(new GraphFromArray(numbers)).Value()).ToString(),
                Is.EqualTo(expectedPath)
            );
        }

        [TestCase(new int[0])]
        [TestCase(new[] { 0, 0 })]
        [TestCase(new[] { 0, 1 })]
        [TestCase(new[] { 1, 0, 1 })]
        [TestCase(new[] { 2, 0, 0, 1 })]
        [TestCase(new[] { 2, 0, 0, 1, 1 })]
        [TestCase(new[] { 1, 0, 1, 1, 1 })]
        [TestCase(new[] { 1, 0, 9, 1, 1 })]
        [TestCase(new[] { -1, 1 })]
        [TestCase(new[] { 1, -1, 1 })]
        [TestCase(new[] { 1, 2, 0, 1, 0, 2, 0 })] // Non-winnable example from task specification
        [TestCase(new[] { 1, 2, 0, -1, 0, 2, 0 })] // Non-winnable example from task specification
        [TestCase(new[] { 1, 2, 1, -1, 0, 2, 0 })] // Non-winnable example from task specification
        public void DoesNotFindShortestPathWhenNoPathsExist(int[] numbers)
        {
            Assert.That(
                new PathFinder().ShortestPathFor(new GraphFromArray(numbers)).HasValue(),
                Is.False
            );
        }
    }
}
