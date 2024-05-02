using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? City { get; set; }
        public string? İmageUrl { get; set; }
        public string? Description { get; set; }

        public List<Article> Articles { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Message> SenderMail { get; set; }
        public List<Message> ReceiverMail { get; set; }
    }
}
