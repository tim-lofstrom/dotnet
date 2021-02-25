using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flashback
{
    public partial class Form1 : Form
    {
        List<Person> personer = new List<Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
            personer.Add(new Person("Kurt", 175));
            personer.Add(new Person("kvickenbjulle", 210));
            personer.Add(new Person("FB-dase", 25));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            personer.Add(new Person(textBox_name.Text, int.Parse(textBox_length.Text)));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }

    class Person
    {
        String name;
        int length;

        public Person(String name, int length)
        {
            this.name = name;
            this.length = length;
        }

        public String getName()
        {
            return name;
        }

        public int getLength()
        {
            return length;
        }

    }
}
