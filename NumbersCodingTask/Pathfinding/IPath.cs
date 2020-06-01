using System.Collections.Generic;

namespace NumbersCodingTask.Pathfinding
{
    public interface IPath
    {
        IEnumerable<IGraphNode> Nodes();
    }
}
