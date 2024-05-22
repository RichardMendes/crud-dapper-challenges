using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace Blog
{
    [Table("[User]")]
    public class User
    {
        public User()
            => Roles = new List<Role>();

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        [Write(false)]
        public List<Role> Roles { get; set; }
    }
}