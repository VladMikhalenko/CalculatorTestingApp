using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TesterProj_TNK_Lab2
{
    public class Calculator
    {
        public string IpClassName { get; private set; }
        public string IpWindowName { get; private set; }
        public uint WindowDescriptor { get; private set; }

        #region Win API CONSTS
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        const int WM_CHAR = 0x0102;
        const int BM_CLICK = 0x00F5;
        const int WM_SETTEXT = 0x000C;
        const int WM_GETTEXT = 0x000d;
        const int WM_GETTEXTLENGTH = 0x000E;

        const int BM_GETCHECK = 0x00f0;
        const int BM_SETCHECK = 0x00f1;
        #endregion

        
        #region External functions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint FindWindowEx(uint hwndParent, uint hwndChildAfter, string className, string windowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(uint hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(uint hWnd, int msg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(uint hWnd, int msg, int wParam, bool lParam);

        #endregion
        public bool TryBindWindow(string IpClassName, string IpWindowName)
        {
            uint desc = FindWindow(IpClassName, IpWindowName);
            if (desc == 0)
                return false;
            WindowDescriptor = desc;
            this.IpClassName = IpClassName;
            this.IpWindowName = IpWindowName;
            return true;    
        }
        public void ProcessInputString(string input, string buttonClass)
        {
            foreach (string num in input.Select(el => el.ToString()).ToArray())
                ClickButton(num, buttonClass);
        }
        public void ClickButton(string caption,string buttonClass)
        {
            if(IsBound())
            {
                uint btnDes = FindWindowEx(WindowDescriptor, 0, buttonClass, caption);
                if (btnDes != 0)
                {
                    SendMessage(btnDes, WM_LBUTTONDOWN, 0, 0);
                    SendMessage(btnDes, WM_LBUTTONUP, 0, 0);
                }
            }
        }
        public string GetTextFromEditField(string editClassName)
        {
            if (IsBound())
            {
                uint editDesc = FindWindowEx(WindowDescriptor, 0, editClassName, "");
                IntPtr textSize = SendMessage(editDesc, WM_GETTEXTLENGTH, 0, 0);
                StringBuilder sb = new StringBuilder();
                if ((int)textSize > 0)
                {
                    sb = new StringBuilder((textSize + 1).ToInt32());
                    SendMessage((IntPtr)editDesc, WM_GETTEXT, sb.Capacity, sb);
                }
                return sb.ToString();
            }
            else
                throw new NullReferenceException("No window is bound");
            
        }
        public void SetTextToEditField(string editClassName,string text)
        {
            if (IsBound())
            {
                uint editDesc = FindWindowEx(WindowDescriptor, 0, editClassName, "");
                if (editDesc > 0)
                    SendMessage(editDesc, WM_SETTEXT, 0, text);
            }
            else
                throw new NullReferenceException("No window is bound");
        }

        public bool GetCheckBoxValue(string caption,string checkBoxClass)
        {
            if(IsBound())
            {
                uint chbDes = FindWindowEx(WindowDescriptor, 0, checkBoxClass, caption);
                bool state = default(bool);
                if (chbDes > 0)
                    SendMessage(chbDes, BM_GETCHECK, 0, state);
                return state;
            }
            else
                throw new NullReferenceException("No window is bound");

        }

        public void SetCheckBoxValue(string caption, string checkBoxClass,bool state)
        {
            if(IsBound())
            {
                uint chbDes = FindWindowEx(WindowDescriptor, 0, checkBoxClass, caption);
                if (chbDes > 0)
                    SendMessage(chbDes, BM_SETCHECK, 0, 1);
            }
            else
            throw new NullReferenceException("No window is bound");
        }

        public bool IsBound()
        {
            return WindowDescriptor > 0;
        }
    }
}
