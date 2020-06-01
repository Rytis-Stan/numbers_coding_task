using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Persistence;
using NumbersCodingTask.Utilities;

namespace NumbersCodingTask.Commands.Implementations
{
    public class FindShortestPathCommand : IFindShortestPathCommand
    {
        private readonly IPathFinder _pathFinder;
        private readonly IStorage _storage;

        public FindShortestPathCommand(IPathFinder pathFinder, IStorage storage)
        {
            _pathFinder = pathFinder;
            _storage = storage;
        }

        public IMaybe<IPath> Execute(int[] numbers)
        {
            return _storage.ExistingOrNewlyCalculatedPath(numbers,
                x => _pathFinder.ShortestPathFor(new GraphFromArray(x))
            );
        }
    }

}
