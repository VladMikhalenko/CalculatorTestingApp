using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.Interfaces;

namespace TesterProj_TNK_Lab2.ScriptInputs
{
    public abstract class AbstractScriptInput
    {
        public string Data { get; set; }
        public abstract void Accept(IScriptVisitor visitor);
    }
}
