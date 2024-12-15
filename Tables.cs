using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using System.Xml.Linq;
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
        Workshops,
        Cars_in_work,
        Free_brigades,
        Number_of_failures_by_cars
    }
    class TableLine
    {
        public List<Type> Types { get; protected set; }
        public string Name { get; protected set; }
        public List<string> Columns { get; protected set; }

        public Button updateButton;
        public Button deleteButton;

        public List<object> ColsData { get; protected set; }
        public List<TextBox> TextBoxes { get; protected set; }
        public List<int> keyIndexes;

        public TableLine()
        {
            updateButton = new Button() { Text = "Изменить" };
            updateButton.Click += (sender, args) => Update(sender, args);

            deleteButton = new Button() { Text = "Удалить" };
            deleteButton.Click += (sender, args) => Delete(sender, args);
        }
        async protected void Update(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> expressions = new List<string>();
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            int counter = 0;
            for (int i = 0; i < Columns.Count; ++i)
            {
                if (ColsData[i].ToString() != TextBoxes[i].Text)
                {
                    ++counter;
                    expressions.Add($"{Columns[i]} = ${i + 1}");
                    parameters.Add(new() { Value = Convert.ChangeType(TextBoxes[i].Text, Types[i]) });
                }
            }

            if (counter > 0)
            {
                List<string> keyExpressions = new List<string>();
                List<NpgsqlParameter> keyParameters = new List<NpgsqlParameter>();
                for (int i = 0; i < keyIndexes.Count; ++i)
                {
                    keyExpressions.Add($"{Columns[keyIndexes[i]]} = ${expressions.Count + i + 1}");
                    keyParameters.Add(new() { Value = ColsData[keyIndexes[i]] });
                }

                await using var command = new NpgsqlCommand($"UPDATE {Name} SET {string.Join(",", expressions)} " +
                    $"WHERE {string.Join(" AND ", keyExpressions)}", connection);
                command.Parameters.AddRange(parameters.ToArray());
                command.Parameters.AddRange(keyParameters.ToArray());

                await command.ExecuteNonQueryAsync();
            }
        }
        async protected void Delete(object sender, EventArgs e)
        {
            await using var dataSource = NpgsqlDataSource.Create(Form1.connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();

            List<string> keyExpressions = new List<string>();
            List<NpgsqlParameter> keyParameters = new List<NpgsqlParameter>();

            for (int i = 0; i < keyIndexes.Count; ++i)
            {
                keyExpressions.Add($"{Columns[keyIndexes[i]]} = ${i + 1}");
                keyParameters.Add(new() { Value = ColsData[keyIndexes[i]] });
            }

            await using var command = new NpgsqlCommand($"DELETE FROM {Name} WHERE {string.Join(" AND ", keyExpressions)}", connection);
            command.Parameters.AddRange(keyParameters.ToArray());

            await command.ExecuteNonQueryAsync();
        }
    }
    class Brigades : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; } = "brigades";
        public static List<string> Columns { get; } = ["brigade_name", "brigade_id"];
        public static List<int> keyIndexes = [1];

        public Brigades(string brigade_name, int brigade_id)
        {
            ColsData = [brigade_name, brigade_id];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    class Car_repair : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; set; } = "car_repair";
        public static List<string> Columns { get; } = ["car_id", "failure_id", "arrival_date", "leaving_date", "brigade_id"];
        public static List<int> keyIndexes = [0, 1, 2];
        public Car_repair(
            int car_id,
            int failure_id,
            DateTime arrival_date,
            DateTime leaving_date,
            int brigade_id
        )
        {
            ColsData = [
                car_id,
                failure_id,
                arrival_date,
                leaving_date,
                brigade_id
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    class Cars : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; protected set; } = "cars";
        public static List<string> Columns { get; } = ["car_body_number", "car_engine_number", "car_owner", "car_vin", "car_id"];
        public static List<int> keyIndexes = [4];

        public Cars(string car_body_number, string car_engine_number, string car_owner, string car_vin, int car_id)
        {
            ColsData = [
                car_body_number,
                car_engine_number,
                car_owner,
                car_vin,
                car_id
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    class Failures : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; } = "failures";
        public static List<string> Columns { get; } = ["failure_name", "work_cost", "failure_id"];
        public static List<int> keyIndexes = [2];

        public Failures(string failure_name, int work_cost, int failure_id)
        {
            ColsData = [
                failure_name,
                work_cost,
                failure_id
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    class Personnel : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; } = "personnel";
        public static List<string> Columns { get; } = ["workshop_id", "person_inn", "brigade_id"];
        public static List<int> keyIndexes = [0, 1];

        public Personnel(int workshop_id, string person_inn, int brigade_id)
        {
            ColsData = [
                workshop_id,
                person_inn,
                brigade_id
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    class Spare_parts : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; } = "spare_parts";
        public static List<string> Columns { get; } = ["car_id", "failure_id", "part_name", "part_cost", "part_amount"];
        public static List<int> keyIndexes = [0, 2];

        public Spare_parts(int car_id, int failure_id, string part_name, int part_cost, int part_amount)
        {
            ColsData = [
                car_id,
                failure_id,
                part_name,
                part_cost,
                part_amount
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    class Workshops : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; } = "workshops";
        public static List<string> Columns { get; } = ["workshop_name", "workshop_id"];
        public static List<int> keyIndexes = [1];

        public Workshops(string workshop_name, int workshop_id)
        {
            ColsData = [
                workshop_name,
                workshop_id
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    //class Cars_in_work : Car_repair
    //{
    //    public Cars_in_work(
    //        int car_id,
    //        int failure_id,
    //        DateTime arrival_date,
    //        DateTime leaving_date,
    //        int brigade_id
    //    ) :
    //        base(
    //        car_id,
    //        failure_id,
    //        arrival_date,
    //        leaving_date,
    //        brigade_id
    //    )
    //    {
    //        Name = "cars_in_work";
    //    }
    //}
    class Cars_in_work : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; set; } = "cars_in_work";
        public static List<string> Columns { get; } = ["car_id", "failure_id", "arrival_date", "leaving_date", "brigade_id"];
        public static List<int> keyIndexes = [0, 1, 2];
        public Cars_in_work(
            int car_id,
            int failure_id,
            DateTime arrival_date,
            DateTime leaving_date,
            int brigade_id
        )
        {
            ColsData = [
                car_id,
                failure_id,
                arrival_date,
                leaving_date,
                brigade_id
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    class Free_brigades : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; } = "free_brigades";
        public static List<string> Columns { get; } = ["brigade_name", "brigade_id"];
        public static List<int> keyIndexes = [1];

        public Free_brigades(string brigade_name, int brigade_id)
        {
            ColsData = [
                brigade_name,
                brigade_id
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
    class Number_of_failures_by_cars : TableLine
    {
        public static List<Type> Types { get; private set; }
        public static string Name { get; } = "number_of_failures_by_cars";
        public static List<string> Columns { get; } = ["car_id", "car_vin", "number_of_failures"];
        public static List<int> keyIndexes = [];
        public Number_of_failures_by_cars(int car_id, string car_vin, long number_of_failures)
        {
            ColsData = [
                car_id,
                car_vin,
                number_of_failures
            ];

            TextBoxes = new List<TextBox>();
            for (int i = 0; i < Columns.Count; ++i)
                TextBoxes.Add(new TextBox() { Text = $"{ColsData[i]}" });

            updateButton.Enabled = false;
            deleteButton.Enabled = false;

            Types = new List<Type>();
            for (int i = 0; i < ColsData.Count; ++i)
                Types.Add(ColsData[i].GetType());

            base.Types = Types;
            base.Name = Name;
            base.Columns = Columns;
            base.keyIndexes = keyIndexes;
        }
    }
}
