using DataLayer.MongoRepositories.Posts;
using Domain.Posts;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PostsWorker
    {
        private PostsRepository _postsRepository;
        public PostsWorker()
        {
            _postsRepository = new PostsRepository();
        }

        public async Task<Post> Create(Post post)
        {
            var createdPost = await _postsRepository.CreateAsync(post);
            return createdPost;
        }

        public Task<Post> GetPostById(ObjectId id)
        {
            var post = _postsRepository.GetById(id);
            return post;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            var posts = await _postsRepository.GetAll();
            return posts;
        }
    }
}
