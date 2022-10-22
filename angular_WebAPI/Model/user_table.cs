using System.ComponentModel.DataAnnotations;

namespace angular_WebAPI.Model
{
    public class user_table
    {
            [Key]
            public Guid UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
    }
}
