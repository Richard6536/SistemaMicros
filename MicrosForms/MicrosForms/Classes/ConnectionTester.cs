using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicrosForms.Model;

namespace MicrosForms.Classes
{
    class ConnectionTester
    {

        public static bool IsConnectionActive()
        {
            try
            {
                var BD = new MicroSystemContext();

                List<Usuario> test = BD.Usuarios.ToList();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
                     
        }
    }
}
