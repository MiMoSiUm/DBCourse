﻿namespace DBCourse
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
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(12, 292);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(283, 146);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(37, 12);
            button1.Name = "button1";
            button1.Size = new Size(99, 23);
            button1.TabIndex = 1;
            button1.Text = "brigades";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(142, 12);
            button2.Name = "button2";
            button2.Size = new Size(99, 23);
            button2.TabIndex = 2;
            button2.Text = "car_repair";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(247, 12);
            button3.Name = "button3";
            button3.Size = new Size(99, 23);
            button3.TabIndex = 3;
            button3.Text = "cars";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(352, 12);
            button4.Name = "button4";
            button4.Size = new Size(99, 23);
            button4.TabIndex = 4;
            button4.Text = "failures";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(457, 12);
            button5.Name = "button5";
            button5.Size = new Size(99, 23);
            button5.TabIndex = 5;
            button5.Text = "personnel";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(562, 12);
            button6.Name = "button6";
            button6.Size = new Size(99, 23);
            button6.TabIndex = 6;
            button6.Text = "spare_parts";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(667, 12);
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
            tableLayoutPanel1.Location = new Point(37, 58);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(729, 211);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
