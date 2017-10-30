using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.Interfaces;
using TesterProj_TNK_Lab2.FormBinders;
using TesterProj_TNK_Lab2.ScriptInputs;

namespace TesterProj_TNK_Lab2
{
    public class CalculatorScriptRuner
    {
        public CalculatorScript Script { get; set; }
        public FormManipulator Manipulator { get; set; }
        public CalculatorFormBinder FormBinder { get; set; }
        public CalculatorScriptRuner(CalculatorScript script)
        { 
            Script = script;
            FormBinder = new CalculatorFormBinder(script.FormClassName, script.FormName, script.ButtonClassName, script.InputEditClassName, script.MemoryEditClassName, script.CheckBoxClassName);
            Manipulator = new FormManipulator(FormBinder);
        }
        public bool BindWindow()
        {
            return FormBinder.TryBindForm(Script.FormClassName, Script.FormName);
        }
        public bool CalculateMathExpression(ScriptExpression exp,out string result)
        {
            char reset = 'C';
            char equal = '=';
           
            string task = reset + exp.Value + equal;
            try
            {
                FormBinder.ProcessInputData(task);
                result = FormBinder.GetEditText(Script.InputEditClassName);
                return exp.CheckAnswer(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error occured:" + ex.Message);
            }
            result = "error";
            return false;
        }
        public string GetMemoryEditText()
        {
            return FormBinder.GetEditText(Script.MemoryEditClassName);
        }
        public string GetInputEditText()
        {
            return FormBinder.GetEditText(Script.InputEditClassName);
        }
        public void SetInputEditText(string text)
        {
            FormBinder.SetEditText(Script.InputEditClassName, text);
        }
        public void SetMemoryEditText(string text)
        {
            FormBinder.SetEditText(Script.MemoryEditClassName, text);
        }

        public uint GetWindowDescriptor()
        {
            return FormBinder.WindowDescriptor;
        }
        public string GetIpClassName()
        {
            return Script.FormClassName;
        }
        public string GetIpWindowName()
        {
            return Script.FormName;
        }

        public void RunFullTest(ref ScriptReport report)
        {
            string output = "";
            if(Script.ExpressionsList.Count>0)
            {
                report.AddTopic("Expressions calculation");
                foreach (ScriptExpression ex in Script.ExpressionsList)
                {
                    bool res = CalculateMathExpression(ex,out output);
                    string repo = ex.Value + "=" + ex.Answer+" Результат вычислений:"+output;
                    report.AddContent(res ? "(►)" + repo : "(֍)" + repo);//☑
                }
            }
            if(Script.Inputs.Count>0)
            {
                report.AddTopic("Input testing");
                foreach (AbstractScriptInput input in Script.Inputs)
                {
                    input.Accept(Manipulator);
                    string repo = "(►)" + input.Data;
                    report.AddContent(repo);
                }
            }   
        }
    }
}
