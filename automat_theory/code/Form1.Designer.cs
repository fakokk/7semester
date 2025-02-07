namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SUDOKU = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Button_Gen = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.Button_check = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.decisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.decisionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SUDOKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decisionBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // SUDOKU
            // 
            this.SUDOKU.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SUDOKU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SUDOKU.EnableHeadersVisualStyles = false;
            this.SUDOKU.Location = new System.Drawing.Point(16, 210);
            this.SUDOKU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SUDOKU.MaximumSize = new System.Drawing.Size(600, 554);
            this.SUDOKU.Name = "SUDOKU";
            this.SUDOKU.RowHeadersVisible = false;
            this.SUDOKU.RowHeadersWidth = 51;
            this.SUDOKU.RowTemplate.Height = 50;
            this.SUDOKU.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SUDOKU.Size = new System.Drawing.Size(584, 524);
            this.SUDOKU.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 175);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Решить судоку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_Solve);
            // 
            // Button_Gen
            // 
            this.Button_Gen.Location = new System.Drawing.Point(16, 175);
            this.Button_Gen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button_Gen.Name = "Button_Gen";
            this.Button_Gen.Size = new System.Drawing.Size(125, 28);
            this.Button_Gen.TabIndex = 5;
            this.Button_Gen.Text = "Сгенерировать";
            this.Button_Gen.UseVisualStyleBackColor = true;
            this.Button_Gen.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(297, 175);
            this.ButtonClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(92, 28);
            this.ButtonClear.TabIndex = 6;
            this.ButtonClear.Text = "Очистить";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Button_check
            // 
            this.Button_check.Location = new System.Drawing.Point(397, 175);
            this.Button_check.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button_check.Name = "Button_check";
            this.Button_check.Size = new System.Drawing.Size(203, 28);
            this.Button_check.TabIndex = 7;
            this.Button_check.Text = "Проверить решабельность";
            this.Button_check.UseVisualStyleBackColor = true;
            this.Button_check.Click += new System.EventHandler(this.Button_check_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 139);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(584, 28);
            this.progressBar1.TabIndex = 8;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(16, 76);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(584, 56);
            this.trackBar.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Текущее значение: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // decisionBindingSource
            // 
            this.decisionBindingSource.DataSource = typeof(WindowsFormsApp1.Decision);
            // 
            // decisionBindingSource1
            // 
            this.decisionBindingSource1.DataSource = typeof(WindowsFormsApp1.Decision);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 778);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Button_check);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.Button_Gen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SUDOKU);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SUDOKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decisionBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Button_Gen;
        public System.Windows.Forms.DataGridView SUDOKU;
        private System.Windows.Forms.BindingSource decisionBindingSource;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.BindingSource decisionBindingSource1;
        private System.Windows.Forms.Button Button_check;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label1;
    }
}

