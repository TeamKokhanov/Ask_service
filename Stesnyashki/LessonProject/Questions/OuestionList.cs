using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stesnyashki.Models;
using Stesnyashki.DAL;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace Stesnyashki.Questions
{
    public class OuestionList
    {
        SQLConnector SQ = new SQLConnector();
        public List<Question> QuestionListRetern(int idReciever) 
        {
           
            DataTable QuestionList = SQ.Select("Question", "*", "idReciever=" + Convert.ToString(idReciever));
            List<int> idSender = QuestionList.AsEnumerable().Select(r => r.Field<int>("idSender")).ToList();
            List<string> qText = QuestionList.AsEnumerable().Select(r => r.Field<string>("qText")).ToList();
            List<DateTime> qDate = QuestionList.AsEnumerable().Select(r => r.Field<DateTime>("qDate")).ToList();
            List<string> aText = QuestionList.AsEnumerable().Select(r => r.Field<string>("aText")).ToList();
            List<int> id = QuestionList.AsEnumerable().Select(r => r.Field<int>("id")).ToList();
            int j = 0;
            List<Question> QuestionsList = new List<Question>();
            int count = 0;
            foreach (var i in qText) 
            {
                if (aText[count] == null)
                {
                    Question q = new Question { id = id[j], idSender = idSender[j], idReciever = idReciever, qText = i, qDate = qDate[j] };
                    QuestionsList.Add(q);
                }
                count++;
            }
            return QuestionsList;
        }

        public bool Answer(int idQuestion,string answertext) 
        {
            List<string> arg = new List<string>();
            List<string> values= new List<string>();
            arg.Add(answertext);
            arg.Add(Convert.ToString(DateTime.Now));
            values.Add("aText");
            values.Add("aDate");
            try
            {
                SQ.Update("Question", arg, values, "id=" + Convert.ToString(idQuestion));
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }

            return true;
        }
    }
}