namespace S3Explorer
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.listView1 = new System.Windows.Forms.ListView();
			this.expTree = new ExpTreeLib.ExpTree();
			this.listView2 = new System.Windows.Forms.ListView();
			this.mnuVersion = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuDownloadThisVersion = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.mnuVersion.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetting});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuSetting
			// 
			this.mnuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFolder});
			this.mnuSetting.Name = "mnuSetting";
			this.mnuSetting.Size = new System.Drawing.Size(43, 20);
			this.mnuSetting.Text = "設定";
			// 
			// mnuFolder
			// 
			this.mnuFolder.Name = "mnuFolder";
			this.mnuFolder.Size = new System.Drawing.Size(109, 22);
			this.mnuFolder.Text = "フォルダ";
			// 
			// listView1
			// 
			this.listView1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(233, 27);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(555, 315);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// expTree
			// 
			this.expTree.AllowFolderRename = false;
			this.expTree.Cursor = System.Windows.Forms.Cursors.Default;
			this.expTree.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.expTree.Location = new System.Drawing.Point(12, 27);
			this.expTree.Name = "expTree";
			this.expTree.ShowRootLines = false;
			this.expTree.Size = new System.Drawing.Size(215, 411);
			this.expTree.StartUpDirectory = ExpTreeLib.ExpTree.StartDir.Desktop;
			this.expTree.TabIndex = 0;
			// 
			// listView2
			// 
			this.listView2.ContextMenuStrip = this.mnuVersion;
			this.listView2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(233, 348);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(555, 90);
			this.listView2.TabIndex = 3;
			this.listView2.UseCompatibleStateImageBehavior = false;
			// 
			// mnuVersion
			// 
			this.mnuVersion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDownloadThisVersion});
			this.mnuVersion.Name = "mnuVersion";
			this.mnuVersion.Size = new System.Drawing.Size(170, 26);
			// 
			// mnuDownloadThisVersion
			// 
			this.mnuDownloadThisVersion.Name = "mnuDownloadThisVersion";
			this.mnuDownloadThisVersion.Size = new System.Drawing.Size(180, 22);
			this.mnuDownloadThisVersion.Text = "このバージョンを取得";
			this.mnuDownloadThisVersion.Click += new System.EventHandler(this.mnuDownloadThisVersion_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listView2);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.expTree);
			this.Controls.Add(this.menuStrip1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.mnuVersion.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuSetting;
		private System.Windows.Forms.ToolStripMenuItem mnuFolder;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView listView1;
		private ExpTreeLib.ExpTree expTree;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ContextMenuStrip mnuVersion;
		private System.Windows.Forms.ToolStripMenuItem mnuDownloadThisVersion;
	}
}

