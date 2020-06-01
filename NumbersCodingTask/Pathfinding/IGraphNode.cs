using System;
using System.Collections.Generic;

namespace NumbersCodingTask.Pathfinding
{
    public interface IGraphNode : IEquatable<IGraphNode>
    {
        string Name();
        IEnumerable<IGraphNode> Neighbors();
    }
}
