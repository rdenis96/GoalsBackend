using BusinessLogic;
using Domain.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private PostsWorker worker;
        public PostsController()
        {
            worker = new PostsWorker();
        }
        [HttpPost]
        public async Task<ActionResult<Post>> Create([FromBody]Post postModel)
        {
            postModel = new Post
            {
                Date = postModel.Date,
                Description = postModel.Description
            };
            var post = await worker.Create(postModel);
            return Ok(post);
        }

        [HttpGet]
        public async Task<ActionResult<Post>> GetAll()
        {
            var posts = await worker.GetAll();
            return Ok(posts);
        }
    }
}
