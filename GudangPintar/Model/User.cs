using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    public class User
    {
        private int userid; 
        private string name { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private Role role { get; set; }
        private User created_by;
        private DateTime created_at;
        private DateTime updated_at;

        public User(int userid, string name, string username, string password, Role role)
        {
            this.userid = userid;
            this.name = name;
            this.username = username;
            this.password = password;
            this.role = role;
        }
    }

}
