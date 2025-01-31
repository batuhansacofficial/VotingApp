namespace VotingApp.Models
{
    public class Vote
    {
        public string Username { get; set; }
        public int CategoryId { get; set; }

        public Vote(string username, int categoryId)
        {
            Username = username;
            CategoryId = categoryId;
        }
    }
}