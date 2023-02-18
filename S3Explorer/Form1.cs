using Amazon.S3.Model;
using AmazonS3Lib;
using ExpTreeLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace S3Explorer
{
	public partial class Form1 : Form
	{
		private S3 s3;
		private string syncDir = @"D:\awsdoki";
		public Form1()
		{
			InitializeComponent();
			this.Load += Form1_Load;
			listView1.ItemActivate += ListView1_ItemActivate;
			

		}

		private void Form1_Load(object sender, EventArgs e) {
			s3 = new S3(ConfigurationManager.AppSettings["aws_access_key_id"],
						ConfigurationManager.AppSettings["aws_secret_access_key"],
						"rdstest123456",
						syncDir);
			s3.Sync();

			this.expTree.ExpTreeNodeSelected +=
				new ExpTreeLib.ExpTree.ExpTreeNodeSelectedEventHandler(this.expTree1_ExpTreeNodeSelected);

			expTree.StartUpDirectory = ExpTree.StartDir.Desktop;
			expTree.ExpandANode(syncDir);


		}

		private void expTree1_ExpTreeNodeSelected(string SelPath, CShItem CSI)
		{
			listView1.View = View.Details;
			listView1.Clear();
			listView1.Columns.Add("名前");
			listView1.Columns.Add("種類");
			listView1.Columns.Add("更新日時");
			listView1.Columns.Add("サイズ");

			try
			{
				// フォルダをリストに追加
				DirectoryInfo dirInfo = new DirectoryInfo(SelPath);

				foreach (DirectoryInfo di in dirInfo.GetDirectories())
				{
					ListViewItem item = new ListViewItem(di.Name, 1);

					// Set a default icon for the file.
					Icon iconForFile = SystemIcons.WinLogo;

					// Check to see if the image collection contains an image
					// for this extension, using the extension as a key.
					if (!imageList1.Images.ContainsKey("directory"))
					{
						// If not, add the image to the image list.
						//iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(di.FullName);
						imageList1.Images.Add("directory", iconForFile.ToBitmap());
					}

					// 各列の内容を設定
					item.ImageKey = "directory";
					item.SubItems.Add("フォルダ");
					item.SubItems.Add(String.Format("{0:yyyy/MM/dd HH:mm:ss}", di.LastAccessTime));
					item.SubItems.Add("");

					// リストに追加
					listView1.Items.Add(item);
				}

				// ファイルをリスト追加
				List<String> fileList = Directory.GetFiles(SelPath).ToList<String>();

				foreach (String file in fileList)
				{
					FileInfo fileInfo = new FileInfo(file);
					ListViewItem item = new ListViewItem(fileInfo.Name, 1);

					// Set a default icon for the file.
					Icon iconForFile = SystemIcons.WinLogo;

					// Check to see if the image collection contains an image
					// for this extension, using the extension as a key.
					if (!imageList1.Images.ContainsKey(fileInfo.Extension))
					{
						// If not, add the image to the image list.
						iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
						
						imageList1.Images.Add(fileInfo.Extension, iconForFile.ToBitmap());

					}
					item.ImageKey = fileInfo.Extension;
					item.SubItems.Add(fileInfo.Extension + " ファイル");
					item.SubItems.Add(String.Format("{0:yyyy/MM/dd HH:mm:ss}", fileInfo.LastAccessTime));
					item.SubItems.Add(getFileSize(fileInfo.Length));


					listView1.Items.Add(item);

				}
			}
			catch (Exception e)
			{
			}

			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

		}

		private String getFileSize(long fileSize) {
			String ret = fileSize + " バイト";
			if (fileSize > (1024f * 1024f * 1024f))
			{
				ret = Math.Round((fileSize / 1024f / 1024f / 1024f), 2).ToString() + " GB";
			}
			else if (fileSize > (1024f * 1024f))
			{
				ret = Math.Round((fileSize / 1024f / 1024f), 2).ToString() + " MB";
			}
			else if (fileSize > 1024f)
			{
				ret = Math.Round((fileSize / 1024f)).ToString() + " KB";
			}

			return ret;
		}

		private void ListView1_ItemActivate(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			List<S3ObjectVersion> li= new List<S3ObjectVersion>();
			//フォーカスのあるアイテムのTextを表示する
			string key = lv.FocusedItem.Text;
			li = s3.getFileList();
			List<S3ObjectVersion> l = s3.getVersions(key, li);
			versionView(l);
		}

		private void versionView(List<S3ObjectVersion> s3ObjectVersions) {
			listView2.View = View.Details;
			listView2.FullRowSelect = true;
            listView2.GridLines = true;
			listView2.MultiSelect = false;
			listView2.Clear();
			listView2.Columns.Add("バージョンID");
			listView2.Columns.Add("更新日時");
			listView2.Columns.Add("Key");


			foreach (S3ObjectVersion s in s3ObjectVersions)
			{
				if (s.VersionId == "null") { continue; }
				ListViewItem item = new ListViewItem(s.VersionId);
				item.SubItems.Add(String.Format("{0:yyyy/MM/dd HH:mm:ss}", s.LastModified));
				item.SubItems.Add(s.Key);

				listView2.Items.Add(item);
			}

			listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void mnuDownloadThisVersion_Click(object sender, EventArgs e)
		{	
			if (listView2.SelectedItems.Count > 0) {
				ListViewItem item = listView2.SelectedItems[0];
				s3.download(item.SubItems[2].Text, @"D:\"+ item.SubItems[2].Text, item.SubItems[0].Text);
			}
		}
	}
}
