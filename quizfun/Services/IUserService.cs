﻿using System;
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
        List<Cuenta> ReaderUserId(int id);
        bool UpdateUser(Cuenta user);
        bool DeleteUser(int id);
    }
}
