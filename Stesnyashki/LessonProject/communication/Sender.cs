using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stesnyashki.Models;

namespace Stesnyashki.communication
{
    public class Sender
    {
        public bool questionSender(int idSender, int idReciever, string textquestion,bool modesender) 
        {
            ShyMeContext Sh = new ShyMeContext();
            
            try {
                Question Q = new Question
                {
                    idSender = idSender,
                    idReciever = idReciever,
                    qText = textquestion,
                    qDate = DateTime.Now
                };
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
            return false;
        }
    }
}