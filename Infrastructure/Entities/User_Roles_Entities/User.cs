using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User_Roles_Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }


        public ICollection<User_Role> User_Roles { get; set; }
    }
}
