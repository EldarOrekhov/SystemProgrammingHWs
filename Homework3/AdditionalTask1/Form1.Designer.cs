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
            productsList = new ListBox();
            LoadButton = new Button();
            SuspendLayout();
            // 
            // productsList
            // 
            productsList.FormattingEnabled = true;
            productsList.Location = new Point(-1, -1);
            productsList.Name = "productsList";
            productsList.Size = new Size(213, 344);
            productsList.TabIndex = 0;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(262, 136);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(111, 29);
            LoadButton.TabIndex = 1;
            LoadButton.Text = "LoadProducts";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 344);
            Controls.Add(LoadButton);
            Controls.Add(productsList);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox productsList;
        private Button LoadButton;
    }
}
