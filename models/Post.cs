using System;

namespace BlogApi.Models
{
    public class Post
    {   
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
    }
}