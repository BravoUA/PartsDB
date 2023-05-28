using PartsDB.Models;
using System.IO;

namespace PartsDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbConnect dbConnect = new dbConnect();
        List<Categor> categors = new List<Categor>();
        Parts parts ;
        private void Form1_Load(object sender, EventArgs e)
        {


            categors = dbConnect.Categor.ToList();
            comboBox1.DataSource = categors;
            comboBox1.DisplayMember = "NameCat";
            //parts = dbConnect.Parts.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parts = new Parts() { NamberPart = textBox1.Text, idCategory = (comboBox1.SelectedIndex+1) };

            dbConnect.Parts.Add(parts);

            dbConnect.SaveChanges();
            textBox1.Text = "";
            textBox2.Text = "";
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            string NameCategory = "";
            NameCategory = Prompt.ShowDialog("Імя Категорії", "Створити нову категорію");
            Categor C = new Categor();
            C.NameCat = NameCategory;
            dbConnect.Categor.Add(C);
            dbConnect.SaveChanges();
            categors = dbConnect.Categor.ToList();
            comboBox1.DataSource = categors;
            comboBox1.DisplayMember = "NameCat";
        }
    }
}
public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 500,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };
        Label textLabel = new Label() { Left = 200, Top = 15, Text = text };
        TextBox textBox = new TextBox() { Left = 40, Top = 45, Width = 400 };
        Button confirmation = new Button() { Text = "Ok", Left = 200, Width = 100, Top = 80, DialogResult = DialogResult.OK };
        confirmation.Click += (sender, e) => { prompt.Close(); };
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(textLabel);
        prompt.AcceptButton = confirmation;

        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
    }
}