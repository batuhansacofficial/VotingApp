namespace VotingApp.Utils
{
    public static class DisplayUtils
    {
        public static void ShowVotingResults(Dictionary<string, (int count, double percentage)> results)
        {
            Console.WriteLine("\n--- Voting Results ---\n:");
            foreach (var result in results)
            {
                Console.WriteLine($"{result.Key}: {result.Value.count} votes ({result.Value.percentage:F2}%)");
            }
            Console.WriteLine();
        }
    }
}
