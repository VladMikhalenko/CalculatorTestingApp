using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesterProj_TNK_Lab2
{
    public class ScriptExpression
    {
        public string Value { get; set; }
        public string Answer { get; set; }

        public ScriptExpression(string value, string answer)
        {
            Value = value;
            Answer = answer;
        }
        public bool CheckAnswer(string answer)
        {
            return Answer == answer;
        }

        public override bool Equals(object obj)
        {
            ScriptExpression exp = (obj as ScriptExpression);
            return Value==exp.Value && Answer==exp.Answer;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
