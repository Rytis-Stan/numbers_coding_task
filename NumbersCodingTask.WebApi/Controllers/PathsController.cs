using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NumbersCodingTask.Commands;
using NumbersCodingTask.Pathfinding;
using NumbersCodingTask.Persistence;
using NumbersCodingTask.Utilities;

namespace NumbersCodingTask.WebApi.Controllers
{
    // TODO: add proper controller action argument and, especially result types.
    // Commands should deal with only business logic oriented data types.
    // Anything needed for HTTP transportation needs to be done at the controller level (for example,
    // command results should be converted to result DTOs).
    [Route("[controller]")]
    public class PathsController : ControllerBase
    {
        private readonly IFindShortestPathCommand _findShortestPathCommand;
        private readonly IFindShortestPathsBatchCommand _findShortestPathsBatchCommand;
        private readonly IGetHistoricalPathSearchesCommand _getHistoricalPathSearchesCommand;

        // TODO: inject commands, which area meant to act as reusable business logic actions, which are independent of HTTP and any UI mechanisms.
        public PathsController(
            IFindShortestPathCommand findShortestPathCommand,
            IFindShortestPathsBatchCommand findShortestPathsBatchCommand,
            IGetHistoricalPathSearchesCommand historicalPathSearchesCommand)
        {
            _findShortestPathCommand = findShortestPathCommand;
            _findShortestPathsBatchCommand = findShortestPathsBatchCommand;
            _getHistoricalPathSearchesCommand = historicalPathSearchesCommand;
        }

        [HttpPost]
        public IMaybe<IPath> Post([FromBody] int[] numbers)
        {
            return _findShortestPathCommand.Execute(numbers);
        }

        [HttpPost]
        [Route("/batch")]
        public IEnumerable<IMaybe<IPath>> Post([FromBody] IEnumerable<int[]> batchOfNumbers)
        {
            return _findShortestPathsBatchCommand.Execute(batchOfNumbers);
        }

        [HttpGet]
        [Route("/history")]
        public IEnumerable<IPathSearch> GetPathSearchHistory()
        {
           return _getHistoricalPathSearchesCommand.Execute();
        }
    }
}
