using System.Collections.Generic;
using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Utilities;

namespace NumbersCodingTask.Commands
{
    public interface IFindShortestPathsBatchCommand
    {
        IEnumerable<IMaybe<IPath>> Execute(IEnumerable<int[]> batchOfNumbers);
    }
}
