using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Utilities;

namespace NumbersCodingTask.Commands
{
    public interface IFindShortestPathCommand
    {
        IMaybe<IPath> Execute(int[] numbers);
    }
}
