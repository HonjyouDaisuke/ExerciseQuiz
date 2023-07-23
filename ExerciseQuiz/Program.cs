// See https://aka.ms/new-console-template for more information

//using System;
//using System.ComponentModel.Design;
//using System.Runtime.CompilerServices;
//using System.Text;

namespace ExcersizeQuiz
{
    class Program
    {
        const int n = 20;

        /// <summary>
        /// 2023.07.23 D.Honjyou
        /// 課題配列を作成
        /// n個ある配列に、ランダムな変数(0 ～ n-1)を挿入
        /// </summary>
        /// <param name="array">挿入する配列</param>
        static void MakeArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Random random = new Random();

                array[i] = random.Next(0, array.Length - 1);
            }
        }

        /// <summary>
        /// 2023.07.23 D.Honjyou
        /// 関数A (メモリは消費するが、早い（ループ回数はn回)
        /// チェック配列を使って使っている数字をチェックする
        /// </summary>
        /// <param name="array">問題の配列</param>
        /// <returns>発生していない数字を文字列で表現</returns>
        static string FuncA(int[] array)
        {
            string result = "";

            //チェック配列を作成
            bool[] num_check = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                num_check[i] = false;
            }

            //使われた数字かどうかをチェックする
            for (int i = 0; i < array.Length; i++)
            {
                num_check[array[i]] = true;
            }

            //出力文字列を作成
            for (int i = 0; i < array.Length; i++)
            {
                if (!num_check[i]) {
                    if (result.Length > 0) result += $",{i}";
                    else result += $"{i}";
                }
            }

            result = "[" + result + "]";

            return result;
        }

        /// <summary>
        /// 2023.07.23 D.Honjyou
        /// 関数B（メモリ消費は最小限だが、遅い(ループ回数が最大n*n)）
        /// ２重ループで解決する方法
        /// </summary>
        /// <param name="array">問題の配列</param>
        /// <returns>発生していない数字を文字列で表現</returns>
        static string FuncB(int[] array)
        {
            string result = "";

            //２重ループで解決
            for(int j=0; j < array.Length; j++)
            {
                bool check = false;
                for(int i=0; i < array.Length; i++)
                {
                    if(j == array[i])
                    {
                        check = true;
                        break;
                    }
                }

                //使われているかどうかを確認した結果使われていなければ文字列に追記
                if (!check)
                {
                    if (result.Length > 0) result += $",{j}";
                    else result += $"{j}";
                }
            }

            result = "[" + result + "]";

            return result;
        }

        /// <summary>
        /// 2023.07.23 D.Honjyou
        /// 関数C (ソートをしてからチェックをするので、メモリ使用量は少なく、ループ回数も少ない）
        /// 課題の配列を一旦ソートしてからチェックする。
        /// </summary>
        /// <param name="array">問題の配列</param>
        /// <returns>発生していない数字を文字列で表現</returns>
        static string FuncC(int[] array)
        {
            string result = "";
            //ソートのためクローンを作成
            int[] local_array = (int[])array.Clone();
            int current_index = 0;

            Array.Sort(local_array);
            for(int i=0; i<local_array.Length; i++)
            {
                if (i != local_array[current_index])
                {
                    if (result.Length > 0) result += $",{i}";
                    else result += $"{i}";
                }
                else
                {
                    for(int j=current_index; j < local_array.Length; j++)
                    {
                        if(local_array[current_index] != local_array[j])
                        {
                            current_index = j;
                            break;
                        }
                    }
                }
            }

            result = "[" + result + "]";

            return result;
        }

        /// <summary>
        /// メイン関数
        /// </summary>
        static void Main()
        {
            int[] array = new int[n];

            //問題の配列を作成（ランダムにn個の数字(0～n-1)の配列）
            MakeArray(array);

            //作成した問題配列を表示
            Console.Write("作成した配列=[");
            for(int i = 0; i < array.Length; i++)
            {
                if(i == 0) Console.Write(array[i]);
                else Console.Write($",{array[i]}");
            }
            Console.Write("]\n");

            //関数A
            Console.WriteLine("関数A:チェック配列を使った回答");
            Console.WriteLine(FuncA(array) + "\n");

            //関数B
            Console.WriteLine("関数B:２重ループを使った回答");
            Console.WriteLine(FuncB(array) + "\n");
            
            //関数C
            Console.WriteLine("関数C:ソートした後にチェックをした回答");
            Console.WriteLine(FuncC(array) + "\n");
            
        }
    }
}

