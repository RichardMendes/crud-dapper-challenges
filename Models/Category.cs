using System.ComponentModel.DataAnnotations.Schema;
using Blog.Models;
using Dapper.Contrib.Extensions;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace Blog
{
    [Table("[Category]")]
    public class Category
    {
        public Category()
        => Posts = new List<Post>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public List<Post> Posts { get; set; }
    }
}