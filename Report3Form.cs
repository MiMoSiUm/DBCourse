using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourse
{
    public partial class Report3Form : Form
    {
        public Report3Form()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            string commandText = $"SELECT w.workshop_name, sum(sp.part_cost * sp.part_amount + f.work_cost) " +
                $"FROM spare_parts sp, car_repair cr, cars c, failures f, workshops w, personnel p WHERE " +
                $"sp.car_id = cr.car_id AND sp.failure_id = cr.failure_id AND " +
                $"sp.failure_id = f.failure_id AND sp.car_id = c.car_id AND cr.brigade_id = p.brigade_id AND " +
                $"p.workshop_id = w.workshop_id AND cr.arrival_date > $1 " +
                $"GROUP BY w.workshop_name;";

            await using var command = new NpgsqlCommand(commandText, connection)
            { Parameters = { new() { Value = date } } };

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                textBox1.AppendText(reader[0].ToString() + " " + reader[1].ToString() + Environment.NewLine);
            }
        }
    }
}
