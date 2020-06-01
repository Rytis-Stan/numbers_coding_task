using NumbersCodingTask.Utilities;

namespace NumbersCodingTask.Pathfinding
{
    public interface IPathFinder
    {
        IMaybe<IPath> ShortestPathFor(IGraph graph);
    }
}
