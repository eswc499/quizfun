using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quizfun.Models;

namespace quizfun.Services
{
    interface IUserService
    {
        bool CreateUser(Cuenta user);
        List<Cuenta> ReaderUser();
        List<Cuenta> ReaderUserId(String Nick);
        bool UpdateUser(Cuenta user);
        bool DeleteUser(string c);
        bool scoreup(string nombre, int id);
        List<Cuenta> BuscaCuenta(string nombre, string psswd);
    }
}
