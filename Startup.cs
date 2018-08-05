using BlogApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BlogApi
{


  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<PostContext>(opt =>
          opt.UseSqlite(Configuration.GetConnectionString("PostContext")));
      services.AddMvc()
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
    public void Configure(IApplicationBuilder app)
    {
      app.UseMvc();
    }
  }
}