using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
{
    //класс решения судоку
    internal class Decision
    {
        public Decision() { }

        //поле судоку размером 9х9
        //нужен только для проверки решабельности
        public int[,] minisud =  {
        { 12, 5, 7, 12, 2, 3, 12, 1, 6 },
        { 1, 4, 12, 7, 12, 6, 8, 12, 2 },
        { 12, 3, 6, 9, 1, 8, 12, 5, 4 },

        { 5, 8, 1, 12, 9, 7, 6, 12, 3 },
        { 12, 6, 12, 5, 8, 4, 12, 9, 12 },
        { 4, 12, 2, 6, 12, 12, 5, 7, 8 },

        { 9, 2, 12, 12, 6, 5, 12, 8, 7 },
        { 3, 12, 5, 8, 12, 2, 1, 12, 12 },
        { 12, 1, 8, 12, 7, 12, 4, 2, 5 }
        };

        //то что задействовано в проге
        public int[,] MySud = {
        { 12, 5, 7, 12, 2, 3, 12, 1, 6 },
        { 1, 4, 12, 7, 12, 6, 8, 12, 2 },
        { 12, 3, 6, 9, 1, 8, 12, 5, 4 },

        { 5, 8, 1, 12, 9, 7, 6, 12, 3 },
        { 12, 6, 12, 5, 8, 4, 12, 9, 12 },
        { 4, 12, 2, 6, 12, 12, 5, 7, 8 },

        { 9, 2, 12, 12, 6, 5, 12, 8, 7 },
        { 3, 12, 5, 8, 12, 2, 1, 12, 12 },
        { 12, 1, 8, 12, 7, 12, 4, 2, 5 }
        };

        //обнуляем все судоку
        public void ClearSUD(int[,] sud)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sud[i, j] = 12;
                }
            }
        }


        //листы флагов, позволяющие вычислить одно возможное число
        //int horizontal, vertical, square;
        List<int> flags = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        List<int> flags_h = new List<int>();
        List<int> flags_v = new List<int>();
        List<int> flags_s = new List<int>();

        //листы для попарного сравнения
        List<int> l1 = new List<int>();
        List<int> l2 = new List<int>();
        List<int> l3 = new List<int>();

        List<int> l1v = new List<int>();
        List<int> l1s = new List<int>();
        List<int> l2h = new List<int>();
        List<int> l2s = new List<int>();
        List<int> l3h = new List<int>();
        List<int> l3v = new List<int>();

        //лист с однозначными значениями
        List<int> l_res = new List<int>();

        //проверка на то не пустое ли поле
        public int isEMPTY(int[,] array )
        {
            int c = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (array[i, j] == 12)
                        c++;
                }
            }

            return c;
            
        }
        public bool CanYouSolve()
        {
            bool canSolve = true;
            // то се 5 10
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    minisud[i,j] = MySud[i,j];
                }
            }

            if ((isEMPTY(minisud) == 81)&(isEMPTY(MySud) == 81))
            {
                { canSolve = false; }
            }
            else
            {
                minisud = Stupid_Unit(MySud);

                //по факту тот же алгоритм что в глупых единицах
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        //на всякий пожарный
                        if (minisud[i, j] == 12)
                            { canSolve = false;}
                        //проверка вертикали
                        for (int c = 0; c < 9; c++)
                        {
                            //flags_v.Add(MySud[j, c]);
                            if ((minisud[i, j] == minisud[c, j]) & (i != c))
                            { canSolve = false;}
                        }

                        //проверка горизонтали
                        for (int c = 0; c < 9; c++)
                        {
                            //flags_h.Add(MySud[c, i]);
                            if ((minisud[i, j] == minisud[i, c]) & (j != c))
                            { canSolve = false; }
                        }

                        //проверка квадратика
                        //int a = id_square(i, j);
                        int k = 0, l = 0;

                        if ((j < 3) & (i < 3)) { k = 3; l = 3; }
                        else
                        if ((j < 6) & (i < 3)) { k = 6; l = 3; }
                        else
                        if ((j < 9) & (i < 3)) { k = 9; l = 3; }
                        else

                        if ((j < 3) & (i < 6)) { k = 3; l = 6; }
                        else
                        if ((j < 6) & (i < 6)) { k = 6; l = 6; }
                        else
                        if ((j < 9) & (i < 6)) { k = 9; l = 6; }
                        else

                        if ((j < 3) & (i < 9)) { k = 3; l = 9; }
                        else
                        if ((j < 6) & (i < 9)) { k = 6; l = 9; }
                        else
                        if ((j < 9) & (i < 9)) { k = 9; l = 9; }

                        //смотрим на конкретный квадратик где обозревается ячейка

                        for (int ll = l - 3; ll < l; ll++)
                        {
                            for (int kk = k - 3; kk < k; kk++)
                            {
                                //flags_s.Add(MySud[kk, ll]);
                                if ((minisud[i, j] == minisud[ll, kk]) & (i != ll) & (j != kk))
                                { canSolve = false;}
                            }
                        }
                    }
                }
            }
            return canSolve;
        }

        public List<int> LIST_ENABLED(List<int> l1, List<int> l2)
        {
            List<int> l3 = new List<int>();

            int c = 0;

            for (int i = 0; i < l1.Count; i++)
            {
                for (int j = 0; j < l2.Count; j++)
                {
                    if (l1[i] == l2[j])
                        c++;
                    //если вышло так что на последнем шаге есть единственный уникальный элемент
                    if ((j == l2.Count - 1) & (c == 0))
                    {
                        l3.Add(l1[i]);
                    }
                }
                c = 0;
            }
            return l3;
        }

        //отработал алгоритм глупой единицы
        //голые тройки 
        bool trese = false;
        //голые четверки
        bool quatro = false;

        //алгоритм который я назвала глупым юнитом
        //есть ли в судоку такая клетка, в которую можно однозначно записать лишь одно число?
        public int[,] Stupid_Unit( int[,] thissud)
        {
            //if (canSolve == true)
            {
                //проверяем каждую клеточку, чтобы совпало три условия
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        //j и i местами не менять!!!!
                        //если сейчас клетка пуста
                        if (thissud[j, i] == 12)
                        {
                            //проверка вертикали
                            for (int c = 0; c < 9; c++)
                            {
                                flags_v.Add(thissud[j, c]);
                            }

                            //проверка горизонтали
                            for (int c = 0; c < 9; c++)
                            {
                                flags_h.Add(thissud[c, i]);
                            }

                            //проверка квадратика
                            //int a = id_square(i, j);
                            int k = 0, l = 0;

                            if ((j < 3) & (i < 3)) { k = 3; l = 3; }
                            else
                            if ((j < 6) & (i < 3)) { k = 6; l = 3; }
                            else
                            if ((j < 9) & (i < 3)) { k = 9; l = 3; }
                            else

                            if ((j < 3) & (i < 6)) { k = 3; l = 6; }
                            else
                            if ((j < 6) & (i < 6)) { k = 6; l = 6; }
                            else
                            if ((j < 9) & (i < 6)) { k = 9; l = 6; }
                            else

                            if ((j < 3) & (i < 9)) { k = 3; l = 9; }
                            else
                            if ((j < 6) & (i < 9)) { k = 6; l = 9; }
                            else
                            if ((j < 9) & (i < 9)) { k = 9; l = 9; }

                            //смотрим на конкретный квадратик где обозревается ячейка

                            for (int ll = l - 3; ll < l; ll++)
                            {
                                for (int kk = k - 3; kk < k; kk++)
                                {
                                    flags_s.Add(thissud[kk, ll]);
                                }
                            }

                            //теперь сравниваем листы чтобы получить элементы которых нет в общем списке
                            //здесь проверяются цифры которых нет по верт, горизонт и в квардрате
                            l1 = LIST_ENABLED(flags, flags_h);
                            l2 = LIST_ENABLED(flags, flags_v);
                            l3 = LIST_ENABLED(flags, flags_s);

                            //здесь нужно менять алгоритм
                            //попарно сравниваем места где также могут быть повторы
                            l1v = LIST_ENABLED(l1, flags_v);
                            l1s = LIST_ENABLED(l1, flags_s);

                            l2h = LIST_ENABLED(l2, flags_h);
                            l2s = LIST_ENABLED(l2, flags_s);

                            l3h = LIST_ENABLED(l3, flags_h);
                            l3v = LIST_ENABLED(l3, flags_v);

                            int counter = 0;

                            //выявляем то самое особое число
                            for (int b = 0; b < l1v.Count(); b++)
                            {
                                for (int c = 0; c < l1s.Count(); c++)
                                {
                                    if (l1v[b] == l1s[c])
                                    {
                                        counter++;
                                    }
                                    //если это число встретилось во всех пяти списках, значит оно нам надо
                                    if ((counter == 5))
                                    {
                                        l_res.Add(l1v[b]);
                                    }

                                }

                                for (int c = 0; c < l2h.Count(); c++)
                                {
                                    if (l1v[b] == l2h[c])
                                    {
                                        counter++;
                                    }

                                    if (counter == 5)
                                    {
                                        l_res.Add(l1v[b]);
                                    }
                                }

                                for (int c = 0; c < l2s.Count(); c++)
                                {
                                    if (l1v[b] == l2s[c])
                                    {
                                        counter++;
                                    }

                                    if (counter == 5)
                                    {
                                        l_res.Add(l1v[b]);
                                    }

                                }
                                for (int c = 0; c < l3h.Count(); c++)
                                {
                                    if (l1v[b] == l3h[c])
                                    {
                                        counter++;
                                    }

                                    if (counter == 5)
                                    {
                                        l_res.Add(l1v[b]);
                                    }

                                }

                                for (int c = 0; c < l3v.Count(); c++)
                                {
                                    if (l1v[b] == l3v[c])
                                    {
                                        counter++;
                                    }
                                    if (counter == 5)
                                    {
                                        l_res.Add(l1v[b]);
                                    }
                                }

                            }
                            //элементы которые нигде не повторяются
                            //if (coouter_big > 0 | l_res[1] == 0 | MySud[i, j] != 12)
                            //if (coouter_big > 0)
                            //if (proverka == false)
                            //if ((counter == 5)&(l_res[0] != 0))
                            if (l_res.Count != 0)
                            {
                                thissud[j, i] = l_res[0];
                                //SUDOKU.Rows[i].Cells[j].Value = my_sudoku.translate_to_int(my_sudoku.array_states[j, i]);
                                //SUDOKU.Rows[i].Cells[j].Style.BackColor = Color.White;
                                //закончился проход по судоку
                                //break;

                                //stup_un = true; пригодится в будущем

                                flags_h.Clear();
                                flags_v.Clear();
                                flags_s.Clear();

                                l1.Clear();
                                l2.Clear();
                                l3.Clear();

                                l1v.Clear();
                                l1s.Clear();
                                l2h.Clear();
                                l2s.Clear();
                                l3h.Clear();
                                l3v.Clear();

                                l_res.Clear();
                            }
                            else break;

                        }
                    }
                }

            }   
            
            return thissud;
        }
    }

}