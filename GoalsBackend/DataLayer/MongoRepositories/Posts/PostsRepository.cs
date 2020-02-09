using Domain.Constants;
using Domain.Posts;

namespace DataLayer.MongoRepositories.Posts
{
    //TO DO
    public class PostsRepository : MongoBaseRepository<Post>
    {
        public PostsRepository() : base(PostsCollections.Posts)
        {

        }
    }
}
