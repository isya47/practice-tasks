using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace PalceholderAPI
{
    public class PostsService : IPostsService
    {
        HttpClient client = new HttpClient();
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        
        public async Task<Post[]> GetPosts()
        {
            var response = await client.GetStringAsync(Url);
            var posts = JsonSerializer.Deserialize<Post[]>(response);
            return posts;
        }
        
        public async Task<Post[]> GetPost(int? id)
        {
            var response = await client.GetStringAsync(Url+$"{id}");
            var posts = JsonSerializer.Deserialize<Post[]>(response);
            return posts;
        }

        public async Task<Post[]> GetByQuery(string content)
        {
            var response = await client.GetStringAsync(Url);
            var posts = JsonSerializer.Deserialize<Post[]>(response);
            var result = posts.Where(p => Contains(p, content)).ToArray();
            return result;
        }

        public bool Contains(Post post, string query)
        {
            return post.Body.Contains(query) || post.Title.Contains(query);
            
        }
    }


}
    
    
    
