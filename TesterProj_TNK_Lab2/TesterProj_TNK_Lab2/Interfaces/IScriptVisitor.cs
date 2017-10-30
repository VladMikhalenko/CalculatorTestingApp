using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.ScriptInputs;
namespace TesterProj_TNK_Lab2.Interfaces
{
    public interface IScriptVisitor
    {
        void Visit(ScriptButtonInput input);
        void Visit(ScriptCheckBoxInput input);
        void Visit(ScriptEditInput input);

    }
}
