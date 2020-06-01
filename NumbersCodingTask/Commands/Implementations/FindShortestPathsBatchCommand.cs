using System.Collections.Generic;
using System.Linq;
using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Persistence;
using NumbersCodingTask.Utilities;

namespace NumbersCodingTask.Commands.Implementations
{
    public class FindShortestPathsBatchCommand : IFindShortestPathsBatchCommand
    {
        private readonly IPathFinder _pathFinder;
        private readonly IStorage _storage;

        public FindShortestPathsBatchCommand(IPathFinder pathFinder, IStorage storage)
        {
            _pathFinder = pathFinder;
            _storage = storage;
        }

        public IEnumerable<IMaybe<IPath>> Execute(IEnumerable<int[]> batchOfNumbers)
        {
            return batchOfNumbers.Select(numbers =>
                _storage.ExistingOrNewlyCalculatedPath(numbers,
                    x => _pathFinder.ShortestPathFor(new GraphFromArray(x))
                )
            );
        }
    }
}
