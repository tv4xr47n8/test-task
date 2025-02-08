using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Class1
{
    private int ccc;
    public  int CalcCounter(int[] a)
    {
         int cnt = 0;
         int i = 0, i1 = 1;
         int max, min, max_ind=0, min_ind=0;
         Boolean fl = true;

         if (!ValidateInput(a))
            return -1;

        while (fl)
        {
            fl = false;
            max = a[0];
            min = a[0];
            for (i = 0; i < a.Length; i++)
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
            if (!fl)
                   break;

            i1 = Math.Abs(max_ind - min_ind);
            if (i1 <= a.Length / 2)
                cnt += i1;
            else cnt += Math.Min(max_ind, min_ind) + a.Length - Math.Max(max_ind, min_ind);

            a[max_ind]--;
            a[min_ind]++;
        }
          
         return cnt;
    }

    public int CalcCounter(string s)
    {
        int[] a;

        StrToIntArr(s, out a);
        return CalcCounter(a);
    }

    private bool ValidateInput(int[] a)
    {
        int i, count = 0;

        for (i = 0; i < a.Length; i++)
            count += a[i];

        return count % a.Length == 0;

    }


    private ushort StrToIntArr(string inp, out int[] a)
    {
        //int outp = new int[];
        ushort cnt = 0;
        ushort i, j = 0;
        string str = ""; //= new string('\0', 15);
        int[] b = new int[100];

        for (i = 0; i <= inp.Length; i++)
        {
            if (i == inp.Length || inp[i] == ' ')
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
            int[] aa = new int[5];

            aa[0] = 1;
            aa[1] = 5;
            aa[2] = 9;
            aa[3] = 10;
            aa[4] = 5;

            Class1 cl = new Class1();

            while (true)
            {
                Console.WriteLine("Введите массив через пробел");
                a = cl.CalcCounter(Console.ReadLine());

              Console.WriteLine($"Count: {a}");
            }
            Console.Read();
        }
    }
}
