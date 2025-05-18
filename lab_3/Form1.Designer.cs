namespace lab_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonAddAll = new Button();
            buttonIsConnected = new Button();
            buttonBTree = new Button();
            buttonResult = new Button();
            SuspendLayout();
            // 
            // buttonAddAll
            // 
            buttonAddAll.Location = new Point(12, 65);
            buttonAddAll.Name = "buttonAddAll";
            buttonAddAll.Size = new Size(266, 47);
            buttonAddAll.TabIndex = 0;
            buttonAddAll.Text = "Добавить 1 кк записей";
            buttonAddAll.UseVisualStyleBackColor = true;
            buttonAddAll.Click += buttonAddAll_Click;
            // 
            // buttonIsConnected
            // 
            buttonIsConnected.Location = new Point(12, 12);
            buttonIsConnected.Name = "buttonIsConnected";
            buttonIsConnected.Size = new Size(266, 47);
            buttonIsConnected.TabIndex = 1;
            buttonIsConnected.Text = "Проверить подключение";
            buttonIsConnected.UseVisualStyleBackColor = true;
            buttonIsConnected.Click += buttonIsConnected_Click;
            // 
            // buttonBTree
            // 
            buttonBTree.Location = new Point(12, 118);
            buttonBTree.Name = "buttonBTree";
            buttonBTree.Size = new Size(266, 47);
            buttonBTree.TabIndex = 2;
            buttonBTree.Text = "B-Tree (сбалансированное дерево)";
            buttonBTree.UseVisualStyleBackColor = true;
            buttonBTree.Click += buttonBTree_Click;
            // 
            // buttonResult
            // 
            buttonResult.Location = new Point(12, 340);
            buttonResult.Name = "buttonResult";
            buttonResult.Size = new Size(266, 47);
            buttonResult.TabIndex = 3;
            buttonResult.Text = "Результаты";
            buttonResult.UseVisualStyleBackColor = true;
            buttonResult.Click += buttonResult_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 399);
            Controls.Add(buttonResult);
            Controls.Add(buttonBTree);
            Controls.Add(buttonIsConnected);
            Controls.Add(buttonAddAll);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "lab_3";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAddAll;
        private Button buttonIsConnected;
        private Button buttonBTree;
        private Button buttonResult;
    }
}
