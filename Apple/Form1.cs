using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apple
{
    public partial class Form1 : Form
    {
        C_DataBase dataBase = new C_DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                string query = $"select * from Orders";
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                adapter.SelectCommand = command;

                adapter.Fill(table);

                dataGridView1.DataSource = table;
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            string customerName = textBoxCustomerName.Text;
            decimal quantity = decimal.Parse(textBoxQuantity.Text);
            DateTime date = dateTimePickerDate.Value;

            string query = $"INSERT INTO Orders (CustomerName, Quantity, Date) VALUES (@CustomerName, @Quantity, @Date)";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.Parameters.AddWithValue("@CustomerName", customerName);
            command.Parameters.AddWithValue("@Quantity", quantity);
            command.Parameters.AddWithValue("@Date", date);
            dataBase.openConnection();
            command.ExecuteNonQuery();

            MessageBox.Show("Заказ успешно добавлен.");

            ClearFields();
        }

        private void ClearFields()
        {
            textBoxCustomerName.Clear();
            textBoxQuantity.Clear();
            dateTimePickerDate.Value = DateTime.Now;
        }

    }
}