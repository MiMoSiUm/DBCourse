using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DBCourse
{
    enum Tables {
        None,
        Brigades,
        Car_repair,
        Cars,
        Failures,
        Personnel,
        Spare_parts,
        Workshops
    }
    class Brigades
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; } = "brigades";
        public static List<string> Columns { get; } = ["brigade_name", "brigade_id"];
        public string brigade_name;
        public int brigade_id;

        public TextBox brigade_name_tb;
        public TextBox brigade_id_tb;

        public Button updateButton;
        public Button deleteButton;

        public Brigades(string brigade_name, int brigade_id) 
        {
            this.brigade_name = brigade_name;
            this.brigade_id = brigade_id;

            brigade_name_tb = new TextBox() { Text = $"{brigade_name}" };
            brigade_id_tb = new TextBox() { Text = $"{brigade_id}" };

            updateButton = new Button() { Text = "Изменить" };
            updateButton.Click += (sender, args) => Update(sender, args);

            deleteButton = new Button() { Text = "Удалить" };
            deleteButton.Click += (sender, args) => Delete(sender, args);

            Types = new List<Type>();
            Types.Add(brigade_name.GetType());
            Types.Add(brigade_id.GetType());
        }

        async private void Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> expressions = new List<string>();

            for (int i = 0; i < Columns.Count; ++i)
                expressions.Add($"{Columns[i]} = ${i + 1}");

            await using var command = new NpgsqlCommand($"UPDATE {Name} SET {string.Join(",", expressions)} " +
                $"WHERE brigade_id = $3", connection)
            {
                Parameters =
                {
                    new() {Value = brigade_name_tb.Text},
                    new() {Value = int.Parse(brigade_id_tb.Text)},
                    new() { Value = brigade_id }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
        async private void Delete(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            await using var command = new NpgsqlCommand($"DELETE FROM {Name} WHERE brigade_id = $1", connection)
            {
                Parameters = {
                    new() { Value = brigade_id }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
    }
    class Car_repair
    {
        public static string Name { get; } = "car_repair";
        public static List<string> Columns { get; } = ["car_id", "failure_id", "arrival_date", "leaving_date", "brigade_id"];
        public int car_id;
        public int failure_id;
        public DateTime arrival_date;
        public DateTime leaving_date;
        public int brigade_id;

        public TextBox car_id_tb;
        public TextBox failure_id_tb;
        public TextBox arrival_date_tb;
        public TextBox leaving_date_tb;
        public TextBox brigade_id_tb;

        public Button updateButton;
        public Button deleteButton;
        public Car_repair(
            int car_id,
            int failure_id,
            DateTime arrival_date,
            DateTime leaving_date,
            int brigade_id
        )
        {
            this.car_id = car_id;
            this.failure_id = failure_id;
            this.arrival_date = arrival_date;
            this.leaving_date = leaving_date;
            this.brigade_id = brigade_id;

            car_id_tb = new TextBox() { Text = $"{car_id}" };
            failure_id_tb = new TextBox() { Text = $"{failure_id}" };
            arrival_date_tb = new TextBox() { Text = $"{arrival_date}" };
            leaving_date_tb = new TextBox() { Text = $"{leaving_date}" };
            brigade_id_tb = new TextBox() { Text = $"{brigade_id}" };

            updateButton = new Button() { Text = "Изменить" };
            updateButton.Click += (sender, args) => Update(sender, args);

            deleteButton = new Button() { Text = "Удалить" };
            deleteButton.Click += (sender, args) => Delete(sender, args);
        }
        async private void Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> expressions = new List<string>();

            for (int i = 0; i < Columns.Count; ++i)
                expressions.Add($"{Columns[i]} = ${i + 1}");

            await using var command = new NpgsqlCommand($"UPDATE {Name} SET {string.Join(",", expressions)} " +
                $"WHERE car_id = $6 AND failure_id = $7 AND arrival_date = $8", connection)
            {
                Parameters =
                {
                    new() {Value = int.Parse(car_id_tb.Text)},
                    new() {Value = int.Parse(failure_id_tb.Text)},
                    new() {Value = DateTime.Parse(arrival_date_tb.Text)},
                    new() {Value = DateTime.Parse(leaving_date_tb.Text)},
                    new() {Value = int.Parse(brigade_id_tb.Text)},
                    new() { Value = car_id },
                    new() { Value = failure_id },
                    new() { Value = arrival_date }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
        async private void Delete(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            await using var command = new NpgsqlCommand($"DELETE FROM {Name} WHERE " +
                $"car_id = $1 AND failure_id = $2 AND arrival_date = $3", connection)
            {
                Parameters = {
                    new() { Value = car_id },
                    new() { Value = failure_id },
                    new() { Value = arrival_date }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
    }
    class Cars
    {
        public static string Name { get; } = "cars";
        public static List<string> Columns { get; } = ["car_body_number", "car_engine_number", "car_owner", "car_vin", "car_id"];
        public string car_body_number;
        public string car_engine_number;
        public string car_owner;
        public string car_vin;
        public int car_id;

        public TextBox car_body_number_tb;
        public TextBox car_engine_number_tb;
        public TextBox car_owner_tb;
        public TextBox car_vin_tb;
        public TextBox car_id_tb;

        public Button updateButton;
        public Button deleteButton;

        public Cars(string car_body_number, string car_engine_number, string car_owner, string car_vin, int car_id)
        {
            this.car_body_number = car_body_number;
            this.car_engine_number = car_engine_number;
            this.car_owner = car_owner;
            this.car_vin = car_vin;
            this.car_id = car_id;

            car_body_number_tb = new TextBox() { Text = car_body_number };
            car_engine_number_tb = new TextBox() { Text = car_engine_number };
            car_owner_tb = new TextBox() { Text = car_owner };
            car_vin_tb = new TextBox() { Text = car_vin };
            car_id_tb = new TextBox() { Text = $"{car_id}" };

            updateButton = new Button() { Text = "Изменить" };
            updateButton.Click += (sender, args) => Update(sender, args);

            deleteButton = new Button() { Text = "Удалить" };
            deleteButton.Click += (sender, args) => Delete(sender, args);
        }
        async private void Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> expressions = new List<string>();

            for (int i = 0; i < Columns.Count; ++i)
                expressions.Add($"{Columns[i]} = ${i + 1}");

            await using var command = new NpgsqlCommand($"UPDATE {Name} SET {string.Join(",", expressions)} " +
                $"WHERE car_id = $6", connection)
            {
                Parameters =
                {
                    new() {Value = car_body_number_tb.Text},
                    new() {Value = car_engine_number_tb.Text},
                    new() {Value = car_owner_tb.Text},
                    new() {Value = car_vin_tb.Text},
                    new() {Value = int.Parse(car_id_tb.Text)},
                    new() { Value = car_id }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
        async private void Delete(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            await using var command = new NpgsqlCommand($"DELETE FROM {Name} WHERE car_id = $1", connection)
            {
                Parameters = {
                    new() { Value = car_id }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
    }
    class Failures
    {
        public static string Name { get; } = "failures";
        public static List<string> Columns { get; } = ["failure_name", "work_cost", "failure_id"];
        public string failure_name;
        public int work_cost;
        public int failure_id;

        public TextBox failure_name_tb;
        public TextBox work_cost_tb;
        public TextBox failure_id_tb;

        public Button updateButton;
        public Button deleteButton;

        public Failures(string failure_name, int work_cost, int failure_id)
        {
            this.failure_name = failure_name;
            this.work_cost = work_cost;
            this.failure_id = failure_id;

            failure_name_tb = new TextBox() { Text = failure_name };
            work_cost_tb = new TextBox() { Text = $"{work_cost}" };
            failure_id_tb = new TextBox() { Text = $"{failure_id}" };

            updateButton = new Button() { Text = "Изменить" };
            updateButton.Click += (sender, args) => Update(sender, args);

            deleteButton = new Button() { Text = "Удалить" };
            deleteButton.Click += (sender, args) => Delete(sender, args);
        }
        async private void Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> expressions = new List<string>();

            for (int i = 0; i < Columns.Count; ++i)
                expressions.Add($"{Columns[i]} = ${i + 1}");

            await using var command = new NpgsqlCommand($"UPDATE {Name} SET {string.Join(",", expressions)} " +
                $"WHERE failure_id = $4", connection)
            {
                Parameters =
                {
                    new() {Value = failure_name_tb.Text},
                    new() {Value = int.Parse(work_cost_tb.Text)},
                    new() {Value = int.Parse(failure_id_tb.Text)},
                    new() { Value = failure_id }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
        async private void Delete(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            await using var command = new NpgsqlCommand($"DELETE FROM {Name} WHERE failure_id = $1", connection)
            {
                Parameters = {
                    new() { Value = failure_id }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
    }
    class Personnel
    {
        public static string Name { get; } = "personnel";
        public static List<string> Columns { get; } = ["workshop_id", "person_inn", "brigade_id"];
        public int workshop_id;
        public string person_inn;
        public int brigade_id;

        public TextBox workshop_id_tb;
        public TextBox person_inn_tb;
        public TextBox brigade_id_tb;

        public Button updateButton;
        public Button deleteButton;

        public Personnel(int workshop_id, string person_inn, int brigade_id)
        {
            this.workshop_id = workshop_id;
            this.person_inn = person_inn;
            this.brigade_id = brigade_id;

            workshop_id_tb = new TextBox() { Text = $"{workshop_id}" };
            person_inn_tb = new TextBox() { Text = person_inn };
            brigade_id_tb = new TextBox() { Text = $"{brigade_id}" };

            updateButton = new Button() { Text = "Изменить" };
            updateButton.Click += (sender, args) => Update(sender, args);

            deleteButton = new Button() { Text = "Удалить" };
            deleteButton.Click += (sender, args) => Delete(sender, args);
        }
        async private void Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> expressions = new List<string>();

            for (int i = 0; i < Columns.Count; ++i)
                expressions.Add($"{Columns[i]} = ${i + 1}");

            await using var command = new NpgsqlCommand($"UPDATE {Name} SET {string.Join(",", expressions)} " +
                $"WHERE workshop_id = $4 AND person_inn = $5", connection)
            {
                Parameters =
                {
                    new() {Value = int.Parse(workshop_id_tb.Text)},
                    new() {Value = person_inn_tb.Text},
                    new() {Value = int.Parse(brigade_id_tb.Text)},
                    new() { Value = workshop_id },
                    new() { Value = person_inn }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
        async private void Delete(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            await using var command = new NpgsqlCommand($"DELETE FROM {Name} WHERE " +
                $"workshop_id = $1 AND person_inn = $2", connection)
            {
                Parameters = {
                    new() { Value = workshop_id },
                    new() { Value = person_inn }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
    }
    class Spare_parts
    {
        public static string Name { get; } = "spare_parts";
        public static List<string> Columns { get; } = ["car_id", "failure_id", "part_name", "part_cost", "part_amount"];
        public int car_id;
        public int failure_id;
        public string part_name;
        public int part_cost;
        public int part_amount;

        public TextBox car_id_tb;
        public TextBox failure_id_tb;
        public TextBox part_name_tb;
        public TextBox part_cost_tb;
        public TextBox part_amount_tb;

        public Button updateButton;
        public Button deleteButton;

        public Spare_parts(int car_id, int failure_id, string part_name, int part_cost, int part_amount)
        {
            this.car_id = car_id;
            this.failure_id = failure_id;
            this.part_name = part_name;
            this.part_cost = part_cost;
            this.part_amount = part_amount;

            car_id_tb = new TextBox() { Text = $"{car_id}" };
            failure_id_tb = new TextBox() { Text = $"{failure_id}" };
            part_name_tb = new TextBox() { Text = part_name };
            part_cost_tb = new TextBox() { Text = $"{part_cost}" };
            part_amount_tb = new TextBox() { Text = $"{part_amount}" };

            updateButton = new Button() { Text = "Изменить" };
            updateButton.Click += (sender, args) => Update(sender, args);

            deleteButton = new Button() { Text = "Удалить" };
            deleteButton.Click += (sender, args) => Delete(sender, args);
        }
        async private void Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> expressions = new List<string>();

            for (int i = 0; i < Columns.Count; ++i)
                expressions.Add($"{Columns[i]} = ${i + 1}");

            await using var command = new NpgsqlCommand($"UPDATE {Name} SET {string.Join(",", expressions)} " +
                $"WHERE car_id = $6 AND part_name = $7", connection)
            {
                Parameters =
                {
                    new() {Value = int.Parse(car_id_tb.Text)},
                    new() {Value = int.Parse(failure_id_tb.Text)},
                    new() {Value = part_name_tb.Text},
                    new() {Value = int.Parse(part_cost_tb.Text)},
                    new() {Value = int.Parse(part_amount_tb.Text)},
                    new() { Value = car_id },
                    new() { Value = part_name }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
        async private void Delete(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            await using var command = new NpgsqlCommand($"DELETE FROM {Name} WHERE " +
                $"car_id = $1 AND part_name = $2", connection)
            {
                Parameters = {
                    new() { Value = car_id },
                    new() { Value = part_name }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
    }
    class Workshops
    {
        public static string Name { get; } = "workshops";
        public static List<string> Columns { get; } = ["workshop_name", "workshop_id"];
        public string workshop_name;
        public int workshop_id;

        public TextBox workshop_name_tb;
        public TextBox workshop_id_tb;

        public Button updateButton;
        public Button deleteButton;

        public Workshops(string workshop_name, int workshop_id)
        {
            this.workshop_name = workshop_name;
            this.workshop_id = workshop_id;

            workshop_name_tb = new TextBox() { Text = workshop_name };
            workshop_id_tb = new TextBox() { Text = $"{workshop_id}" };

            updateButton = new Button() { Text = "Изменить" };
            updateButton.Click += (sender, args) => Update(sender, args);

            deleteButton = new Button() { Text = "Удалить" };
            deleteButton.Click += (sender, args) => Delete(sender, args);
        }
        async private void Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> expressions = new List<string>();

            for (int i = 0; i < Columns.Count; ++i)
                expressions.Add($"{Columns[i]} = ${i + 1}");

            await using var command = new NpgsqlCommand($"UPDATE {Name} SET {string.Join(",", expressions)} " +
                $"WHERE workshop_id = $3", connection)
            {
                Parameters =
                {
                    new() {Value = workshop_name_tb.Text},
                    new() {Value = int.Parse(workshop_id_tb.Text)},
                    new() {Value = workshop_id}
                }
            };

            await command.ExecuteNonQueryAsync();
        }
        async private void Delete(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            await using var command = new NpgsqlCommand($"DELETE FROM {Name} WHERE workshop_id = $1", connection)
            {
                Parameters = {
                    new() { Value = workshop_id }
                }
            };

            await command.ExecuteNonQueryAsync();
        }
    }
}
