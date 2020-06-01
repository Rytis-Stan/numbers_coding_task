using System.Collections.Generic;
using NumbersCodingTask.Persistence;

namespace NumbersCodingTask.Commands.Implementations
{
    public class GetHistoricalPathSearchesCommand : IGetHistoricalPathSearchesCommand
    {
        private readonly IStorage _storage;

        public GetHistoricalPathSearchesCommand(IStorage storage)
        {
            _storage = storage;
        }

        public IEnumerable<IPathSearch> Execute()
        {
            return _storage.PathSearches();
        }
    }
}
