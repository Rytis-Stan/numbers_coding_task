using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersCodingTask.Persistence
{
    public class InMemoryStorage : IStorage
    {
        private readonly List<IPathSearch> _graphsWithPaths;

        public InMemoryStorage()
            : this(new List<IPathSearch>())
        {
        }

        private InMemoryStorage(List<IPathSearch> graphsWithPaths)
        {
            _graphsWithPaths = graphsWithPaths;
        }

        public IMaybe<IPath> ExistingOrNewlyCalculatedPath(int[] numbers, Func<int[], IMaybe<IPath>> pathForNumbers)
        {
            IPathSearch pathSearch = _graphsWithPaths.FirstOrDefault(x => x.Numbers().SequenceEqual(numbers));
            // TODO: get rid of "null" value usage
            if (pathSearch == null)
            {
                pathSearch = new PathSearch(numbers, pathForNumbers(numbers));
                _graphsWithPaths.Add(pathSearch);
            }
            return pathSearch.FoundPath();
        }

        public IEnumerable<IPathSearch> PathSearches()
        {
            return _graphsWithPaths;
        }
    }
}