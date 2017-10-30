using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.Interfaces;

namespace TesterProj_TNK_Lab2.ScriptInputs
{
    public class ScriptEditInput:AbstractScriptInput
    {
        public string ClassName { get; private set; }

        public ScriptEditInput(string data,string className)
        {
            Data = data;
            ClassName = className;
        }

        public override void Accept(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
