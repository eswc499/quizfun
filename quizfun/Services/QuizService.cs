using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quizfun.Models;

namespace quizfun.Services
{
    public class QuizService : IQuizService
    {
        public int scoreSum(int score, int value, Pregunta p)
        {

            if(value == int.Parse(p.respuesta))
            {
                score = score + 2;
            }
            
            if(value != int.Parse(p.respuesta))
            {
                score = score + 0;
            }
            return score;
        }
    }
}