using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace From_Scratch
{
    public class PostsService
    {
        HttpClient client = new HttpClient();
        private const string Url = "https://jsonplaceholder.typicode.com/posts";

        public async Task<Post[]> GetPosts()
        {
            var response = await client.GetStringAsync(Url);
            var posts = JsonSerializer.Deserialize<Post[]>(response);

            return posts;
        }
    }
}