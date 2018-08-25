using BlogApi;
using BlogApi.Models;
using BlogApi.Controllers;
using Moq;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogApi.tests
{
  // This file was auto-generated based on version 1.2.0 of the canonical data.
  public class PostControllerTest
  {
    [Fact]
    public void constructor()
    {
      var posts = GetTestPosts();
      var mockSet = GetQueryableMockDbSet<Post>(posts);
      var mockContextOptions = new DbContextOptions<PostContext>();
      var mockContext = new Mock<PostContext>(mockContextOptions);
      mockContext.Setup(m => m.Posts).Returns(mockSet);

      var controller = new PostController(mockContext.Object);
      // var result = controller.GetAll();
      mockContext.Verify(c => c.Posts, Times.Once());
    }

    [Fact]
    public void GetAllCallsPosts()
    {
      var posts = GetTestPosts();
      var mockSet = GetQueryableMockDbSet<Post>(posts);
      var mockContextOptions = new DbContextOptions<PostContext>();
      var mockContext = new Mock<PostContext>(mockContextOptions);
      mockContext.Setup(m => m.Posts).Returns(mockSet);

      var controller = new PostController(mockContext.Object);
      var result = controller.GetAll();
      mockContext.Verify(c => c.Posts, Times.Exactly(2));
    }
    
    private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
    {
      var queryable = sourceList.AsQueryable();

      var dbSet = new Mock<DbSet<T>>();
      dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
      dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
      dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
      dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
      dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
      return dbSet.Object;
    }

    private List<Post> GetTestPosts()
    {
      var posts = new List<Post>();
      posts.Add(new Post()
      {
        Id = 1,
        Title = "First test post"
      });
      posts.Add(new Post()
      {
        Id = 2,
        Title = "Second test post"
      });
      return posts;
    }
  }
}
