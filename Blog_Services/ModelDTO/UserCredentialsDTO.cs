using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.ModelDTO
{
    public class UserCredentialsDTO
    {
        public int UserID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
