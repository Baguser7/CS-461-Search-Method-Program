namespace WinFormsApp_SM
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
            label1 = new Label();
            label2 = new Label();
            comboBox_startCity = new ComboBox();
            comboBox_endCity = new ComboBox();
            comboBox_method = new ComboBox();
            button_search = new Button();
            progressBar1 = new ProgressBar();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label12 = new Label();
            textBox_totalTime = new TextBox();
            textBox_arraySize = new TextBox();
            textBox_distance = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            rtb_route = new RichTextBox();
            rtb_visited = new RichTextBox();
            lbl_visited = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(623, 421);
            label1.Name = "label1";
            label1.Size = new Size(165, 20);
            label1.TabIndex = 0;
            label1.Text = "---Bagus Hendrawan---";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(14, 12);
            label2.Name = "label2";
            label2.Size = new Size(281, 32);
            label2.TabIndex = 1;
            label2.Text = "Search Method Program";
            // 
            // comboBox_startCity
            // 
            comboBox_startCity.AllowDrop = true;
            comboBox_startCity.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_startCity.ForeColor = SystemColors.Desktop;
            comboBox_startCity.FormattingEnabled = true;
            comboBox_startCity.Items.AddRange(new object[] { "Abilene", "Andover", "Anthony", "Argonia", "Attica", "Augusta", "Bluff_City", "Caldwell", "Cheney", "Clearwater", "Coldwater", "Derby", "El_Dorado", "Emporia", "Florence", "Greensburg", "Harper", "Haven", "Hays", "Hillsboro", "Hutchinson", "Junction_City", "Kingman", "Kiowa", "Leon", "Lyons", "Manhattan", "Marion", "Mayfield", "McPherson", "Medicine_Lodge", "Mulvane", "Newton", "Oxford", "Pratt", "Rago", "Salina", "Sawyer", "South_Haven", "Topeka", "Towanda", "Viola", "Wellington", "Wichita", "Winfield", "Zenda" });
            comboBox_startCity.Location = new Point(23, 89);
            comboBox_startCity.Margin = new Padding(3, 4, 3, 4);
            comboBox_startCity.Name = "comboBox_startCity";
            comboBox_startCity.Size = new Size(200, 25);
            comboBox_startCity.TabIndex = 2;
            comboBox_startCity.Text = "Choose_City";
            // 
            // comboBox_endCity
            // 
            comboBox_endCity.AllowDrop = true;
            comboBox_endCity.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_endCity.ForeColor = SystemColors.Desktop;
            comboBox_endCity.FormattingEnabled = true;
            comboBox_endCity.Items.AddRange(new object[] { "Abilene", "Andover", "Anthony", "Argonia", "Attica", "Augusta", "Bluff_City", "Caldwell", "Cheney", "Clearwater", "Coldwater", "Derby", "El_Dorado", "Emporia", "Florence", "Greensburg", "Harper", "Haven", "Hays", "Hillsboro", "Hutchinson", "Junction_City", "Kingman", "Kiowa", "Leon", "Lyons", "Manhattan", "Marion", "Mayfield", "McPherson", "Medicine_Lodge", "Mulvane", "Newton", "Oxford", "Pratt", "Rago", "Salina", "Sawyer", "South_Haven", "Topeka", "Towanda", "Viola", "Wellington", "Wichita", "Winfield", "Zenda" });
            comboBox_endCity.Location = new Point(23, 166);
            comboBox_endCity.Margin = new Padding(3, 4, 3, 4);
            comboBox_endCity.Name = "comboBox_endCity";
            comboBox_endCity.Size = new Size(200, 25);
            comboBox_endCity.TabIndex = 3;
            comboBox_endCity.Text = "Choose_City";
            // 
            // comboBox_method
            // 
            comboBox_method.AllowDrop = true;
            comboBox_method.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_method.ForeColor = SystemColors.Desktop;
            comboBox_method.FormattingEnabled = true;
            comboBox_method.Items.AddRange(new object[] { "Brute-Force Approach (Recursive)", "Breadth-First Search (BFS)", "Depth-First Search (DFS)", "ID-DFS", "Best-First Search", "A* Search" });
            comboBox_method.Location = new Point(23, 310);
            comboBox_method.Margin = new Padding(3, 4, 3, 4);
            comboBox_method.Name = "comboBox_method";
            comboBox_method.Size = new Size(200, 25);
            comboBox_method.TabIndex = 6;
            comboBox_method.Text = "Choose_Method";
            // 
            // button_search
            // 
            button_search.Location = new Point(23, 354);
            button_search.Margin = new Padding(3, 4, 3, 4);
            button_search.Name = "button_search";
            button_search.Size = new Size(86, 31);
            button_search.TabIndex = 8;
            button_search.Text = "Search";
            button_search.UseVisualStyleBackColor = true;
            button_search.MouseClick += button_search_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(23, 393);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(200, 13);
            progressBar1.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.Location = new Point(286, 62);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 11;
            label7.Text = "Route :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label8.Location = new Point(286, 281);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 12;
            label8.Text = "Distance :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label9.Location = new Point(551, 334);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 13;
            label9.Text = "Array Size :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label12.Location = new Point(286, 333);
            label12.Name = "label12";
            label12.Size = new Size(95, 20);
            label12.TabIndex = 17;
            label12.Text = "Total Time :";
            // 
            // textBox_totalTime
            // 
            textBox_totalTime.Location = new Point(387, 332);
            textBox_totalTime.Name = "textBox_totalTime";
            textBox_totalTime.ReadOnly = true;
            textBox_totalTime.Size = new Size(125, 27);
            textBox_totalTime.TabIndex = 19;
            // 
            // textBox_arraySize
            // 
            textBox_arraySize.Location = new Point(646, 332);
            textBox_arraySize.Name = "textBox_arraySize";
            textBox_arraySize.ReadOnly = true;
            textBox_arraySize.Size = new Size(125, 27);
            textBox_arraySize.TabIndex = 20;
            // 
            // textBox_distance
            // 
            textBox_distance.Location = new Point(387, 281);
            textBox_distance.Name = "textBox_distance";
            textBox_distance.ReadOnly = true;
            textBox_distance.Size = new Size(264, 27);
            textBox_distance.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(23, 286);
            label5.Name = "label5";
            label5.Size = new Size(114, 20);
            label5.TabIndex = 7;
            label5.Text = "Search Method";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(23, 142);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 5;
            label4.Text = "Destination City";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(23, 65);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 4;
            label3.Text = "Start City";
            // 
            // rtb_route
            // 
            rtb_route.Location = new Point(387, 60);
            rtb_route.Name = "rtb_route";
            rtb_route.ReadOnly = true;
            rtb_route.Size = new Size(384, 92);
            rtb_route.TabIndex = 27;
            rtb_route.Text = "";
            // 
            // rtb_visited
            // 
            rtb_visited.Location = new Point(387, 168);
            rtb_visited.Name = "rtb_visited";
            rtb_visited.ReadOnly = true;
            rtb_visited.Size = new Size(384, 92);
            rtb_visited.TabIndex = 29;
            rtb_visited.Text = "";
            // 
            // lbl_visited
            // 
            lbl_visited.AutoSize = true;
            lbl_visited.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_visited.Location = new Point(286, 170);
            lbl_visited.Name = "lbl_visited";
            lbl_visited.Size = new Size(67, 20);
            lbl_visited.TabIndex = 28;
            lbl_visited.Text = "Visited :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(564, 354);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 30;
            label6.Text = "(Sum)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(label6);
            Controls.Add(rtb_visited);
            Controls.Add(lbl_visited);
            Controls.Add(rtb_route);
            Controls.Add(textBox_distance);
            Controls.Add(textBox_arraySize);
            Controls.Add(textBox_totalTime);
            Controls.Add(label12);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(progressBar1);
            Controls.Add(button_search);
            Controls.Add(label5);
            Controls.Add(comboBox_method);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox_endCity);
            Controls.Add(comboBox_startCity);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        public ComboBox comboBox_startCity;
        public ComboBox comboBox_endCity;
        public ComboBox comboBox_method;
        private Button button_search;
        private ProgressBar progressBar1;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label12;
        private TextBox textBox_totalTime;
        private TextBox textBox_arraySize;
        private TextBox textBox_distance;
        private Label label5;
        private Label label4;
        private Label label3;
        private RichTextBox rtb_route;
        private RichTextBox rtb_visited;
        private Label lbl_visited;
        private Label label6;
    }
}