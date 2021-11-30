
namespace My_Rakhivnytsia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.параметриToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вхідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.реєстраціяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.балансToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додаванняТранзакціїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметриToolStripMenuItem,
            this.балансToolStripMenuItem,
            this.додаванняТранзакціїToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1178, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // параметриToolStripMenuItem
            // 
            this.параметриToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.параметриToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вхідToolStripMenuItem,
            this.реєстраціяToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.параметриToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan;
            this.параметриToolStripMenuItem.Name = "параметриToolStripMenuItem";
            this.параметриToolStripMenuItem.Size = new System.Drawing.Size(183, 42);
            this.параметриToolStripMenuItem.Text = "Параметри";
            // 
            // вхідToolStripMenuItem
            // 
            this.вхідToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.вхідToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan;
            this.вхідToolStripMenuItem.Name = "вхідToolStripMenuItem";
            this.вхідToolStripMenuItem.Size = new System.Drawing.Size(263, 46);
            this.вхідToolStripMenuItem.Text = "Вхід";
            this.вхідToolStripMenuItem.Click += new System.EventHandler(this.вхідToolStripMenuItem_Click);
            // 
            // реєстраціяToolStripMenuItem
            // 
            this.реєстраціяToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.реєстраціяToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan;
            this.реєстраціяToolStripMenuItem.Name = "реєстраціяToolStripMenuItem";
            this.реєстраціяToolStripMenuItem.Size = new System.Drawing.Size(263, 46);
            this.реєстраціяToolStripMenuItem.Text = "Реєстрація";
            this.реєстраціяToolStripMenuItem.Click += new System.EventHandler(this.реєстраціяToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.вихідToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan;
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(263, 46);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // балансToolStripMenuItem
            // 
            this.балансToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan;
            this.балансToolStripMenuItem.Name = "балансToolStripMenuItem";
            this.балансToolStripMenuItem.Size = new System.Drawing.Size(126, 42);
            this.балансToolStripMenuItem.Text = "Баланс";
            this.балансToolStripMenuItem.Click += new System.EventHandler(this.балансToolStripMenuItem_Click);
            // 
            // додаванняТранзакціїToolStripMenuItem
            // 
            this.додаванняТранзакціїToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan;
            this.додаванняТранзакціїToolStripMenuItem.Name = "додаванняТранзакціїToolStripMenuItem";
            this.додаванняТранзакціїToolStripMenuItem.Size = new System.Drawing.Size(323, 42);
            this.додаванняТранзакціїToolStripMenuItem.Text = "Додавання транзакції";
            this.додаванняТранзакціїToolStripMenuItem.Click += new System.EventHandler(this.додаванняТранзакціїToolStripMenuItem_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(13, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 684);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Моя Рахівниця";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem параметриToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вхідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem реєстраціяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem балансToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додаванняТранзакціїToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}

