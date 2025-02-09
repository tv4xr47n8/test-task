using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Class1 // 
{

    public  int CalcCounter(int[] a)//собственно фуекция подсчёта фишек
    {
         int cnt = 0;
         int i = 0, i1 = 1;
         int max, min, max_ind=0, min_ind=0;
         Boolean fl = true;

         if (!ValidateInput(a))//если количество фишек не делится поровну на число мест, то такие исходные данные считаются некорректными
            return -1;

        while (true)
        {
            fl = false;
            max = a[0];
            min = a[0];
            for (i = 0; i < a.Length; i++)//пройдти по всему массиву и найти максимальное и минимальное значение с их индексами
            {
                if (max < a[i])
                {
                    max = a[i];
                    max_ind = i;
                    fl = true;
                }
                if (min > a[i])
                {
                    min = a[i];
                    min_ind = i;
                    fl = true;
                }
            }
            if (!fl)  //если не найдено максимального и минимального значения, то все значения одинаковы, это условия для выхода
                   break;

            i1 = Math.Abs(max_ind - min_ind); //определить, сколько действий нужно для перемещения одной фишки от максимума к минимуму
            if (i1 <= a.Length / 2)
                cnt += i1;
            else cnt += Math.Min(max_ind, min_ind) + a.Length - Math.Max(max_ind, min_ind); // с учётом, что массив зациклен

            a[max_ind]--;// переместить одну фишку с максимума в минимум
            a[min_ind]++;
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
