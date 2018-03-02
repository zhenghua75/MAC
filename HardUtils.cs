using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Management;
namespace WindowsApplication1
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 16);
			this.label1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(304, 40);
			this.label2.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.DarkOrange;
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(224, 32);
			this.label3.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(320, 150);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "系统测试";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new Form1());
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.GetInfo();
		}
		private void GetInfo()
		{
			string cpuInfo = "";//cpu序列号
			ManagementClass cimobject = new ManagementClass("Win32_Processor");
			ManagementObjectCollection moc = cimobject.GetInstances();
			foreach(ManagementObject mo in moc)
			{
				cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
				this.label1.Text="cpu序列号："+cpuInfo.ToString ();
			}
			//获取硬盘ID
			String HDid;
			ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
			ManagementObjectCollection moc1 = cimobject1.GetInstances();
			foreach(ManagementObject mo in moc1)
			{
				HDid = (string)mo.Properties["Model"].Value;
				this.label2.Text="硬盘序列号："+HDid.ToString ();
			}

			//获取网卡硬件地址    
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc2 = mc.GetInstances();
			string strTmp ="";
            int i = 0;
			foreach(ManagementObject mo in moc2)
			{
				
				if((bool)mo["IPEnabled"] == true)
					strTmp = strTmp + "MAC address\t{" + i.ToString() +"}"+mo["MacAddress"].ToString()+"\r\n";
				    i++;
				mo.Dispose();
			}
			this.label3.Text = strTmp;
		}
 

	}
}


