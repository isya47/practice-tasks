using System.Dynamic;
using System.Threading.Tasks;

namespace PalceholderAPI
{
    
    public interface IPostsService
    {
        public Task <Post[]> GetPosts();
        public Task <Post[]> GetPost(int? id);
        public Task <Post[]> GetByQuery(string content);

    }
}