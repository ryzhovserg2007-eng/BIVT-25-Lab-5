using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                int minIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }
                answer[i] = minIndex;
            }

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }
                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / max);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m || k < 0 || k >= m) return;

            int max = matrix[0, 0];
            int maxind = 0;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxind = i;
                }
            }

            if (maxind == k) return;

            for (int row = 0; row < n; row++)
            {
                (matrix[row, k], matrix[row, maxind]) = (matrix[row, maxind], matrix[row, k]);
            }

            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int max = int.MinValue;
            int maxind = -1;

            if (rows != cols) return;

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxind = i;
                }

            }

            for (int i = 0; i < rows; i++)
            {
                (matrix[i, maxind], matrix[maxind, i]) = (matrix[maxind, i], matrix[i, maxind]);
            }

            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int maxSum = 0;
            int maxInd = -1;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > 0)
                        sum += matrix[i, j];

                if (sum > maxSum || maxInd == -1)
                {
                    maxSum = sum;
                    maxInd = i;
                }
            }

            if (maxInd != -1)
            {
                answer = new int[n - 1, m];
                int rowid = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i == maxInd) continue;
                    for (int j = 0; j < m; j++)
                    {
                        answer[rowid, j] = matrix[i, j];

                    }
                    rowid++;
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int maxNeg = -1;  // максимальное кол-во отрицательных
            int minNeg = int.MaxValue; // минимальное кол-во отрицательных
            int maxIndex = -1;
            int minIndex = -1;

            // Находим строки с минимальным и максимальным количеством отрицательных
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }

                if (count > maxNeg)
                {
                    maxNeg = count;
                    maxIndex = i;
                }

                if (count < minNeg)
                {
                    minNeg = count;
                    minIndex = i;
                }
            }


            if (maxNeg == minNeg) // если все строки имеют одинаковое количество отрицательных - обмен не нужен
                return;


            for (int j = 0; j < m; j++) // меняем строки местами
            {
                (matrix[minIndex, j], matrix[maxIndex, j]) = (matrix[maxIndex, j], matrix[minIndex, j]);
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (array.Length != n) return matrix;

            int min = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            int st = m;

            for (int j = 0; j < m; j++)
            {
                bool y = false;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] == min)
                    {
                        st = j;
                        break;
                    }
                }
                if (st != m) break;
            }

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int x = 0;
                for (int j = 0; j < m + 1; j++)
                {
                    if (j == st + 1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[i, x++];
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int pos = 0;
                int neg = 0;

                int max = matrix[0, j];
                int maxst = 0;

                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0) pos++;
                    if (matrix[i, j] < 0) neg++;

                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxst = i;
                    }
                }

                if (pos > neg)
                {
                    matrix[maxst, j] = 0;
                }
                else if (neg > pos)
                {
                    matrix[maxst, j] = maxst;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            for (int k = 0; k < n; k++)
            {
                matrix[0, k] = 0;
                matrix[n - 1, k] = 0;
                matrix[k, 0] = 0;
                matrix[k, n - 1] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || n != m)
                return (null, null);

            int colelA = n * (n - 1) / 2;
            int colelB = n * (n + 1) / 2;

            A = new int[colelB];
            B = new int[colelA];

            int Ai = 0, Bi = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i) A[Ai++] = matrix[i, j];
                    if (j < i) B[Bi++] = matrix[i, j];
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int row = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            for (int j = 0; j < rows; j++)
            {
                int[] size = new int[row];
                for (int i = 0; i < row; i++)
                {
                    size[i] = matrix[i, j];
                }
                if (j % 2 == 0)
                {
                    for (int i = 0; i < row - 1; i++)
                    {
                        for (int k = i + 1; k < row; k++)
                        {
                            if (size[i] < size[k])
                            {
                                int ans = size[i];
                                size[i] = size[k];
                                size[k] = ans;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < row - 1; i++)
                    {
                        for (int k = i + 1; k < row; k++)
                        {
                            if (size[i] > size[k])
                            {
                                int ans = size[i];
                                size[i] = size[k];
                                size[k] = ans;
                            }
                        }
                    }
                }
                for (int i = 0; i < row; i++)
                {
                    matrix[i, j] = size[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null) return;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int countI = 0;
                    int countJ = 0;
                    int sumI = 0;
                    int sumJ = 0;
                    if (array[i] != null)
                    {
                        countI = array[i].Length;
                        for (int k = 0; k < array[i].Length; k++)
                        {
                            sumI += array[i][k];
                        }
                    }
                    if (array[j] != null)
                    {
                        countJ = array[j].Length;
                        for (int k = 0; k < array[j].Length; k++)
                        {
                            sumJ += array[j][k];
                        }
                    }
                    bool answer = false;
                    if (countI < countJ)
                    {
                        answer = true;
                    }
                    else if (countI == countJ && sumI < sumJ)
                    {
                        answer = true;
                    }
                    if (answer)
                    {
                        int[] ans = array[i];
                        array[i] = array[j];
                        array[j] = ans;
                    }
                }
            }
            // end

        }
    }
}
