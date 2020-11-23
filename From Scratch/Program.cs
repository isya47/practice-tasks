using System;
using System.Threading.Tasks;

namespace From_Scratch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new PostsService();
            var posts = await service.GetPosts();
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Title}");
            }
        }
        
        
    }
}