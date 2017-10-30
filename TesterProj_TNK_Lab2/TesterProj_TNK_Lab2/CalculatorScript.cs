using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.ScriptInputs;
namespace TesterProj_TNK_Lab2
{
    public class CalculatorScript
    {
        public string FormName { get; set; }
        public string FormClassName { get; set; }
        public string ButtonClassName { get; set; }
        public string InputEditClassName { get; set; }
        public string MemoryEditClassName { get; set; }
        public string CheckBoxClassName { get; set; }

        public List<ScriptExpression> ExpressionsList { get; private set; }
        public List<AbstractScriptInput> Inputs { get; private set; }
        
        public CalculatorScript()
        {
            ExpressionsList = new List<ScriptExpression>();
            Inputs = new List<AbstractScriptInput>();
        }
        public void AddExpression(ScriptExpression exp)
        {
            if(!ExpressionsList.Contains(exp))
                ExpressionsList.Add(exp);
        }
        public void AddInputControl(AbstractScriptInput input)
        {
            Inputs.Add(input);
        }
    }
}
