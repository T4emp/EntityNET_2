using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityNET_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "localDbDataSet.Phone". При необходимости она может быть перемещена или удалена.
            this.phoneTableAdapter.Fill(this.localDbDataSet.Phone);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание объекта класса Phone
            Phone phone = new Phone();
            // Присваивание элемента к конкретному ТекстБоксу
            phone.number = textBox1.Text;
            phone.name = textBox2.Text;
            phone.@operator = textBox3.Text;
            // Создание объекта класса localdb
            localDbEntities localDbEntities = new localDbEntities();
            // Занесение полей в бд "Phone"
            localDbEntities.Phone.Add(phone);
            // Сохранение внесений
            localDbEntities.SaveChanges();
            //Очистка полей от данных
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            // Создание объекта класса List
            List<Phone> ListPhone = new List<Phone>();
            // Возврат объекта содержащий элементы из входной последовательности
            ListPhone = localDbEntities.Phone.ToList();
            // Возврат объекта содержащий данные в dataGridView1
            dataGridView1.DataSource = ListPhone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Phone phone = new Phone();
            phone.number = textBox1.Text;
            phone.name = textBox2.Text;
            phone.@operator = textBox3.Text;
            localDbEntities localDbEntities = new localDbEntities();
            localDbEntities.Phone.Remove(localDbEntities.Phone.Find(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
            localDbEntities.SaveChanges();

            List<Phone> ListPhone = new List<Phone>();
            ListPhone = localDbEntities.Phone.ToList();
            dataGridView1.DataSource = ListPhone;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            localDbEntities localDbEntities = new localDbEntities();
            Phone phone1 = localDbEntities.Phone.Find(dataGridView1.CurrentCell.Value);

            phone1.number = textBox1.Text;
            phone1.name = textBox2.Text;
            phone1.@operator = textBox3.Text;
            localDbEntities.SaveChanges();

            List<Phone> ListPhone = new List<Phone>();
            ListPhone = localDbEntities.Phone.ToList();
            dataGridView1.DataSource = ListPhone;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Phone phone = new Phone();
            localDbEntities localDbEntities = new localDbEntities();
            Phone phone1 = localDbEntities.Phone.Find(dataGridView1.CurrentCell.Value);

            textBox1.Text = phone1.number.ToString();
            textBox2.Text = phone1.name.ToString();
            textBox3.Text = phone1.@operator.ToString();

            phone.number = textBox1.Text;
            phone.name = textBox2.Text;
            phone.@operator = textBox3.Text;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
        }
    }
}
