using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Utilities;
using System;
using System.Collections.Generic;

namespace NumbersCodingTask.Persistence
{
    public interface IStorage
    {
        IMaybe<IPath> ExistingOrNewlyCalculatedPath(int[] numbers, Func<int[], IMaybe<IPath>> pathForNumbers);
        IEnumerable<IPathSearch> PathSearches();
    }
}