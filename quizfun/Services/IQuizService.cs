using quizfun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizfun.Services
{
    interface IQuizService
    {
        int scoreSum(int score, int value,Pregunta p);
    }
}
