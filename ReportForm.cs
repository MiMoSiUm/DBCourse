using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourse
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            textBox1.PlaceholderText = "car_id";
            textBox2.PlaceholderText = "Результат";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int car_id = int.Parse(textBox1.Text);
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            string commandText = $"SELECT c.car_id, sum(sp.part_cost * sp.part_amount + f.work_cost) " +
            $"FROM spare_parts sp, car_repair cr, cars c, failures f WHERE " +
            $"sp.car_id = cr.car_id AND sp.failure_id = cr.failure_id AND " +
            $"sp.failure_id = f.failure_id AND sp.car_id = c.car_id AND c.car_id = $1 " +
            $"GROUP BY c.car_id;";

            await using var command = new NpgsqlCommand(commandText, connection)
            { Parameters = { new() { Value = car_id } } };

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                textBox2.AppendText(reader[1].ToString());
            }
        }
    }
}
