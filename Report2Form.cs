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
    public partial class Report2Form : Form
    {
        public Report2Form()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            string commandText = $"SELECT b.brigade_name, count(cr.brigade_id) FROM brigades b, car_repair cr " +
                $"WHERE cr.brigade_id = b.brigade_id AND cr.arrival_date > $1 " +
                $"GROUP BY b.brigade_name;";

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
