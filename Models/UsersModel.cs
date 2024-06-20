using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackMetalBlog.Models
{
    [Table("Users")]
    public class UsersModel
    {
        public UsersModel(string username, string password, string name, string token)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Token = token;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Username { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string Token { get; set; }
    }
}