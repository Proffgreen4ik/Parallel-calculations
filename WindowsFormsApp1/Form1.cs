using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
        Random rnd = new Random();
        int[] defaultArr;
        int[] mas1;
        int[] mas2;
        int[] mas3;
        static int swapCount1;
        static int swapCount2;
        static int swapCount3;
        //Создание и заполнение массива
        private void button1_Click(object sender, EventArgs e)
        {
            defaultArr = new int[Convert.ToInt32(textBox1.Text)];
            int startPos = Convert.ToInt32(textBox2.Text);
            int endPos = Convert.ToInt32(textBox3.Text);
            for (int i = 0; i< defaultArr.Length; i++)
            {
                defaultArr[i] = rnd.Next(startPos, endPos+1);
                listBox1.Items.Add(defaultArr[i].ToString());
            }
            mas1 = defaultArr;
            mas2 = defaultArr;
            mas3 = defaultArr;
        }
        //Метод обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        //Сортировка пузырьком
        static int[] BubbleSort(int[] mas)
        {
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int j = 0; j < mas.Length - i - 1; j++)
                {
                    if (mas[j + 1] < mas[j])
                    {
                        Swap(ref mas[j], ref mas[j + 1]);
                        swapCount1++;
                    }
                }
            }
            return mas;
        }
        //Сортировка вставками
        static int[] InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    swapCount2++;
                    j--;
                }
                
                array[j] = key;
            }

            return array;
        }

        //Сортировка Шелла
        static int[] ShellSort(int[] array)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        swapCount3++;
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start(); //запуск
            BubbleSort(mas1);
            myStopwatch.Stop(); //остановить
            textBox4.Text = myStopwatch.Elapsed.ToString();
            textBox7.Text = swapCount1.ToString();
            myStopwatch.Restart(); //запуск
            InsertionSort(mas2);
            myStopwatch.Stop(); //остановить
            textBox5.Text = myStopwatch.Elapsed.ToString();
            textBox8.Text = swapCount2.ToString();
            myStopwatch.Restart(); //запуск
            ShellSort(mas3);
            myStopwatch.Stop(); //остановить
            textBox6.Text = myStopwatch.Elapsed.ToString();
            textBox9.Text = swapCount3.ToString();
            for (int i = 0; i < defaultArr.Length; i++)
            {
                listBox2.Items.Add(mas1[i]);
                listBox3.Items.Add(mas2[i]);
                listBox4.Items.Add(mas3[i]);
            }
            
        }

       //Thread t1 = new Thread(new ParameterizedThreadStart(BubbleSort));
        //Thread t2 = new Thread(new ParameterizedThreadStart(Swap));
        //Thread t3 = new Thread(new ParameterizedThreadStart(InsertionSort));
        //t1.Start(defaultArr);
        //t2.Start(defaultArr);
        //t3.Start(defaultArr);
    }
}
