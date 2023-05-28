using Microsoft.EntityFrameworkCore;
using PartsDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartsDB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        dbConnect dbConnect = new dbConnect();
        List<Parts> Parts = new List<Parts>();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

            Parts = dbConnect.Parts.ToList();
            Parts.RemoveAt(0);
            listBox1.DataSource = Parts;
            listBox1.DisplayMember = "NamberPart";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Parts> parts = new List<Parts>();

             Parts = dbConnect.Parts.ToList();
            foreach (var item in Parts)
            {
                if (item.NamberPart.Contains(textBox1.Text.ToString()))
                {
                    parts.Add(item);
                }
                
            }
           
            
            listBox1.DataSource = parts;
            listBox1.DisplayMember = "NamberPart";
        }
    }
}
