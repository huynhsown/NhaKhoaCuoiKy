namespace NhaKhoaCuoiKy.Views
{
    partial class AddNewRecord
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btn_back = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // btn_back
            // 
            btn_back.BorderRadius = 5;
            btn_back.CustomizableEdges = customizableEdges1;
            btn_back.DisabledState.BorderColor = Color.DarkGray;
            btn_back.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_back.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_back.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_back.FillColor = Color.FromArgb(17, 34, 71);
            btn_back.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_back.ForeColor = Color.White;
            btn_back.ImageAlign = HorizontalAlignment.Left;
            btn_back.Location = new Point(12, 12);
            btn_back.Name = "btn_back";
            btn_back.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_back.Size = new Size(100, 36);
            btn_back.TabIndex = 3;
            btn_back.Text = "Trở lại";
            btn_back.Click += btn_back_Click;
            // 
            // AddNewRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1214, 806);
            Controls.Add(btn_back);
            Name = "AddNewRecord";
            Text = "AddNewRecord";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_back;
    }
}