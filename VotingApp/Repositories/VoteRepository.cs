using VotingApp.Models;

namespace VotingApp.Repositories
{
    public class VoteRepository
    {
        private readonly List<Vote> _votes = new List<Vote>();

        public void AddVote(Vote vote)
        {
            _votes.Add(vote);
        }

        public int GetVoteCount(int categoryId)
        {
            return _votes.Count(v => v.CategoryId == categoryId);
        }

        public Dictionary<int, int> GetAllVoteCounts()
        {
            return _votes.GroupBy(v => v.CategoryId)
                         .ToDictionary(g => g.Key, g => g.Count());
        }

        public bool HasUserVoted(string username, int categoryId)
        {
            return _votes.Any(v => v.Username == username && v.CategoryId == categoryId);
        }
    }
}
