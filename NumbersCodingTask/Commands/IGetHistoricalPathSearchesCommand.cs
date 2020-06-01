using System.Collections.Generic;
using NumbersCodingTask.Persistence;

namespace NumbersCodingTask.Commands
{
    public interface IGetHistoricalPathSearchesCommand
    {
        IEnumerable<IPathSearch> Execute();
    }
}