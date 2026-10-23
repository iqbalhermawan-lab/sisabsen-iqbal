using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisabsen_iqbal
{
    class UserSession
    {
        public static int IdUser { get; set; }
        public static string Username { get; set; }
        public static int IdRole { get; set; }
        public static int? IdGuru { get; set; }

        public static void Logout()
        {
            IdUser = 0;
            Username = null;
            IdRole = 0;
            IdGuru = null;
        }
    }
}
