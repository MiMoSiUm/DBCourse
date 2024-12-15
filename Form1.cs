using Npgsql;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DBCourse
{
    public partial class Form1 : Form
    {
        public static readonly string connectionString = "Host=192.168.1.119;Username=postgres;Password=postgres;Database=course work";
        //public static readonly string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=course work";
        List<Brigades> brigades = new List<Brigades>();
        List<Car_repair> car_repair = new List<Car_repair>();
        List<Cars> cars = new List<Cars>();
        List<Failures> failures = new List<Failures>();
        List<Personnel> personnel = new List<Personnel>();
        List<Spare_parts> spare_parts = new List<Spare_parts>();
        List<Workshops> workshops = new List<Workshops>();
        List<Cars_in_work> cars_in_work = new List<Cars_in_work>();
        List<Free_brigades> free_brigades = new List<Free_brigades>();
        List<Number_of_failures_by_cars> number_of_failures_by_cars = new List<Number_of_failures_by_cars>();
        Tables current_table = Tables.None;
        string sort = "ASC";
        public Form1()
        {
            InitializeComponent();
        }

        async private void button1_Click(object sender, EventArgs e) // brigades
        {
            current_table = Tables.Brigades;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button2_Click(object sender, EventArgs e) // car_repair
        {
            current_table = Tables.Car_repair;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button3_Click(object sender, EventArgs e) // cars
        {
            current_table = Tables.Cars;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button4_Click(object sender, EventArgs e) // failures
        {
            current_table = Tables.Failures;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button5_Click(object sender, EventArgs e) // personnel
        {
            current_table = Tables.Personnel;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button6_Click(object sender, EventArgs e) // spare_parts
        {
            current_table = Tables.Spare_parts;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button7_Click(object sender, EventArgs e) // workshops
        {
            current_table = Tables.Workshops;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button8_Click(object sender, EventArgs e)
        {
            current_table = Tables.Cars_in_work;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button9_Click(object sender, EventArgs e)
        {
            current_table = Tables.Free_brigades;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
        }

        async private void button10_Click(object sender, EventArgs e)
        {
            current_table = Tables.Number_of_failures_by_cars;
            tableLayoutPanel1.Controls.Clear();
            FilterTableAdd();
            await Update(sender, e);
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

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Brigades.Types[i])
                            });
                    }

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

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Car_repair.Types[i])
                            });
                    }

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

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Cars.Types[i])
                            });
                    }

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

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Failures.Types[i])
                            });
                    }

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

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Personnel.Types[i])
                            });
                    }

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

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Spare_parts.Types[i])
                            });
                    }

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

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Workshops.Types[i])
                            });
                    }

                    for (int i = 0; i < Workshops.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Workshops.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Cars_in_work:
                    tableName = Cars_in_work.Name;

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Cars_in_work.Types[i])
                            });
                    }

                    for (int i = 0; i < Cars_in_work.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Cars_in_work.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Free_brigades:
                    tableName = Free_brigades.Name;

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Free_brigades.Types[i])
                            });
                    }

                    for (int i = 0; i < Free_brigades.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Free_brigades.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                case Tables.Number_of_failures_by_cars:
                    tableName = Number_of_failures_by_cars.Name;

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                            parameters.Add(new NpgsqlParameter
                            {
                                Value = Convert.ChangeType(tableLayoutPanel1.Controls[i].Text, Number_of_failures_by_cars.Types[i])
                            });
                    }

                    for (int i = 0; i < Number_of_failures_by_cars.Columns.Count; ++i)
                    {
                        if (tableLayoutPanel1.Controls[i].Text != "")
                        {
                            cols.Add(Number_of_failures_by_cars.Columns[i]);
                            placeholders.Add($"${cols.Count}");
                        }
                    }

                    break;

                default:
                    break;
            }

            await using var command = new NpgsqlCommand($"INSERT INTO {tableName} ({string.Join(",", cols)}) " +
                $"VALUES ({string.Join(",", placeholders)})", connection);
            command.Parameters.AddRange(parameters.ToArray());

            await command.ExecuteNonQueryAsync();
        }
        async void BlankRowAdd(List<string> cols)
        {
            for (int i = 0; i < tableLayoutPanel1.ColumnCount - 2; ++i)
                tableLayoutPanel1.Controls.Add(new TextBox() { PlaceholderText = cols[i], Visible = false });

            Button addButton = new Button() { Text = "Добавить", Visible = false };
            addButton.Click += (sender, args) => Add_row_click(sender, args);
            addButton.Click += async (sender, args) => Update(sender, args);
            tableLayoutPanel1.Controls.Add(addButton);
            tableLayoutPanel1.Controls.Add(new Label { Text = " " });
        }
        void TableEven()
        {
            //for (int i = 0; i < tableLayoutPanel1.ColumnCount; ++i)
            //{
            //    tableLayoutPanel1.Controls.Add(new Label());
            //}

            for (int i = 0; i < FilterTable.Controls.Count; ++i)
            {
                FilterTable.Controls[i].Width = ((Width - 80) / FilterTable.ColumnCount);
                FilterTable.Controls[i].Dock = DockStyle.Fill;
            }

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; ++i)
            {
                tableLayoutPanel1.Controls[i].Width = ((Width - 80) / tableLayoutPanel1.ColumnCount);
                tableLayoutPanel1.Controls[i].Visible = true;
                //tableLayoutPanel1.Controls[i].Dock = DockStyle.Fill;
            }
        }
        void FilterTableAdd()
        {
            List<string> cols = new List<string>();
            FilterTable.Controls.Clear();
            if (FilterTable.Controls.Count == 0)
            {
                switch (current_table)
                {
                    case Tables.Brigades:
                        FilterTable.ColumnCount = Brigades.Columns.Count + 2;
                        cols = Brigades.Columns;
                        break;
                    case Tables.Car_repair:
                        FilterTable.ColumnCount = Car_repair.Columns.Count + 2;
                        cols = Car_repair.Columns;
                        break;
                    case Tables.Cars:
                        FilterTable.ColumnCount = Cars.Columns.Count + 2;
                        cols = Cars.Columns;
                        break;
                    case Tables.Failures:
                        FilterTable.ColumnCount = Failures.Columns.Count + 2;
                        cols = Failures.Columns;
                        break;
                    case Tables.Personnel:
                        FilterTable.ColumnCount = Personnel.Columns.Count + 2;
                        cols = Personnel.Columns;
                        break;
                    case Tables.Spare_parts:
                        FilterTable.ColumnCount = Spare_parts.Columns.Count + 2;
                        cols = Spare_parts.Columns;
                        break;
                    case Tables.Workshops:
                        FilterTable.ColumnCount = Workshops.Columns.Count + 2;
                        cols = Workshops.Columns;
                        break;
                    case Tables.Cars_in_work:
                        FilterTable.ColumnCount = Cars_in_work.Columns.Count + 2;
                        cols = Cars_in_work.Columns;
                        break;
                    case Tables.Free_brigades:
                        FilterTable.ColumnCount = Free_brigades.Columns.Count + 2;
                        cols = Free_brigades.Columns;
                        break;
                    case Tables.Number_of_failures_by_cars:
                        FilterTable.ColumnCount = Number_of_failures_by_cars.Columns.Count + 2;
                        cols = Number_of_failures_by_cars.Columns;
                        break;

                    default:
                        break;
                }
            }
            for (int i = 0; i < FilterTable.ColumnCount - 2; ++i)
                FilterTable.Controls.Add(new TextBox() { PlaceholderText = cols[i] });
            Button FindButton = new Button() { Text = "Найти" };
            FindButton.Click += (sender, args) => Update(sender, args);
            FilterTable.Controls.Add(FindButton);
            FilterTable.Controls.Add(new Label());
            //for (int i = 0; i < FilterTable.Controls.Count; ++i)
            //{
            //    FilterTable.Controls[i].Width = ((FilterTable.Width - 50) / FilterTable.ColumnCount);
            //    //FilterTable.Controls[i].Dock = DockStyle.Fill;
            //}
            TableEven();

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(cols.ToArray());
            comboBox1.Text = comboBox1.Items[0].ToString();
        }
        async Task Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            List<string> expressions = new List<string>();
            string tableName = "";
            List<Type> types = new List<Type>();
            List<string> cols = new List<string>();
            switch (current_table)
            {
                case Tables.Brigades:
                    tableName = Brigades.Name;
                    types = Brigades.Types;
                    cols = Brigades.Columns;
                    break;
                case Tables.Car_repair:
                    tableName = Car_repair.Name;
                    types = Car_repair.Types;
                    cols = Car_repair.Columns;
                    break;
                case Tables.Cars:
                    tableName = Cars.Name;
                    types = Cars.Types;
                    cols = Cars.Columns;
                    break;
                case Tables.Failures:
                    tableName = Failures.Name;
                    types = Failures.Types;
                    cols = Failures.Columns;
                    break;
                case Tables.Personnel:
                    tableName = Personnel.Name;
                    types = Personnel.Types;
                    cols = Personnel.Columns;
                    break;
                case Tables.Spare_parts:
                    tableName = Spare_parts.Name;
                    types = Spare_parts.Types;
                    cols = Spare_parts.Columns;
                    break;
                case Tables.Workshops:
                    tableName = Workshops.Name;
                    types = Workshops.Types;
                    cols = Workshops.Columns;
                    break;
                case Tables.Cars_in_work:
                    tableName = Cars_in_work.Name;
                    types = Cars_in_work.Types;
                    cols = Cars_in_work.Columns;
                    break;
                case Tables.Free_brigades:
                    tableName = Free_brigades.Name;
                    types = Free_brigades.Types;
                    cols = Free_brigades.Columns;
                    break;
                case Tables.Number_of_failures_by_cars:
                    tableName = Number_of_failures_by_cars.Name;
                    types = Number_of_failures_by_cars.Types;
                    cols = Number_of_failures_by_cars.Columns;
                    break;

                default:
                    break;
            }

            for (int i = 0; i < FilterTable.Controls.Count - 2; ++i)
            {
                if (FilterTable.Controls[i].Text != "")
                {
                    expressions.Add($"{cols[i]} = ${expressions.Count + 1}");
                    parameters.Add(new()
                    {
                        Value = Convert.ChangeType(FilterTable.Controls[i].Text, types[i])
                    });
                }
            }

            string where = expressions.Count == 0 ? "" : " WHERE ";
            string commandText = $"SELECT * FROM {tableName}{where}{string.Join(" AND ", expressions)} " +
                $"ORDER BY {comboBox1.Text} {sort}";

            await using var command = new NpgsqlCommand(commandText, connection);
            command.Parameters.AddRange(parameters.ToArray());

            await using var reader = await command.ExecuteReaderAsync();

            tableLayoutPanel1.Controls.Clear();

            switch (current_table)
            {
                case Tables.Brigades:
                    brigades.Clear();
                    while (await reader.ReadAsync())
                    {
                        brigades.Add(new Brigades(
                            reader.GetString(0),
                            reader.GetInt32(1)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Brigades.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Brigades.Columns);

                    for (int i = 0; i < Brigades.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Brigades.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < brigades.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(brigades[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(brigades[i].updateButton);
                        tableLayoutPanel1.Controls.Add(brigades[i].deleteButton);

                        brigades[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Car_repair:
                    car_repair.Clear();
                    while (await reader.ReadAsync())
                    {
                        car_repair.Add(new Car_repair(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetDateTime(2),
                            reader.GetDateTime(3),
                            reader.GetInt32(4)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Car_repair.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Car_repair.Columns);

                    for (int i = 0; i < Car_repair.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Car_repair.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < car_repair.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(car_repair[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(car_repair[i].updateButton);
                        tableLayoutPanel1.Controls.Add(car_repair[i].deleteButton);

                        car_repair[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Cars:
                    cars.Clear();
                    while (await reader.ReadAsync())
                    {
                        cars.Add(new Cars(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Cars.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Cars.Columns);

                    for (int i = 0; i < Cars.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Cars.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < cars.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(cars[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(cars[i].updateButton);
                        tableLayoutPanel1.Controls.Add(cars[i].deleteButton);

                        cars[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Failures:
                    failures.Clear();
                    while (await reader.ReadAsync())
                    {
                        failures.Add(new Failures
                        (
                            reader.GetString(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Failures.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Failures.Columns);

                    for (int i = 0; i < Failures.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Failures.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < failures.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(failures[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(failures[i].updateButton);
                        tableLayoutPanel1.Controls.Add(failures[i].deleteButton);

                        failures[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Personnel:
                    personnel.Clear();
                    while (await reader.ReadAsync())
                    {
                        personnel.Add(new Personnel(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Personnel.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Personnel.Columns);

                    for (int i = 0; i < Personnel.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Personnel.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < personnel.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(personnel[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(personnel[i].updateButton);
                        tableLayoutPanel1.Controls.Add(personnel[i].deleteButton);

                        personnel[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Spare_parts:
                    spare_parts.Clear();
                    while (await reader.ReadAsync())
                    {
                        spare_parts.Add(new Spare_parts(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetInt32(4)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Spare_parts.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Spare_parts.Columns);

                    for (int i = 0; i < Spare_parts.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Spare_parts.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < spare_parts.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(spare_parts[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(spare_parts[i].updateButton);
                        tableLayoutPanel1.Controls.Add(spare_parts[i].deleteButton);

                        spare_parts[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Workshops:
                    workshops.Clear();
                    while (await reader.ReadAsync())
                    {
                        workshops.Add(new Workshops(
                            reader.GetString(0),
                            reader.GetInt32(1)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Workshops.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Workshops.Columns);

                    for (int i = 0; i < Workshops.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Workshops.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < workshops.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(workshops[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(workshops[i].updateButton);
                        tableLayoutPanel1.Controls.Add(workshops[i].deleteButton);

                        workshops[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Cars_in_work:
                    cars_in_work.Clear();
                    while (await reader.ReadAsync())
                    {
                        cars_in_work.Add(new Cars_in_work(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetDateTime(2),
                            reader.GetDateTime(3),
                            reader.GetInt32(4)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Cars_in_work.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Cars_in_work.Columns);

                    for (int i = 0; i < Cars_in_work.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Cars_in_work.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < cars_in_work.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(cars_in_work[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(cars_in_work[i].updateButton);
                        tableLayoutPanel1.Controls.Add(cars_in_work[i].deleteButton);

                        cars_in_work[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Free_brigades:
                    free_brigades.Clear();
                    while (await reader.ReadAsync())
                    {
                        free_brigades.Add(new Free_brigades(
                            reader.GetString(0),
                            reader.GetInt32(1)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Free_brigades.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Free_brigades.Columns);

                    for (int i = 0; i < Free_brigades.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Free_brigades.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < free_brigades.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(free_brigades[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(free_brigades[i].updateButton);
                        tableLayoutPanel1.Controls.Add(free_brigades[i].deleteButton);

                        free_brigades[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                case Tables.Number_of_failures_by_cars:
                    number_of_failures_by_cars.Clear();
                    while (await reader.ReadAsync())
                    {
                        number_of_failures_by_cars.Add(new Number_of_failures_by_cars(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt64(2)
                        ));
                    }
                    tableLayoutPanel1.ColumnCount = Number_of_failures_by_cars.Columns.Count + 2;
                    tableLayoutPanel1.RowCount = 0;

                    BlankRowAdd(Number_of_failures_by_cars.Columns);

                    for (int i = 0; i < Number_of_failures_by_cars.Columns.Count; ++i)
                        tableLayoutPanel1.Controls.Add(new Label() { Text = Number_of_failures_by_cars.Columns[i] });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });
                    tableLayoutPanel1.Controls.Add(new Label() { Text = " " });

                    for (int i = 0; i < number_of_failures_by_cars.Count; ++i)
                    {
                        tableLayoutPanel1.Controls.AddRange(number_of_failures_by_cars[i].TextBoxes.ToArray());
                        tableLayoutPanel1.Controls.Add(number_of_failures_by_cars[i].updateButton);
                        tableLayoutPanel1.Controls.Add(number_of_failures_by_cars[i].deleteButton);

                        number_of_failures_by_cars[i].deleteButton.Click += async (sender, args) => Update(sender, args);
                    }
                    break;

                default:
                    break;
            }
            TableEven();
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            TableEven();
        }

        async private void AscButton_Click(object sender, EventArgs e)
        {
            sort = "ASC";
            await Update(sender, e);
        }

        async private void DescButton_Click(object sender, EventArgs e)
        {
            sort = "DESC";
            await Update(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Стоимость ремонта":
                    ReportForm reportForm = new ReportForm();
                    reportForm.Show();
                    break;
                case "Производительность труда бригад":
                    Report2Form report2Form = new Report2Form();
                    report2Form.Show();
                    break;
                case "Выручка сервисов":
                    Report3Form report3Form = new Report3Form();
                    report3Form.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
