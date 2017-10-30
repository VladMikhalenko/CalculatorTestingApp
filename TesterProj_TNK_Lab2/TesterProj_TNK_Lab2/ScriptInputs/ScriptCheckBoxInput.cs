using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.Interfaces;

namespace TesterProj_TNK_Lab2.ScriptInputs
{
    public class ScriptCheckBoxInput:AbstractScriptInput
    {
        string state;
        public string State
        {
            get { return state; }
            set {
                bool res;
                if (bool.TryParse(value,out res))
                    state = value;
                else
                    throw new FormatException();
                }
        }
        public string Caption { get; set; }

        public ScriptCheckBoxInput(string state,string caption="новая версия")
        {
            State = state;
            Caption = caption;
        }
        public string GetData()
        {
            return State;
        }

        public override void Accept(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
