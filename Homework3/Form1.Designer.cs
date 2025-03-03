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
            FactorialTextBox = new TextBox();
            CalculateButton = new Button();
            resultLabel = new Label();
            SuspendLayout();
            // 
            // FactorialTextBox
            // 
            FactorialTextBox.Location = new Point(165, 138);
            FactorialTextBox.Name = "FactorialTextBox";
            FactorialTextBox.Size = new Size(125, 27);
            FactorialTextBox.TabIndex = 0;
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(296, 138);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(94, 29);
            CalculateButton.TabIndex = 1;
            CalculateButton.Text = "Calculate";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(210, 178);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(0, 20);
            resultLabel.TabIndex = 2;
            resultLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 344);
            Controls.Add(resultLabel);
            Controls.Add(CalculateButton);
            Controls.Add(FactorialTextBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FactorialTextBox;
        private Button CalculateButton;
        private Label resultLabel;
    }
}
