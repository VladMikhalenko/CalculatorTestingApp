using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.ScriptInputs;
namespace TesterProj_TNK_Lab2
{
    public class CalculatorFileParser
    {
        const string DataKey = "#data";
        const string ExprKey = "#expressions";
        const string InputKey = "#input_test";
        string FilePath { get; set; }
        StreamReader FileReader { get; set; }
        string CurrentLine { get; set; }

        public CalculatorFileParser(string path)
        {
            FilePath = path;
        }
        public CalculatorScript ParseFile()
        {
            CalculatorScript script = new CalculatorScript();
            using (FileReader = new StreamReader(FilePath))
            {
                if (FindKey(DataKey))
                {
                    ParseDataBlock(ref script);
                    if (FindKey(ExprKey))
                        ParseExpressionBlock(ref script);
                    if (FindKey(InputKey))
                        ParseInputBlock(ref script);
                }
                else
                    throw new InvalidDataException("Invalid script-file structure");
            }
            return script;
        }

        private void ParseExpressionBlock(ref CalculatorScript script)
        {
            ReadLine();
            int indexOfEqual = -1;
            while (CurrentLine[0]!='#' && !FileReader.EndOfStream)
            {
                
                indexOfEqual = CurrentLine.LastIndexOf("=");
                string expr = CurrentLine.Substring(0, indexOfEqual);
                string ans = CurrentLine.Substring(indexOfEqual + 1, CurrentLine.Length - indexOfEqual-1);
                if (string.IsNullOrEmpty(expr) || string.IsNullOrEmpty(ans))
                {
                    throw new InvalidDataException();
                }
                else
                {
                    script.AddExpression(new ScriptExpression(expr, ans));
                }
                ReadLine();
            }
        }
        private void ParseDataBlock(ref CalculatorScript script)
        {
            ReadLine();
            int indexOfColon = -1;
            while (CurrentLine[0] != '#')
            {
                if (FileReader.EndOfStream)
                    return;
                indexOfColon = CurrentLine.IndexOf(":");
                string key = CurrentLine.Substring(0, indexOfColon);
                string keyValue = CurrentLine.Substring(indexOfColon + 1, CurrentLine.Length - indexOfColon - 1);
                switch (key)
                {
                    case "formName":
                        script.FormName = keyValue;
                        break;
                    case "formClass":
                        script.FormClassName = keyValue;
                        break;
                    case "button":
                        script.ButtonClassName = keyValue;
                        break;
                    case "inputEdit":
                        script.InputEditClassName = keyValue;
                        break;
                    case "memoryEdit":
                        script.MemoryEditClassName = keyValue;
                        break;
                    case "checkBox":
                        script.CheckBoxClassName = keyValue;
                        break;
                    default: throw new InvalidDataException("Invalid data string in script data block");
                }
                ReadLine();
            }
        }
        private void ParseInputBlock(ref CalculatorScript script)
        {
            ReadLine();
            int indexOfLeft = -1;
            int indexOfRight = -1;
            int indexOfEqual = -1;
            while (CurrentLine[0] != '#')
            {
                
                indexOfLeft = CurrentLine.IndexOf("(");
                indexOfRight = CurrentLine.IndexOf(")");
                indexOfEqual = CurrentLine.IndexOf("=");
                string key = CurrentLine.Substring(0, indexOfLeft);
                string keyValue = CurrentLine.Substring(indexOfLeft + 1, indexOfRight-indexOfLeft-1);
                string addInfo = indexOfEqual > 0 ? CurrentLine.Substring(indexOfEqual + 1, CurrentLine.Length - indexOfEqual - 1):"";
                switch (key)
                {
                    case "btn":
                        script.AddInputControl(new ScriptButtonInput(keyValue));
                        break;
                    case "edit":
                        script.AddInputControl(new ScriptEditInput(keyValue,addInfo));
                        break;
                    case "chbx":
                        script.AddInputControl(new ScriptCheckBoxInput(keyValue,addInfo));
                        break;
                    default: throw new InvalidDataException("Invalid data string in script data block");
                }
                if (FileReader.EndOfStream)
                    return;
                ReadLine();
                
            }

        }
        private bool FindKey(string key)
        {
            if (CurrentLine == key)
                return true;
            if (FileReader != null)
            {
                while (!FileReader.EndOfStream)
                {
                    ReadLine();
                    if (CurrentLine.Equals(key))
                        return true;
                }
                return false;
            }
            else
                throw new NullReferenceException();
        }
        
        private void ReadLine()
        {
            if (CanRead())
                CurrentLine = FileReader.ReadLine();
            else
                throw new NullReferenceException();
        }
        private bool CanRead()
        {
            return FileReader != null && !FileReader.EndOfStream;
        }
    }
}
