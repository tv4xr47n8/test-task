using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Class1 // 
{

    public  int CalcCounter(int[] a)//собственно фуекция подсчёта фишек
    {
         int cnt = 0, d_cnt, d_cnt_best;
         int i = 0, j, i1 = 1;
         int max, min, cmax, cmin, min_pos = 0, max_pos = 0;
         int[] max_ind = new int[50], min_ind = new int[50];
         Boolean fl = true;

         if (!ValidateInput(a))//если количество фишек не делится поровну на число мест, то такие исходные данные считаются некорректными
            return -1;

        while (true)
        {
            cmax = 0;
            cmin = 0;
            max = a[0]; 
            min = a[0];
            d_cnt_best = 99999;
            for (i = 0; i < a.Length; i++)//пройдти по всему массиву и найти максимальное и минимальное значение
            {
                if (max < a[i])
                    max = a[i];

                if (min > a[i])
                    min = a[i];          
            }
            if (max == a[0] && min == a[0])  //если не найдено максимального и минимального значения, то все значения одинаковы, это условия для выхода
                   break;

            for (i = 0; i < a.Length; i++)// найти позиции всех максимумов и минимумов
            {
                if (a[i] == max)
                {
                    max_ind[cmax] = i;
                    cmax++;
                }
                if (a[i] == min)
                {
                    min_ind[cmin] = i;
                    cmin++;
                }       
            }

            for (i = 0; i < cmax; i++) //найти ближайшие максимумы и минимумы
                for (j = 0; j < cmin; j++)
                { 
                   i1 = Math.Abs(max_ind[i] - min_ind[j]); //определить, сколько действий нужно для перемещения одной фишки от максимума к минимуму
                   if (i1 <= a.Length / 2)
                      d_cnt = i1;
                   else d_cnt = Math.Min(max_ind[i], min_ind[j]) + a.Length - Math.Max(max_ind[i], min_ind[j]); // с учётом, что массив зациклен
                   if (d_cnt < d_cnt_best)
                    {
                        d_cnt_best = d_cnt;
                        min_pos = min_ind[j];
                        max_pos = max_ind[i];
                    }
                }

            cnt += d_cnt_best;
            a[max_pos]--;// переместить одну фишку с максимума в минимум
            a[min_pos]++;
        }
          
         return cnt;
    }

    public int CalcCounter(string s) // если входные данные -- строка, которую ещё нужно распарсить
    {
        int[] a;

        StrToIntArr(s, out a);
        return CalcCounter(a);
    }

    private bool ValidateInput(int[] a) // проверка, подходят ли исходные данные
    {
        int i, count = 0;

        for (i = 0; i < a.Length; i++)
            count += a[i];

        return count % a.Length == 0;

    }


    private ushort StrToIntArr(string inp, out int[] a)// разбор строки на массив с числами, разделителем считается пробел
    {
        ushort i, j = 0;
        string str = ""; 
        int[] b = new int[100];

        for (i = 0; i <= inp.Length; i++)
        {
            if ((i == inp.Length || inp[i] == ' ') && str != "")
            {
                b[j] = Convert.ToInt16(str);
                str = "";
                j++; 
            }
            else
            {
                str += inp[i];
            }

        }

        a = new int[j];
        for (i = 0; i < j; i++)
            a[i] = b[i];

        return j;

    }
}



namespace ConsoleApplication1
{
    class Program
    {


        static void Main(string[] args)
        {
            int a;


            Class1 cl = new Class1();

            while (true) // ввод данных, бесконечный, до выхода из программы
            {
                Console.WriteLine("Введите массив через пробел");
                a = cl.CalcCounter(Console.ReadLine());

              Console.WriteLine($"Count: {a}");
            }
   
        }
    }
}
