using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.Interfaces;
using TesterProj_TNK_Lab2.ScriptInputs;
namespace TesterProj_TNK_Lab2
{
    public class ScriptButtonInput : AbstractScriptInput
    {
        public ScriptButtonInput(string data)
        {
            Data = data;
        }

        public override void Accept(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
