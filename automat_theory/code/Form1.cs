using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //здесь производятся настройки поля судоку
            //и другие параметры приложения
            SUDOKU.Width = 450;
            SUDOKU.Height = 450;

            SUDOKU.RowCount = 9;
            SUDOKU.ColumnCount = 9;

            SUDOKU.RowTemplate.Height = 50;

            for (int i = 0; i < 9; i++) 
            {
                SUDOKU.Columns[i].Width = 50;
            }

            SUDOKU.ColumnHeadersVisible = false;
            SUDOKU.RowHeadersVisible = false;

            foreach (DataGridViewColumn c in SUDOKU.Columns)
            {
                SUDOKU.DefaultCellStyle.Font = new Font("Verdana", 16);
            }

            //my_sudoku.States_Sud_PULL();

            //print_sudoku();

            timer.Interval = 1000; //интервал между срабатываниями 1000 миллисекунд
            timer.Tick += new EventHandler(timer_Tick); //подписываемся на события Tick
                                                        //timer.Start();

            print_sudoku();

            this.SUDOKU.ScrollBars = ScrollBars.None;

            //SUDOKU.AllowUserToAddRows = false;
            //SUDOKU.AllowUserToDeleteRows = false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    if ((j < 3) & (i < 3))              { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Moccasin; }    //белый
                    else
                    if ((j < 6) & (i < 3) & (j >= 3))   { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Linen; }
                    else
                    if ((j < 9) & (i < 3))              { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Moccasin; }    //белый
                    else

                    if ((j < 3) & (i < 6)) { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Linen; }
                    else
                    if ((j < 6) & (i < 6)) { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Moccasin; }
                    else
                    if ((j < 9) & (i < 6)) { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Linen; }
                    else

                    if ((j < 3) & (i < 9)) { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Moccasin; }
                    else
                    if ((j < 6) & (i < 9)) { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Linen; }
                    else
                    if ((j < 9) & (i < 9)) { SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.Moccasin; }
                }
            }//

            trackBar.Minimum = 1;
            trackBar.Maximum = 81;
            trackBar.Scroll+=trackBar1_Scroll;

        }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int timerCounter = 0; //счётчик для таймера

        //обработчик события Tick
        void timer_Tick(object sender, EventArgs e)
        {
            //В текстбокс выводим значение timerCounter увеличенное на 1
            //this.text_timer.Text = (++timerCounter).ToString();

        }

        //объект класса решатель
        Decision my_sudoku = new Decision();

        //кнопка решить судоку
        private void Button_Solve(object sender, EventArgs e)
        {
            //берем цифры записаные в поле
            //if (my_sudoku_flag == false)
            {
                NewSudokuPrint();

                my_sudoku.CanYouSolve();
                if (my_sudoku.isEMPTY(my_sudoku.MySud) == 81)
                {
                    MessageBox.Show("Поле пустое!");
                }
                else
                if (my_sudoku.CanYouSolve() == true)
                {
                    // проверяем глупые единицы
                    my_sudoku.MySud = my_sudoku.Stupid_Unit(my_sudoku.MySud);

                    print_sudoku();

                    my_sudoku.ClearSUD(my_sudoku.minisud);
                }
                else
                {
                    MessageBox.Show("Задача не имеет однозначного решения");
                }
            }

        }
        public void print_sudoku()
        {
            for (int i = 0;i < 9;i++) 
            {
                for (int j = 0;j < 9;j++) 
                {
                    if (my_sudoku.MySud[i, j] != 12)
                        SUDOKU[i, j].Value = my_sudoku.MySud[i, j];
                    else SUDOKU[i, j].Value = "";
                }
            }
        }

        //печать судоку из окна в поле класса решения
        private void NewSudokuPrint()
        {
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    var cellValue = SUDOKU.Rows[j].Cells[i].Value;
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int a))
                    {
                        if ((a > 0) & (a < 10))
                            my_sudoku.MySud[i, j] = a;
                    }
                    else
                    {
                        my_sudoku.MySud[i, j] = 12;
                    }
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Generate Gen = new Generate();

            //новый объект класса gen 
            //это генерация судоку
            my_sudoku.ClearSUD(my_sudoku.MySud);
            my_sudoku.ClearSUD(my_sudoku.minisud);

            //непосредственно генерация
            Gen.GridToZero();
            Gen.GenerateGrid();
            Gen.RemoveCells(sudoku_numder);
            Gen.ClearSud();

            my_sudoku.MySud = Gen.grid;
            my_sudoku.minisud = Gen.grid;

            print_sudoku();

            Gen = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //кнопка очистки Судоку
        private void button2_Click_1(object sender, EventArgs e)
        {
            my_sudoku.ClearSUD(my_sudoku.MySud);
            my_sudoku.ClearSUD(my_sudoku.minisud);

            print_sudoku();

            if ((my_sudoku.isEMPTY(my_sudoku.minisud) == 81)& (my_sudoku.isEMPTY(my_sudoku.MySud) == 81))
            {
                MessageBox.Show("Успешно очищено");
            }

        }

        //проверка того можно ли решать судоку
        private void Button_check_Click(object sender, EventArgs e)
        {
            NewSudokuPrint();
            my_sudoku.CanYouSolve();

            if (my_sudoku.CanYouSolve() == false)
            {
                MessageBox.Show("Эта задача не имеет однозначного решения");
            }
            else
            {
                MessageBox.Show("Эта задача имеет однозначное решение");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int sudoku_numder;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sudoku_numder = (int)trackBar.Value;
            label1.Text = String.Format("Текущее значение: {0}", trackBar.Value);
        }

    }
}
