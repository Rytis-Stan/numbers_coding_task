using System.Linq;
using NumbersCodingTask.Pathfinding;

namespace NumbersCodingTask.Tests.Pathfinding
{
    public class PathVisualization
    {
        private readonly IPath _path;

        public PathVisualization(IPath path)
        {
            _path = path;
        }

        public override string ToString()
        {
            return string.Join(" -> ", _path.Nodes().Select(node => node.Name()));
        }
    }
}
