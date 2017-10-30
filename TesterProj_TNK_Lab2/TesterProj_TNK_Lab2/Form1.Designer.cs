namespace TesterProj_TNK_Lab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbWDesc = new System.Windows.Forms.Label();
            this.btnTestNums = new System.Windows.Forms.Button();
            this.gbTest = new System.Windows.Forms.GroupBox();
            this.btnFullTest = new System.Windows.Forms.Button();
            this.btnOperations = new System.Windows.Forms.Button();
            this.btnGetEdit = new System.Windows.Forms.Button();
            this.tbEdit = new System.Windows.Forms.TextBox();
            this.btnGetMem = new System.Windows.Forms.Button();
            this.tbMemory = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbWClass = new System.Windows.Forms.Label();
            this.lbWName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listControls = new System.Windows.Forms.ListBox();
            this.lbProtocol = new System.Windows.Forms.ListBox();
            this.gbTest.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbWDesc
            // 
            this.lbWDesc.AutoSize = true;
            this.lbWDesc.Location = new System.Drawing.Point(6, 16);
            this.lbWDesc.Name = "lbWDesc";
            this.lbWDesc.Size = new System.Drawing.Size(98, 13);
            this.lbWDesc.TabIndex = 3;
            this.lbWDesc.Text = "Window descriptor:";
            // 
            // btnTestNums
            // 
            this.btnTestNums.Location = new System.Drawing.Point(6, 14);
            this.btnTestNums.Name = "btnTestNums";
            this.btnTestNums.Size = new System.Drawing.Size(91, 35);
            this.btnTestNums.TabIndex = 4;
            this.btnTestNums.Text = "Push number buttons";
            this.btnTestNums.UseVisualStyleBackColor = true;
            this.btnTestNums.Click += new System.EventHandler(this.btnTestNums_Click);
            // 
            // gbTest
            // 
            this.gbTest.Controls.Add(this.btnFullTest);
            this.gbTest.Controls.Add(this.btnOperations);
            this.gbTest.Controls.Add(this.btnGetEdit);
            this.gbTest.Controls.Add(this.tbEdit);
            this.gbTest.Controls.Add(this.btnGetMem);
            this.gbTest.Controls.Add(this.tbMemory);
            this.gbTest.Controls.Add(this.btnTestNums);
            this.gbTest.Location = new System.Drawing.Point(12, 138);
            this.gbTest.Name = "gbTest";
            this.gbTest.Size = new System.Drawing.Size(498, 212);
            this.gbTest.TabIndex = 5;
            this.gbTest.TabStop = false;
            this.gbTest.Text = "Tests";
            // 
            // btnFullTest
            // 
            this.btnFullTest.Location = new System.Drawing.Point(10, 157);
            this.btnFullTest.Name = "btnFullTest";
            this.btnFullTest.Size = new System.Drawing.Size(87, 35);
            this.btnFullTest.TabIndex = 13;
            this.btnFullTest.Text = "Run Full Test";
            this.btnFullTest.UseVisualStyleBackColor = true;
            this.btnFullTest.Click += new System.EventHandler(this.btnFullTest_Click);
            // 
            // btnOperations
            // 
            this.btnOperations.Location = new System.Drawing.Point(6, 55);
            this.btnOperations.Name = "btnOperations";
            this.btnOperations.Size = new System.Drawing.Size(91, 35);
            this.btnOperations.TabIndex = 12;
            this.btnOperations.Text = "Change CheckBox state";
            this.btnOperations.UseVisualStyleBackColor = true;
            this.btnOperations.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // btnGetEdit
            // 
            this.btnGetEdit.Location = new System.Drawing.Point(220, 188);
            this.btnGetEdit.Name = "btnGetEdit";
            this.btnGetEdit.Size = new System.Drawing.Size(133, 23);
            this.btnGetEdit.TabIndex = 10;
            this.btnGetEdit.Text = "Get edit text";
            this.btnGetEdit.UseVisualStyleBackColor = true;
            this.btnGetEdit.Click += new System.EventHandler(this.btnGetEdit_Click);
            // 
            // tbEdit
            // 
            this.tbEdit.Location = new System.Drawing.Point(220, 8);
            this.tbEdit.Multiline = true;
            this.tbEdit.Name = "tbEdit";
            this.tbEdit.Size = new System.Drawing.Size(133, 173);
            this.tbEdit.TabIndex = 9;
            // 
            // btnGetMem
            // 
            this.btnGetMem.Location = new System.Drawing.Point(359, 187);
            this.btnGetMem.Name = "btnGetMem";
            this.btnGetMem.Size = new System.Drawing.Size(132, 23);
            this.btnGetMem.TabIndex = 8;
            this.btnGetMem.Text = "Get memory text";
            this.btnGetMem.UseVisualStyleBackColor = true;
            this.btnGetMem.Click += new System.EventHandler(this.btnGetMem_Click);
            // 
            // tbMemory
            // 
            this.tbMemory.Location = new System.Drawing.Point(359, 8);
            this.tbMemory.Multiline = true;
            this.tbMemory.Name = "tbMemory";
            this.tbMemory.Size = new System.Drawing.Size(131, 173);
            this.tbMemory.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // lbWClass
            // 
            this.lbWClass.AutoSize = true;
            this.lbWClass.Location = new System.Drawing.Point(6, 39);
            this.lbWClass.Name = "lbWClass";
            this.lbWClass.Size = new System.Drawing.Size(76, 13);
            this.lbWClass.TabIndex = 8;
            this.lbWClass.Text = "Window class:";
            // 
            // lbWName
            // 
            this.lbWName.AutoSize = true;
            this.lbWName.Location = new System.Drawing.Point(6, 63);
            this.lbWName.Name = "lbWName";
            this.lbWName.Size = new System.Drawing.Size(78, 13);
            this.lbWName.TabIndex = 9;
            this.lbWName.Text = "Window name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listControls);
            this.groupBox1.Controls.Add(this.lbWName);
            this.groupBox1.Controls.Add(this.lbWDesc);
            this.groupBox1.Controls.Add(this.lbWClass);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Window info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Window Controls Classes";
            // 
            // listControls
            // 
            this.listControls.FormattingEnabled = true;
            this.listControls.Location = new System.Drawing.Point(299, 35);
            this.listControls.Name = "listControls";
            this.listControls.Size = new System.Drawing.Size(212, 56);
            this.listControls.TabIndex = 10;
            // 
            // lbProtocol
            // 
            this.lbProtocol.Font = new System.Drawing.Font("Arial", 10F);
            this.lbProtocol.FormattingEnabled = true;
            this.lbProtocol.ItemHeight = 16;
            this.lbProtocol.Location = new System.Drawing.Point(13, 356);
            this.lbProtocol.Name = "lbProtocol";
            this.lbProtocol.Size = new System.Drawing.Size(497, 228);
            this.lbProtocol.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 588);
            this.Controls.Add(this.lbProtocol);
            this.Controls.Add(this.gbTest);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TesterApplication";
            this.gbTest.ResumeLayout(false);
            this.gbTest.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbWDesc;
        private System.Windows.Forms.Button btnTestNums;
        private System.Windows.Forms.GroupBox gbTest;
        private System.Windows.Forms.TextBox tbMemory;
        private System.Windows.Forms.Button btnGetMem;
        private System.Windows.Forms.Button btnGetEdit;
        private System.Windows.Forms.TextBox tbEdit;
        private System.Windows.Forms.Button btnOperations;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label lbWClass;
        private System.Windows.Forms.Label lbWName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listControls;
        private System.Windows.Forms.Button btnFullTest;
        private System.Windows.Forms.ListBox lbProtocol;
    }
}

