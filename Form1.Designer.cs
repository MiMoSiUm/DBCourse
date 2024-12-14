namespace DBCourse
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            FilterTable = new TableLayoutPanel();
            comboBox1 = new ComboBox();
            AscButton = new Button();
            DescButton = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(99, 23);
            button1.TabIndex = 1;
            button1.Text = "brigades";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(117, 13);
            button2.Name = "button2";
            button2.Size = new Size(99, 23);
            button2.TabIndex = 2;
            button2.Text = "car_repair";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(222, 13);
            button3.Name = "button3";
            button3.Size = new Size(99, 23);
            button3.TabIndex = 3;
            button3.Text = "cars";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(327, 13);
            button4.Name = "button4";
            button4.Size = new Size(99, 23);
            button4.TabIndex = 4;
            button4.Text = "failures";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(432, 13);
            button5.Name = "button5";
            button5.Size = new Size(99, 23);
            button5.TabIndex = 5;
            button5.Text = "personnel";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(537, 13);
            button6.Name = "button6";
            button6.Size = new Size(99, 23);
            button6.TabIndex = 6;
            button6.Text = "spare_parts";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(642, 13);
            button7.Name = "button7";
            button7.Size = new Size(99, 23);
            button7.TabIndex = 7;
            button7.Text = "workshops";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(12, 125);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(946, 313);
            tableLayoutPanel1.TabIndex = 8;
            tableLayoutPanel1.Resize += tableLayoutPanel1_Resize;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 107);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 9;
            label1.Text = "Добавить строку:";
            // 
            // FilterTable
            // 
            FilterTable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FilterTable.ColumnCount = 1;
            FilterTable.ColumnStyles.Add(new ColumnStyle());
            FilterTable.Location = new Point(12, 71);
            FilterTable.Name = "FilterTable";
            FilterTable.RowCount = 1;
            FilterTable.RowStyles.Add(new RowStyle());
            FilterTable.Size = new Size(946, 39);
            FilterTable.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(747, 13);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 23);
            comboBox1.TabIndex = 11;
            // 
            // AscButton
            // 
            AscButton.Location = new Point(904, 12);
            AscButton.Name = "AscButton";
            AscButton.Size = new Size(24, 23);
            AscButton.TabIndex = 12;
            AscButton.Text = "↑";
            AscButton.UseVisualStyleBackColor = true;
            AscButton.Click += AscButton_Click;
            // 
            // DescButton
            // 
            DescButton.Location = new Point(934, 12);
            DescButton.Name = "DescButton";
            DescButton.Size = new Size(24, 23);
            DescButton.TabIndex = 13;
            DescButton.Text = "↓";
            DescButton.UseVisualStyleBackColor = true;
            DescButton.Click += DescButton_Click;
            // 
            // button8
            // 
            button8.Location = new Point(12, 42);
            button8.Name = "button8";
            button8.Size = new Size(99, 23);
            button8.TabIndex = 14;
            button8.Text = "cars_in_work";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(117, 42);
            button9.Name = "button9";
            button9.Size = new Size(99, 23);
            button9.TabIndex = 15;
            button9.Text = "free_brigades";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(222, 42);
            button10.Name = "button10";
            button10.Size = new Size(204, 23);
            button10.TabIndex = 16;
            button10.Text = "number_of_failures_by_cars";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 450);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(DescButton);
            Controls.Add(AscButton);
            Controls.Add(comboBox1);
            Controls.Add(FilterTable);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel FilterTable;
        private ComboBox comboBox1;
        private Button AscButton;
        private Button DescButton;
        private Button button8;
        private Button button9;
        private Button button10;
    }
}
