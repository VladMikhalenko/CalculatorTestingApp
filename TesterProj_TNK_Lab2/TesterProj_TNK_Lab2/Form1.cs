using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TesterProj_TNK_Lab2.ScriptInputs;
namespace TesterProj_TNK_Lab2
{    
    public partial class Form1 : Form
    {
        const string WinLabelDescriptor = "Window descriptor:";
        const string WinLabelClassName = "Window class name:";
        const string WinLabelName = "Window name:";
        CalculatorScriptRuner Runner { get; set; } = null;
        CalculatorFileParser Parser { get; set; } = null;
        CalculatorScript Script { get; set; } = null;
        public Form1()
        {
            InitializeComponent();
            gbTest.Enabled = false;
            //tbIpClassName.Text = "Tjform";
            //tbIpWindowName.Text = "CALC";
        }
        
        private void btnTestNums_Click(object sender, EventArgs e)
        {
            ScriptButtonInput input = new ScriptButtonInput("0123456789.");
            Runner.Manipulator.Visit(input);
        }
        private void btnGetMem_Click(object sender, EventArgs e)
        {
            tbMemory.Text = Runner.GetMemoryEditText();
        }
        private void btnGetEdit_Click(object sender, EventArgs e)
        {
            tbEdit.Text = Runner.GetInputEditText();
        }


        private void btnRunTest_Click(object sender, EventArgs e)
        {
            if(Runner.FormBinder.GetCheckBoxState("новая версия"))
                Runner.FormBinder.SetCheckBoxUnChecked("новая версия");
            else
                Runner.FormBinder.SetCheckBoxChecked("новая версия");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.Filter = "test scripts (*.script)|*script|All files (*.*)|*.*";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    Parser = new CalculatorFileParser(OFD.FileName);
                    Script = Parser.ParseFile();
                }
                else
                {
                    MessageBox.Show("Script-file was not selected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Script = null;
                }
            }
            if(Script!=null)
            {
                Runner = new CalculatorScriptRuner(Script);
                bool res = Runner.BindWindow();
                if (res)
                {
                    DisplayScriptInfo(Runner.GetWindowDescriptor().ToString(),Runner.GetIpClassName(),Runner.GetIpWindowName());
                    MessageBox.Show("Окно успешно найдено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Окно не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gbTest.Enabled = res;

            }
        }

        private void DisplayScriptInfo(string winDesc, string winClass, string winName)
        {
            lbWDesc.Text = WinLabelDescriptor + winDesc;
            lbWClass.Text = WinLabelClassName + winClass;
            lbWName.Text = WinLabelName + winName;
            listControls.Items.Add("Buttons:"+Script.ButtonClassName);
            listControls.Items.Add("Iput edit:"+Script.InputEditClassName);
            listControls.Items.Add("Memory edit:"+Script.MemoryEditClassName);
            listControls.Items.Add("CheckBox:"+ Script.CheckBoxClassName);
        }

        
        private void btnFullTest_Click(object sender, EventArgs e)
        {
            lbProtocol.Items.Clear();
            ScriptReport report = new ScriptReport();
            Runner.RunFullTest(ref report);
            report.Report.ForEach(el => lbProtocol.Items.Add(el));
        }
    }
}
