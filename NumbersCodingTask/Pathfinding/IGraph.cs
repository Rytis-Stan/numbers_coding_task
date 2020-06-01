using System.Collections.Generic;

namespace NumbersCodingTask.Pathfinding
{
    public interface IGraph
    {
        bool IsEmpty();
        IEnumerable<IGraphNode> Nodes();
        IGraphNode Start();
        IGraphNode Finish();
    }
}
