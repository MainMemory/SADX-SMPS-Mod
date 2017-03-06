namespace SMPSConfigTool
{
	partial class MainForm
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(4, 1);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(18, 13);
			label1.TabIndex = 0;
			label1.Text = "ID";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(29, 1);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(49, 13);
			label2.TabIndex = 1;
			label2.Text = "Filename";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(85, 1);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(27, 13);
			label3.TabIndex = 2;
			label3.Text = "Title";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(119, 1);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(51, 13);
			label4.TabIndex = 3;
			label4.Text = "Selection";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(label4, 3, 0);
			this.tableLayoutPanel1.Controls.Add(label3, 2, 0);
			this.tableLayoutPanel1.Controls.Add(label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(175, 15);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(584, 562);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MainForm";
			this.Text = "SMPS Player Configuration";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}

