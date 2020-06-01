using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Utilities;

namespace NumbersCodingTask.Persistence
{
    public interface IPathSearch
    {
        int[] Numbers();
        IMaybe<IPath> FoundPath();
    }
}
