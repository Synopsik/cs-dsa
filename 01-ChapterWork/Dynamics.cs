namespace Chapter1;

// ------------------------------------------------------------------------------------------------ //
//                                         Dynamics                                                 //
// ------------------------------------------------------------------------------------------------ //
public class Dynamics
{
    public async Task DynamicsAsync()
    {
        dynamic posts = await GetPostsAsync();
        foreach (dynamic post in posts)
        {
            string title = post.title;
            string body = post.body;
            Console.WriteLine($"Title: {title}\n" +
                              $"Body:  {body}\n");
        }
    }

    Task<dynamic> GetPostsAsync()
    {
        var libraryTitles = new[]
        {
            new { title = "Strange Stories", body = "A collection of strange stories" },
            new { title = "Academic Intrests", body = "A collection a noteworthy academic novels" }
        };
        return Task.FromResult<dynamic>(libraryTitles);
    }
}