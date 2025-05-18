namespace lab_3
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelBTree = new Label();
            BTreeInsert = new Label();
            SuspendLayout();
            // 
            // labelBTree
            // 
            labelBTree.AutoSize = true;
            labelBTree.Location = new Point(151, 35);
            labelBTree.Name = "labelBTree";
            labelBTree.Size = new Size(41, 15);
            labelBTree.TabIndex = 0;
            labelBTree.Text = "B-Tree";
            labelBTree.Click += label1_Click;
            // 
            // BTreeInsert
            // 
            BTreeInsert.AutoSize = true;
            BTreeInsert.Location = new Point(151, 82);
            BTreeInsert.Name = "BTreeInsert";
            BTreeInsert.Size = new Size(38, 15);
            BTreeInsert.TabIndex = 1;
            BTreeInsert.Text = "label1";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTreeInsert);
            Controls.Add(labelBTree);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelBTree;
        private Label BTreeInsert;
    }
}