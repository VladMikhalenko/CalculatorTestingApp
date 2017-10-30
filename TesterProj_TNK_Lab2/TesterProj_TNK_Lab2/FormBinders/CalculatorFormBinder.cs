using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterProj_TNK_Lab2.Interfaces;
namespace TesterProj_TNK_Lab2.FormBinders
{
    public class CalculatorFormBinder : AbstractWinAPIBinder
    {
        public string ButtonClassName { get; private set; }
        public string MemoryEditClassName { get; private set; }
        public string InputEditClassName { get; private set; }
        public string CheckBoxClassName { get; private set; }

        public CalculatorFormBinder(string IpClassName, string IpWindowName, string buttonClass, string inputEditClass, string memoryEditClass, string checkBoxClass)
        {
            this.IpClassName = IpClassName;
            this.IpWindowName = IpWindowName;
            ButtonClassName = buttonClass;
            MemoryEditClassName = memoryEditClass;
            InputEditClassName = inputEditClass;
            CheckBoxClassName = checkBoxClass;
        }

        public override void ProcessInputData(string data)
        {
            if (IsBound())
            {
                foreach (string num in data.Select(el => el.ToString()).ToArray())
                    ClickButton(num, ButtonClassName);
            }
        }
       
        public override void SetCheckBoxChecked(string caption)
        {//?????
            if (IsBound())
            {
                uint chbDes = FindWindowEx(WindowDescriptor, 0, CheckBoxClassName, caption);
                if (chbDes > 0)
                    SendMessage(chbDes, BM_SETCHECK, 1, 1);
                else throw new NullReferenceException("Control not found");
            }
            else
                throw new NullReferenceException("No window is bound");
        }

        public override void SetCheckBoxUnChecked(string caption)
        {
            if (IsBound())
            {
                uint chbDes = FindWindowEx(WindowDescriptor, 0, CheckBoxClassName, caption);
                if (chbDes > 0)
                    SendMessage(chbDes, BM_SETCHECK,0, 1);
                else throw new NullReferenceException("Control not found");
            }
            else
                throw new NullReferenceException("No window is bound");
        }

        public override bool GetCheckBoxState(string caption)
        {
            if (IsBound())
            {
                uint chbDes = FindWindowEx(WindowDescriptor, 0, CheckBoxClassName, caption);
                IntPtr state=chbDes>0? SendMessage(chbDes, BM_GETCHECK, 0, 0):(IntPtr)BST_INDERTEMINATE;
                bool ret = false;
                switch(state.ToInt32())
                {
                    case BST_CHECKED:ret = true;
                        break;
                    case BST_INDERTEMINATE://interesting place
                        break;
                    case BST_UNCHECKED:ret = false;
                        break;
                }
                return ret;
            }
            else
                throw new NullReferenceException("No window is bound");
        }
    }
}
