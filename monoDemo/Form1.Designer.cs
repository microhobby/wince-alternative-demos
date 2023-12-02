
namespace monoDemo
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableInfo = new System.Windows.Forms.TableLayoutPanel();
            this.labelTorizonVersion = new System.Windows.Forms.Label();
            this.labelFrameworkVersion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.labelHWInfo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(20, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 479);
            this.tabControl1.TabIndex = 0;
            //
            // tabPage1
            //
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 42);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Controls";
            this.tabPage1.UseVisualStyleBackColor = true;
            //
            // button1
            //
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Location = new System.Drawing.Point(25, 142);
            this.button1.Margin = new System.Windows.Forms.Padding(20);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(20);
            this.button1.Size = new System.Drawing.Size(603, 77);
            this.button1.TabIndex = 1;
            this.button1.Text = "LED TOGGLE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // pictureBox1
            //
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(3, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(20);
            this.pictureBox1.Size = new System.Drawing.Size(647, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 2;
            //
            // tabPage2
            //
            this.tabPage2.Controls.Add(this.tableInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "About";
            this.tabPage2.UseVisualStyleBackColor = true;
            //
            // tableInfo
            //
            this.tableInfo.ColumnCount = 2;
            this.tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.99382F));
            this.tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.00618F));
            this.tableInfo.Controls.Add(this.labelTorizonVersion, 1, 0);
            this.tableInfo.Controls.Add(this.pictureBox2, 0, 0);
            this.tableInfo.Controls.Add(this.pictureBox3, 0, 2);
            this.tableInfo.Controls.Add(this.labelFrameworkVersion, 1, 2);
            this.tableInfo.Controls.Add(this.pictureBox4, 0, 1);
            this.tableInfo.Controls.Add(this.labelHWInfo, 1, 1);
            this.tableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableInfo.Location = new System.Drawing.Point(3, 3);
            this.tableInfo.Name = "tableInfo";
            this.tableInfo.RowCount = 3;
            this.tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.38173F));
            this.tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.72365F));
            this.tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.71545F));
            this.tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableInfo.Size = new System.Drawing.Size(647, 427);
            this.tableInfo.TabIndex = 0;
            //
            // labelTorizonVersion
            //
            this.labelTorizonVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTorizonVersion.AutoSize = true;
            this.labelTorizonVersion.Location = new System.Drawing.Point(370, 50);
            this.labelTorizonVersion.Name = "labelTorizonVersion";
            this.labelTorizonVersion.Size = new System.Drawing.Size(113, 33);
            this.labelTorizonVersion.TabIndex = 0;
            this.labelTorizonVersion.Text = "Torizon";
            this.labelTorizonVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // labelFrameworkVersion
            //
            this.labelFrameworkVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFrameworkVersion.AutoSize = true;
            this.labelFrameworkVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelFrameworkVersion.Location = new System.Drawing.Point(346, 336);
            this.labelFrameworkVersion.Name = "labelFrameworkVersion";
            this.labelFrameworkVersion.Size = new System.Drawing.Size(162, 33);
            this.labelFrameworkVersion.TabIndex = 1;
            this.labelFrameworkVersion.Text = "Framework";
            this.labelFrameworkVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // pictureBox2
            //
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Location = new System.Drawing.Point(39, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(129, 117);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            //
            // pictureBox3
            //
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(54, 288);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(98, 129);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            //
            // pictureBox4
            //
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox4.Location = new System.Drawing.Point(51, 160);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(105, 91);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            //
            // labelHWInfo
            //
            this.labelHWInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHWInfo.AutoSize = true;
            this.labelHWInfo.BackColor = System.Drawing.Color.LightGray;
            this.labelHWInfo.Location = new System.Drawing.Point(328, 189);
            this.labelHWInfo.Name = "labelHWInfo";
            this.labelHWInfo.Size = new System.Drawing.Size(197, 33);
            this.labelHWInfo.TabIndex = 5;
            this.labelHWInfo.Text = "Hardware Info";
            this.labelHWInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 479);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableInfo.ResumeLayout(false);
            this.tableInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableInfo;
        private System.Windows.Forms.Label labelTorizonVersion;
        private System.Windows.Forms.Label labelFrameworkVersion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label labelHWInfo;
    }
}

