using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace Blog
{
    [Table("[Role]")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}