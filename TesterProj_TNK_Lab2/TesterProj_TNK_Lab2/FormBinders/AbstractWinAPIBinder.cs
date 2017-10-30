using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TesterProj_TNK_Lab2.Interfaces
{
    public abstract class AbstractWinAPIBinder
    {
        public string IpClassName { get; set; }
        public string IpWindowName { get; set; }
        public uint WindowDescriptor { get; set; }


        #region Win API CONSTS
        protected const int WM_LBUTTONDOWN = 0x0201;
        protected const int WM_LBUTTONUP = 0x0202;
        protected const int WM_KEYDOWN = 0x0100;
        protected const int WM_KEYUP = 0x0101;
        protected const int WM_CHAR = 0x0102;
        
        protected const int WM_SETTEXT = 0x000C;
        protected const int WM_GETTEXT = 0x000d;
        protected const int WM_GETTEXTLENGTH = 0x000E;

        protected const int BM_GETCHECK = 0x00f0;
        protected const int BM_SETCHECK = 0x00f1;
        protected const int BM_CLICK = 0x00F5;

        protected const int BST_CHECKED = 0x1;
        protected const int BST_INDERTEMINATE = 0x2;
        protected const int BST_UNCHECKED = 0x0;
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

        public bool TryBindForm(string IpClassName, string IpWindowName)
        {
            uint desc = FindWindow(IpClassName, IpWindowName);
            if (desc == 0)
                return false;
            WindowDescriptor = desc;
            this.IpClassName = IpClassName;
            this.IpWindowName = IpWindowName;
            return true;
        }
        public void ClickButton(string btnCaption,string btnClass)
        {
            if (IsBound())
            {
                uint btnDes = FindWindowEx(WindowDescriptor, 0, btnClass, btnCaption);
                if (btnDes != 0)
                {
                    SendMessage(btnDes, WM_LBUTTONDOWN, 0, 0);
                    SendMessage(btnDes, WM_LBUTTONUP, 0, 0);
                }
            }
        }
        public string GetEditText(string editClassName)
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
        public void SetEditText(string editClassName, string text)
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

        public abstract void ProcessInputData(string data);
        public abstract bool GetCheckBoxState(string caption);
        public abstract void SetCheckBoxChecked(string caption);
        public abstract void SetCheckBoxUnChecked(string caption);
        public bool IsBound()
        {
            return WindowDescriptor > 0;
        }
    }
}
