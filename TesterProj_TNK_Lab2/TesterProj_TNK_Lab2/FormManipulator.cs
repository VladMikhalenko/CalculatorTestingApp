using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.Interfaces;
using TesterProj_TNK_Lab2.FormBinders;
using TesterProj_TNK_Lab2.ScriptInputs;

namespace TesterProj_TNK_Lab2
{
    public class FormManipulator:IScriptVisitor
    {
        AbstractWinAPIBinder formBinder;

        public FormManipulator(AbstractWinAPIBinder binder)
        {
            formBinder = binder;
        }
        public void Visit(ScriptEditInput input)
        {
            formBinder.SetEditText(input.ClassName, input.Data);
        }

        public void Visit(ScriptCheckBoxInput input)
        {
            bool state;
            bool.TryParse(input.State, out state);
            if (state)
                formBinder.SetCheckBoxChecked(input.Caption);
            else
                formBinder.SetCheckBoxUnChecked(input.Caption);
        }

        public void Visit(ScriptButtonInput input)
        {
            formBinder.ProcessInputData(input.Data);
        }
    }
}
