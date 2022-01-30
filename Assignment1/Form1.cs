using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        List<Book> books = new List<Book>()
        {
            new Book("J.K. Rowling", "123423", 20, "Harry Poter"),
            new Book("Conan Doyle",  "232354", 10, "Sherlock"),
            new Book("Mayne Reid",   "654662", 15, "Headless Horseman")
            
        };
        List<Order> orders = new List<Order>();
        double subtotal = 0;
        public Form1()
        {
            
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            for (int i = 0; i<books.Count; i++)
                comboBox1.Items.Add(books[i].Title);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && int.Parse(textBox4.Text)>0)
                {
                    Order order = new Order(comboBox1.Text, double.Parse(textBox3.Text), int.Parse(textBox4.Text));
                    dataGridView1.Rows.Add(comboBox1.Text, textBox3.Text, textBox4.Text, double.Parse(textBox3.Text) * int.Parse(textBox4.Text));
                    subtotal += double.Parse(textBox3.Text) * int.Parse(textBox4.Text);
                    textBox5.Text = subtotal.ToString();
                    textBox6.Text = (subtotal / 10).ToString();
                    textBox7.Text = (subtotal + subtotal / 10).ToString();

                }
                else
                {
                    if (comboBox1.Text == "")
                    {
                        comboBox1.Focus();
                        MessageBox.Show("Please Add Book Title", "Information Is Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (int.Parse(textBox4.Text) <= 0)
                        throw new FormatException();
                }
            }
            catch (FormatException ex)
            {
                textBox4.Focus();
                MessageBox.Show("Enter a Valid Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book y = books.Where(x => x.Title == comboBox1.Text).FirstOrDefault();
            textBox1.Text = y.Author;
            textBox2.Text = y.ISBN;
            textBox3.Text = y.Price.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 1)
                MessageBox.Show("Add a Book", "No Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel order?", "Canceling Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    subtotal = 0;
                    dataGridView1.Rows.Clear();
                    textBox5.Text = subtotal.ToString();
                    textBox6.Text = subtotal.ToString();
                    textBox7.Text = subtotal.ToString();
                }
            }
        }
    }
}
