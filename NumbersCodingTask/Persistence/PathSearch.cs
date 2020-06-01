using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Utilities;

namespace NumbersCodingTask.Persistence
{
    public class PathSearch : IPathSearch
    {
        private readonly int[] _numbers;
        private readonly IMaybe<IPath> _foundPath;

        public PathSearch(int[] numbers, IMaybe<IPath> foundPath)
        {
            _numbers = numbers;
            _foundPath = foundPath;
        }

        public int[] Numbers()
        {
            return _numbers;
        }

        public IMaybe<IPath> FoundPath()
        {
            return _foundPath;
        }
    }
}
