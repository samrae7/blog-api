using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BlogApi.Models;
using BlogApi.Services;
using System.Web;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using BlogApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;

namespace BlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class S3UploadController : ControllerBase
  {
    public string AWS_KEY {get; private set;}
    public string AWS_SECRET {get; private set;}
    public static IConfiguration Configuration { get; set; }
    private AmazonUploader uploader { get; set; }

    public S3UploadController(IConfiguration config)
    {
      Configuration = config;
      AWS_KEY = Configuration["AWS_KEY"];
      AWS_SECRET = Configuration["AWS_SECRET"];
      uploader = new AmazonUploader(AWS_KEY, AWS_SECRET);
    }

    [HttpGet]
    public ListObjectsResponse GetAll()
    {
      return uploader.ListingObjectsAsync().Result;
    }
      
    [HttpPost]
    public PutObjectResponse MyFileUpload()
    {
      var request = HttpContext.Request;
      var fileStream = request.Body;
      var contentLength = request.ContentLength;
      var contentType = request.ContentType;
      // string filePath = this.Request.Form.Files.First().FileName;

      var length = contentLength.HasValue ? (long)contentLength : 0;
      return uploader.sendMyFileToS3(fileStream, contentType, length).Result;
    }
  }
}
