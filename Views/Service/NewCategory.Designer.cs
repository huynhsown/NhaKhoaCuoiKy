namespace NhaKhoaCuoiKy.Views.Service
{
    partial class NewCategory
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tb_category = new Guna.UI2.WinForms.Guna2TextBox();
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            btn_cancel = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // tb_category
            // 
            tb_category.CustomizableEdges = customizableEdges7;
            tb_category.DefaultText = "";
            tb_category.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_category.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_category.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_category.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_category.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_category.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tb_category.ForeColor = Color.Black;
            tb_category.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_category.Location = new Point(91, 58);
            tb_category.Name = "tb_category";
            tb_category.PasswordChar = '\0';
            tb_category.PlaceholderForeColor = Color.Gray;
            tb_category.PlaceholderText = "Nhập loại dịch vụ";
            tb_category.SelectedText = "";
            tb_category.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tb_category.Size = new Size(328, 36);
            tb_category.TabIndex = 0;
            // 
            // btn_add
            // 
            btn_add.BorderRadius = 15;
            btn_add.CustomizableEdges = customizableEdges9;
            btn_add.DisabledState.BorderColor = Color.DarkGray;
            btn_add.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_add.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_add.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_add.FillColor = Color.FromArgb(17, 34, 71);
            btn_add.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_add.ForeColor = Color.White;
            btn_add.Image = Properties.Resources.icons8_add_new_64;
            btn_add.ImageAlign = HorizontalAlignment.Left;
            btn_add.Location = new Point(289, 125);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btn_add.Size = new Size(130, 36);
            btn_add.TabIndex = 1;
            btn_add.Text = "Thêm";
            btn_add.Click += btn_add_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.BorderColor = Color.FromArgb(17, 34, 71);
            btn_cancel.BorderRadius = 15;
            btn_cancel.BorderThickness = 1;
            btn_cancel.CustomizableEdges = customizableEdges11;
            btn_cancel.DisabledState.BorderColor = Color.DarkGray;
            btn_cancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_cancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_cancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_cancel.FillColor = Color.White;
            btn_cancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_cancel.ForeColor = Color.Black;
            btn_cancel.Image = Properties.Resources.icons8_add_new_64;
            btn_cancel.ImageAlign = HorizontalAlignment.Left;
            btn_cancel.Location = new Point(91, 125);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btn_cancel.Size = new Size(130, 36);
            btn_cancel.TabIndex = 2;
            btn_cancel.Text = "Hủy";
            btn_cancel.Click += btn_cancel_Click;
            // 
            // NewCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(523, 200);
            Controls.Add(btn_cancel);
            Controls.Add(btn_add);
            Controls.Add(tb_category);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewCategory";
            Load += NewCategory_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tb_category;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2Button btn_cancel;
    }
}