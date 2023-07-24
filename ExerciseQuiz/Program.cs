// See https://aka.ms/new-console-template for more information

//using System;
//using System.ComponentModel.Design;
//using System.Runtime.CompilerServices;
//using System.Text;

using System.Text;

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

                array[i] = random.Next(1, array.Length);
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
            string result;
            StringBuilder sb = new StringBuilder();

            //チェック配列を作成
            bool[] num_check = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                num_check[i] = false;
            }

            //使われた数字かどうかをチェックする
            for (int i = 0; i < array.Length; i++)
            {
                num_check[array[i] - 1] = true;
            }

            //出力文字列を作成
            for (int i = 0; i < array.Length; i++)
            {
                if (!num_check[i]) {
                    if (sb.Length > 0) sb.Append($",{i + 1}");
                    else sb.Append($"{i + 1}");
                }
            }

            result = "[" + sb + "]";

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
            string result;
            StringBuilder sb = new StringBuilder();

            //２重ループで解決
            for(int j=0; j < array.Length; j++)
            {
                bool check = false;
                for(int i=0; i < array.Length; i++)
                {
                    if(array[i] == j + 1)
                    {
                        check = true;
                        break;
                    }
                }

                //使われているかどうかを確認した結果使われていなければ文字列に追記
                if (!check)
                {
                    if (sb.Length > 0) sb.Append($",{j + 1}");
                    else sb.Append($"{j + 1}");
                }
            }

            result = "[" + sb + "]";

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
            string result;
            StringBuilder sb = new StringBuilder();

            //ソートのためクローンを作成
            int[] local_array = (int[])array.Clone();
            int current_index = 0;

            Array.Sort(local_array);
            for(int i=0; i<local_array.Length; i++)
            {
                if (local_array[current_index] != i + 1)
                {
                    if (sb.Length > 0) sb.Append($",{i + 1}");
                    else sb.Append($"{i + 1}");
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

            result = "[" + sb + "]";

            return result;
        }

        static string FuncD(int[] array)
        {
            string result;
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<array.Length;i++)
            {
                if(Array.IndexOf(array, i+1) == -1) {
                    if (sb.Length > 0) sb.Append($",{i + 1}");
                    else sb.Append($"{i + 1}");
                }
            }

            result = "[" + sb + "]";

            return result;
        }

        static string FuncE(int[] array)
        {
            string result;
            StringBuilder sb = new StringBuilder();
            ulong Check = 0;

            for (int i = 0; i < array.Length; i++)
            {
                Check |= (ulong)Math.Pow(2, array[i]);
            }

            for (int i = 0; i < array.Length; i++)
            {
                if ((Check & (ulong)Math.Pow(2, i + 1)) == 0)
                {
                    if (sb.Length > 0) sb.Append($",{i + 1}");
                    else sb.Append($"{i + 1}");
                }
            }

            result = "[" + sb + "]";

            return result;
        }


        static string FuncF(int[] array)
        {
            string result;
            StringBuilder sb = new StringBuilder();

            //回答用配列(List)を作成
            var resultList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                resultList.Add(i + 1);
            }

            //使われた数字かどうかをチェックする
            for (int i = 0; i < array.Length; i++)
            {
                resultList.RemoveAll(x => x == array[i]);
            }

            //出力文字列を作成
            foreach(int item in resultList)
            {
                if (sb.Length > 0) sb.Append($",{item}");
                else sb.Append($"{item}");
            }

            result = "[" + sb + "]";

            return result;
        }

        static string FuncG(int[] array)
        {
            string result;
            StringBuilder sb = new StringBuilder();

            //回答用配列を作成
            int[] resultArray = new int[array.Length];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = i + 1;
            }

            //使われた数字かどうかをチェックする
            for (int i = 0; i < array.Length; i++)
            {
                resultArray[array[i] - 1] = 0;
            }

            //出力文字列を作成
            for(int i = 0; i < resultArray.Length; i++)
            {
                if (resultArray[i] != 0)
                {
                    if (sb.Length > 0) sb.Append($",{resultArray[i]}");
                    else sb.Append($"{resultArray[i]}");
                }
            }

            result = "[" + sb + "]";

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

            //関数D
            Console.WriteLine("関数D:IndexOfを使用した回答");
            Console.WriteLine(FuncD(array) + "\n");

            //関数E
            Console.WriteLine("関数E:ビット演算を使用した回答");
            Console.WriteLine(FuncE(array) + "\n");

            //関数F
            Console.WriteLine("関数F:回答配列から削除する方法で回答");
            Console.WriteLine(FuncF(array) + "\n");

            //関数G
            Console.WriteLine("関数G:検索結果を直接回答にする方法で回答");
            Console.WriteLine(FuncF(array) + "\n");
        }
    }
}

