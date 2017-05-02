using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;



namespace ReadingFolder_App
{
    public partial class Form1 : Form
    {
        public Archive archive = new Archive();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog folder = new FolderBrowserDialog();
            //string path = string.Empty;

            //if (folder.ShowDialog() == DialogResult.OK)
            //{
            //    path = folder.SelectedPath;
            //}

            //DirectoryInfo dinfo = new DirectoryInfo(path);
            //foreach (FileInfo finfo in dinfo.GetFiles())
            //{
            //    archive.Extract(finfo);
            //    File.Delete(finfo.FullName);
            //}
            //archive.test();
            
            ReadFromFile read = new ReadFromFile();
            //read.ReadFeatures();
            read.ReadFeatures();
            read.Read_fileread();
            //read.test();

            //read.Insert_Features_Value();

        }
    }
}
