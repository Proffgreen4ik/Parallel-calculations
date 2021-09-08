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
        }
        //Сортировка пузырьком
        static int[] BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int j = 0; j < mas.Length - i - 1; j++)
                {
                    if (mas[j + 1] < mas[j])
                    {
                        temp = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        //Метод обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
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
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < defaultArr.Length; i++)
            {
                BubbleSort(defaultArr);
                listBox2.Items.Add(defaultArr[i]);
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
