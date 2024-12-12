using Npgsql;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DBCourse
{
    public partial class Form1 : Form
    {
        public static readonly string connectionString = "Host=192.168.1.119;Username=postgres;Password=postgres;Database=course work";
        List<Brigades> brigades = new List<Brigades>();
        List<Car_repair> car_repair = new List<Car_repair>();
        List<Cars> cars = new List<Cars>();
        List<Failures> failures = new List<Failures>();
        List<Personnel> personnel = new List<Personnel>();
        List<Spare_parts> spare_parts = new List<Spare_parts>();
        List<Workshops> workshops = new List<Workshops>();
        Tables current_table = Tables.None;
        public Form1()
        {
            InitializeComponent();
        }
        async Task FillBrigadesList()
        {
            brigades.Clear();
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using var command = dataSource.CreateCommand("SELECT * FROM brigades");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                brigades.Add(new Brigades(reader.GetString(0), reader.GetInt32(1)));
            }
        }
        async Task FillCar_repairList()
        {
            car_repair.Clear();
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using var command = dataSource.CreateCommand("SELECT * FROM car_repair");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                car_repair.Add(new Car_repair ( 
                    reader.GetInt32(0), 
                    reader.GetInt32(1),
                    reader.GetDateTime(2),
                    reader.GetDateTime(3),
                    reader.GetInt32(4)
                ));
            }
        }
        async Task FillCarsList()
        {
            cars.Clear();
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using var command = dataSource.CreateCommand("SELECT * FROM cars");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                cars.Add(new Cars (
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt32(4)
                ));
            }
        }
        async Task FillFailuresList()
        {
            failures.Clear();
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using var command = dataSource.CreateCommand("SELECT * FROM failures");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                failures.Add(new Failures
                (
                    reader.GetString(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2)
                ));
            }
        }
        async Task FillPersonnelList()
        {
            personnel.Clear();
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using var command = dataSource.CreateCommand("SELECT * FROM personnel");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                personnel.Add(new Personnel (
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2)
                ));
            }
        }
        async Task FillSpare_partsList()
        {
            spare_parts.Clear();
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using var command = dataSource.CreateCommand("SELECT * FROM spare_parts");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                spare_parts.Add(new Spare_parts (
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetInt32(4)
                ));
            }
        }
        async Task FillWorkshopsList()
        {
            workshops.Clear();
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using var command = dataSource.CreateCommand("SELECT * FROM workshops");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                workshops.Add(new Workshops (reader.GetString(0), reader.GetInt32(1)));
            }
        }

        async private void button1_Click(object sender, EventArgs e) // brigades
        {
            current_table = Tables.Brigades;
            await FillBrigadesList();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = Brigades.Columns.Count + 2;
            tableLayoutPanel1.RowCount = 0;

            BlankRowAdd();

            for (int i = 0; i < Brigades.Columns.Count; ++i)
                tableLayoutPanel1.Controls.Add(new Label() { Text = Brigades.Columns[i] });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

            for (int i = 0; i < brigades.Count; ++i)
            {
                tableLayoutPanel1.Controls.Add(brigades[i].brigade_name_tb);
                tableLayoutPanel1.Controls.Add(brigades[i].brigade_id_tb);
                tableLayoutPanel1.Controls.Add(brigades[i].updateButton);
                tableLayoutPanel1.Controls.Add(brigades[i].deleteButton);
            }

            TableEven();
            FilterTableAdd();
        }

        async private void button2_Click(object sender, EventArgs e) // car_repair
        {
            current_table = Tables.Car_repair;
            await FillCar_repairList();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = Car_repair.Columns.Count + 2;
            tableLayoutPanel1.RowCount = 0;

            BlankRowAdd();

            for (int i = 0; i < Car_repair.Columns.Count; ++i)
                tableLayoutPanel1.Controls.Add(new Label() { Text = Car_repair.Columns[i] });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

            for (int i = 0; i < car_repair.Count; ++i)
            {
                tableLayoutPanel1.Controls.Add(car_repair[i].car_id_tb);
                tableLayoutPanel1.Controls.Add(car_repair[i].failure_id_tb);
                tableLayoutPanel1.Controls.Add(car_repair[i].arrival_date_tb);
                tableLayoutPanel1.Controls.Add(car_repair[i].leaving_date_tb);
                tableLayoutPanel1.Controls.Add(car_repair[i].brigade_id_tb);
                tableLayoutPanel1.Controls.Add(car_repair[i].updateButton);
                tableLayoutPanel1.Controls.Add(car_repair[i].deleteButton);
            }

            TableEven();
            FilterTableAdd();
        }

        async private void button3_Click(object sender, EventArgs e) // cars
        {
            current_table = Tables.Cars;
            await FillCarsList();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = Cars.Columns.Count + 2;
            tableLayoutPanel1.RowCount = 0;

            BlankRowAdd();

            for (int i = 0; i < Cars.Columns.Count; ++i)
                tableLayoutPanel1.Controls.Add(new Label() { Text = Cars.Columns[i] });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

            for (int i = 0; i < cars.Count; ++i)
            {
                tableLayoutPanel1.Controls.Add(cars[i].car_body_number_tb);
                tableLayoutPanel1.Controls.Add(cars[i].car_engine_number_tb);
                tableLayoutPanel1.Controls.Add(cars[i].car_owner_tb);
                tableLayoutPanel1.Controls.Add(cars[i].car_vin_tb);
                tableLayoutPanel1.Controls.Add(cars[i].car_id_tb);
                tableLayoutPanel1.Controls.Add(cars[i].updateButton);
                tableLayoutPanel1.Controls.Add(cars[i].deleteButton);
            }

            TableEven();
            FilterTableAdd();
        }

        async private void button4_Click(object sender, EventArgs e) // failures
        {
            current_table = Tables.Failures;
            await FillFailuresList();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = Failures.Columns.Count + 2;
            tableLayoutPanel1.RowCount = 0;

            BlankRowAdd();

            for (int i = 0; i < Failures.Columns.Count; ++i)
                tableLayoutPanel1.Controls.Add(new Label() { Text = Failures.Columns[i] });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

            for (int i = 0; i < failures.Count; ++i)
            {
                tableLayoutPanel1.Controls.Add(failures[i].failure_name_tb);
                tableLayoutPanel1.Controls.Add(failures[i].work_cost_tb);
                tableLayoutPanel1.Controls.Add(failures[i].failure_id_tb);
                tableLayoutPanel1.Controls.Add(failures[i].updateButton);
                tableLayoutPanel1.Controls.Add(failures[i].deleteButton);
            }

            TableEven();
            FilterTableAdd();
        }

        async private void button5_Click(object sender, EventArgs e) // personnel
        {
            current_table = Tables.Personnel;
            await FillPersonnelList();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = Personnel.Columns.Count + 2;
            tableLayoutPanel1.RowCount = 0;

            BlankRowAdd();

            for (int i = 0; i < Personnel.Columns.Count; ++i)
                tableLayoutPanel1.Controls.Add(new Label() { Text = Personnel.Columns[i] });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

            for (int i = 0; i < personnel.Count; ++i)
            {
                tableLayoutPanel1.Controls.Add(personnel[i].workshop_id_tb);
                tableLayoutPanel1.Controls.Add(personnel[i].person_inn_tb);
                tableLayoutPanel1.Controls.Add(personnel[i].brigade_id_tb);
                tableLayoutPanel1.Controls.Add(personnel[i].updateButton);
                tableLayoutPanel1.Controls.Add(personnel[i].deleteButton);
            }

            TableEven();
            FilterTableAdd();
        }

        async private void button6_Click(object sender, EventArgs e) // spare_parts
        {
            current_table = Tables.Spare_parts;
            await FillSpare_partsList();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = Spare_parts.Columns.Count + 2;
            tableLayoutPanel1.RowCount = 0;

            BlankRowAdd();

            for (int i = 0; i < Spare_parts.Columns.Count; ++i)
                tableLayoutPanel1.Controls.Add(new Label() { Text = Spare_parts.Columns[i] });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

            for (int i = 0; i < spare_parts.Count; ++i)
            {
                tableLayoutPanel1.Controls.Add(spare_parts[i].car_id_tb);
                tableLayoutPanel1.Controls.Add(spare_parts[i].failure_id_tb);
                tableLayoutPanel1.Controls.Add(spare_parts[i].part_name_tb);
                tableLayoutPanel1.Controls.Add(spare_parts[i].part_cost_tb);
                tableLayoutPanel1.Controls.Add(spare_parts[i].part_amount_tb);
                tableLayoutPanel1.Controls.Add(spare_parts[i].updateButton);
                tableLayoutPanel1.Controls.Add(spare_parts[i].deleteButton);
            }

            TableEven();
            FilterTableAdd();
        }

        async private void button7_Click(object sender, EventArgs e) // workshops
        {
            current_table = Tables.Workshops;
            await FillWorkshopsList();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = Workshops.Columns.Count + 2;
            tableLayoutPanel1.RowCount = 0;

            BlankRowAdd();

            for (int i = 0; i < Workshops.Columns.Count; ++i)
                tableLayoutPanel1.Controls.Add(new Label() { Text = Workshops.Columns[i] });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

            for (int i = 0; i < workshops.Count; ++i)
            {
                tableLayoutPanel1.Controls.Add(workshops[i].workshop_name_tb);
                tableLayoutPanel1.Controls.Add(workshops[i].workshop_id_tb);
                tableLayoutPanel1.Controls.Add(workshops[i].updateButton);
                tableLayoutPanel1.Controls.Add(workshops[i].deleteButton);
            }

            TableEven();
            FilterTableAdd();
        }

        async private void Add_row_click(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            string tableName = "";
            List<string> cols = new List<string>();
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            List<string> placeholders = new List<string>();

            switch (current_table)
            {
                case Tables.Brigades:
                    tableName = Brigades.Name;

                    if (tableLayoutPanel1.Controls[0].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[0].Text });

                    if (tableLayoutPanel1.Controls[1].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[1].Text) });

                    for (int i = 0; i < Brigades.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Brigades.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Car_repair:
                    tableName = Car_repair.Name;

                    if (tableLayoutPanel1.Controls[0].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[0].Text) });

                    if (tableLayoutPanel1.Controls[1].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[1].Text) });

                    if (tableLayoutPanel1.Controls[2].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = DateTime.Parse(tableLayoutPanel1.Controls[2].Text) });

                    if (tableLayoutPanel1.Controls[3].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = DateTime.Parse(tableLayoutPanel1.Controls[3].Text) });

                    if (tableLayoutPanel1.Controls[4].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[4].Text) });

                    for (int i = 0; i < Car_repair.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Car_repair.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Cars:
                    tableName = Cars.Name;

                    if (tableLayoutPanel1.Controls[0].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[0].Text });

                    if (tableLayoutPanel1.Controls[1].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[1].Text });

                    if (tableLayoutPanel1.Controls[2].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[2].Text });

                    if (tableLayoutPanel1.Controls[3].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[3].Text });

                    if (tableLayoutPanel1.Controls[4].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[4].Text) });

                    for (int i = 0; i < Cars.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Cars.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Failures:
                    tableName = Failures.Name;

                    if (tableLayoutPanel1.Controls[0].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[0].Text });

                    if (tableLayoutPanel1.Controls[1].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[1].Text) });

                    if (tableLayoutPanel1.Controls[2].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[2].Text) });

                    for (int i = 0; i < Failures.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Failures.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Personnel:
                    tableName = Personnel.Name;


                    if (tableLayoutPanel1.Controls[0].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[0].Text) });

                    if (tableLayoutPanel1.Controls[1].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[1].Text });

                    if (tableLayoutPanel1.Controls[2].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[2].Text) });

                    for (int i = 0; i < Personnel.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Personnel.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Spare_parts:
                    tableName = Spare_parts.Name;

                    if (tableLayoutPanel1.Controls[0].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[0].Text) });

                    if (tableLayoutPanel1.Controls[1].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[1].Text) });

                    if (tableLayoutPanel1.Controls[2].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[2].Text });

                    if (tableLayoutPanel1.Controls[3].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[3].Text) });

                    if (tableLayoutPanel1.Controls[4].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[4].Text) });

                    for (int i = 0; i < Spare_parts.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Spare_parts.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Workshops:
                    tableName = Workshops.Name;

                    if (tableLayoutPanel1.Controls[0].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = tableLayoutPanel1.Controls[0].Text });

                    if (tableLayoutPanel1.Controls[1].Text != "")
                        parameters.Add(new NpgsqlParameter { Value = int.Parse(tableLayoutPanel1.Controls[1].Text) });

                    for (int i = 0; i < Workshops.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Workshops.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                default:
                    break;
            }

            await using var command = new NpgsqlCommand($"INSERT INTO {tableName} ({string.Join(",", cols)})" +
                $"VALUES ({string.Join(",", placeholders)})", connection);
            command.Parameters.AddRange(parameters.ToArray());

            await command.ExecuteNonQueryAsync();
        }
        void BlankRowAdd()
        {
            for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                tableLayoutPanel1.Controls.Add(new TextBox());

            Button addButton = new Button();
            addButton.Text = "Добавить";
            addButton.Click += (sender, args) => Add_row_click(sender, args);
            tableLayoutPanel1.Controls.Add(addButton);
            tableLayoutPanel1.Controls.Add(new Label { Text = " "});
        }
        void TableEven()
        {
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; ++i)
            {
                tableLayoutPanel1.Controls.Add(new Label());
            }

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; ++i)
            {
                tableLayoutPanel1.Controls[i].Width = ((this.Width - 100) / tableLayoutPanel1.ColumnCount);
                tableLayoutPanel1.Controls[i].Dock = DockStyle.Fill;
            }
        }
        void FilterTableAdd()
        {
            FilterTable.Controls.Clear();
            if (FilterTable.Controls.Count == 0)
            {
                switch (current_table)
                {
                    case Tables.Brigades:
                        FilterTable.ColumnCount = Brigades.Columns.Count + 2;
                        break;
                    case Tables.Car_repair:
                        FilterTable.ColumnCount = Car_repair.Columns.Count + 2;
                        break;
                    case Tables.Cars:
                        FilterTable.ColumnCount = Cars.Columns.Count + 2;
                        break;
                    case Tables.Failures:
                        FilterTable.ColumnCount = Failures.Columns.Count + 2;
                        break;
                    case Tables.Personnel:
                        FilterTable.ColumnCount = Personnel.Columns.Count + 2;
                        break;
                    case Tables.Spare_parts:
                        FilterTable.ColumnCount = Spare_parts.Columns.Count + 2;
                        break;
                    case Tables.Workshops:
                        FilterTable.ColumnCount = Workshops.Columns.Count + 2;
                        break;

                    default:
                        break;
                }
            }
            for (int i = 0; i < FilterTable.ColumnCount - 2; ++i)
                FilterTable.Controls.Add(new TextBox());
            Button FindButton = new Button() { Text = "Найти" };
            FindButton.Click += (sender, args) => Update(sender, args);
            FilterTable.Controls.Add(FindButton);
            FilterTable.Controls.Add(new Label());
            for (int i = 0; i < FilterTable.Controls.Count; ++i)
            {
                FilterTable.Controls[i].Width = ((this.Width - 100) / tableLayoutPanel1.ColumnCount);
                FilterTable.Controls[i].Dock = DockStyle.Fill;
            }
        }
        async Task Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            List<string> expressions = new List<string>();
            string tableName = "";
            switch (current_table)
            {
                case Tables.Brigades:
                    tableName = Brigades.Name;
                    for (int i = 0; i < FilterTable.Controls.Count; ++i)
                    {
                        if (FilterTable.Controls[i].Text != "")
                        {
                            expressions.Add($"{Brigades.Columns[i]} = ${expressions.Count + 1}");
                            parameters.Add(new()
                            {
                                Value = Convert.ChangeType(FilterTable.Controls[i].Text, Brigades.Types[i])
                            });
                        }
                    }
                    break;
                case Tables.Car_repair:
                    for (int i = 0; i < FilterTable.Controls.Count; ++i)
                    {

                    }
                    break;
                case Tables.Cars:
                    for (int i = 0; i < FilterTable.Controls.Count; ++i)
                    {

                    }
                    break;
                case Tables.Failures:
                    for (int i = 0; i < FilterTable.Controls.Count; ++i)
                    {

                    }
                    break;
                case Tables.Personnel:
                    for (int i = 0; i < FilterTable.Controls.Count; ++i)
                    {

                    }
                    break;
                case Tables.Spare_parts:
                    for (int i = 0; i < FilterTable.Controls.Count; ++i)
                    {

                    }
                    break;
                case Tables.Workshops:
                    for (int i = 0; i < FilterTable.Controls.Count; ++i)
                    {

                    }
                    break;

                default:
                    break;
            }
            string commandText = $"SELECT * FROM {tableName} WHERE {string.Join(" AND ", expressions)}";

            await using var command = new NpgsqlCommand(commandText, connection);
            command.Parameters.AddRange(parameters.ToArray());

            await command.ExecuteNonQueryAsync();

            brigades.Clear();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                brigades.Add(new Brigades(reader.GetString(0), reader.GetInt32(1)));
            }
        }
    }
}
