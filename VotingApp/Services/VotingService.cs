using VotingApp.Models;
using VotingApp.Repositories;

namespace VotingApp.Services
{
    public class VotingService
    {
        private readonly VoteRepository _voteRepository;
        private readonly CategoryRepository _categoryRepository;

        public VotingService(VoteRepository voteRepository, CategoryRepository categoryRepository)
        {
            _voteRepository = voteRepository;
            _categoryRepository = categoryRepository;
        }

        public bool Vote(string username, int categoryId)
        {
            if (!_categoryRepository.GetAllCategories().Any(c => c.Id == categoryId))
            {
                return false;
            }

            if (_voteRepository.HasUserVoted(username, categoryId))
            {
                return false;
            }

            _voteRepository.AddVote(new Vote(username, categoryId));
            return true;
        }

        public Dictionary<string, (int count, double percentage)> GetResults()
        {
            var voteCounts = _voteRepository.GetAllVoteCounts();
            int totalVotes = voteCounts.Values.Sum();
            var categories = _categoryRepository.GetAllCategories();

            return categories.ToDictionary(
                category => category.Name,
                category =>
                {
                    int count = voteCounts.ContainsKey(category.Id) ? voteCounts[category.Id] : 0;
                    double percentage = totalVotes > 0 ? (count / (double)totalVotes) * 100 : 0;
                    return (count, percentage);
                }
            );
        }
    }
}
