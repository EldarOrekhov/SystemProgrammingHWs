namespace WinFormsApp1
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
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            progressBar3 = new ProgressBar();
            progressBar4 = new ProgressBar();
            progressBar5 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            StartButton = new Button();
            ResultsListBox = new ListBox();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(81, 22);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(501, 29);
            progressBar1.TabIndex = 0;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(81, 57);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(501, 29);
            progressBar2.TabIndex = 1;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(81, 92);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(501, 29);
            progressBar3.TabIndex = 2;
            // 
            // progressBar4
            // 
            progressBar4.Location = new Point(81, 127);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new Size(501, 29);
            progressBar4.TabIndex = 3;
            // 
            // progressBar5
            // 
            progressBar5.Location = new Point(81, 162);
            progressBar5.Name = "progressBar5";
            progressBar5.Size = new Size(501, 29);
            progressBar5.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 5;
            label1.Text = "Horse 1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 162);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 6;
            label2.Text = "Horse 5:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 127);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 7;
            label3.Text = "Horse 4:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 92);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 8;
            label4.Text = "Horse 3:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 57);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 9;
            label5.Text = "Horse 2:";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(244, 226);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(113, 33);
            StartButton.TabIndex = 10;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // ResultsListBox
            // 
            ResultsListBox.FormattingEnabled = true;
            ResultsListBox.Location = new Point(12, 295);
            ResultsListBox.Name = "ResultsListBox";
            ResultsListBox.Size = new Size(570, 224);
            ResultsListBox.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 531);
            Controls.Add(ResultsListBox);
            Controls.Add(StartButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar5);
            Controls.Add(progressBar4);
            Controls.Add(progressBar3);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;
        private ProgressBar progressBar4;
        private ProgressBar progressBar5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button StartButton;
        private ListBox ResultsListBox;
    }
}
