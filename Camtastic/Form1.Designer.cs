namespace Camtastic
{
    partial class MainScreen
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
            this.linkInput_textBox = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.exceptionsLabel = new System.Windows.Forms.Label();
            this.displayBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // linkInput_textBox
            // 
            this.linkInput_textBox.Location = new System.Drawing.Point(34, 49);
            this.linkInput_textBox.Name = "linkInput_textBox";
            this.linkInput_textBox.Size = new System.Drawing.Size(577, 22);
            this.linkInput_textBox.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(645, 49);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(175, 23);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.search_ClickEvent);
            // 
            // exceptionsLabel
            // 
            this.exceptionsLabel.AutoSize = true;
            this.exceptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exceptionsLabel.ForeColor = System.Drawing.Color.Red;
            this.exceptionsLabel.Location = new System.Drawing.Point(33, 85);
            this.exceptionsLabel.Name = "exceptionsLabel";
            this.exceptionsLabel.Size = new System.Drawing.Size(0, 29);
            this.exceptionsLabel.TabIndex = 2;
            // 
            // displayBox
            // 
            this.displayBox.Location = new System.Drawing.Point(34, 142);
            this.displayBox.Multiline = true;
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(786, 279);
            this.displayBox.TabIndex = 3;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(848, 461);
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.exceptionsLabel);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.linkInput_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainScreen";
            this.Text = "Camtastic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox linkInput_textBox;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label exceptionsLabel;
        private System.Windows.Forms.TextBox displayBox;
    }
}

