using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BlogApi.Models;

namespace BlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostController : ControllerBase
  {
    private readonly PostContext _context;

    public PostController(PostContext context)
    {
      _context = context;

      if (_context.Posts.Count() == 0)
      {
        _context.Posts.Add(new Post { Title = "Post1" });
        _context.SaveChanges();
      }
    }

    [HttpGet]
    public ActionResult<List<Post>> GetAll()
    {
      return _context.Posts.ToList();
    }

    [HttpGet("{id}", Name = "GetPost")]
    public ActionResult<Post> GetById(long id)
    {
      var post = _context.Posts.Find(id);
      if (post == null)
      {
        return NotFound();
      }
      return post;
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
      _context.Posts.Add(post); 
      _context.SaveChanges();

      return CreatedAtRoute("GetPost", new { id = post.Id }, post);
    }
  }
}
