using System.Text.Json;

namespace Serealize.Domain.Entities
{
    public static class ArrayApp
    {
        private static bool IsFibonacci(int n)
        {
            if (n < 0) return false;
            if (n == 0 || n == 1) return true;

            int a = 0, b = 1;
            while (b < n)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }

            return b == n;
        }
        private static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            // Проверяем делители вида 6k ± 1 до sqrt(n)
            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }
        public static int[] FiltrArray(bool justNums, bool fibonacciNums,params int[] arr)
        {
            if (justNums)
            {
                    arr = arr.Where(n => !IsPrime(n)).ToArray();
            }
            if (fibonacciNums)
            {
                arr = arr.Where(n => !IsFibonacci(n)).ToArray();
            }
            return arr;
        }
        public static void JsonSerealizeArray( string directory,bool justNums, bool fibonacciNums,params int[]  arr)
        {
            // выбрал формат Json, для сереализации так как он самый популярный и скорее всего в проекте у меня будет работа с Json
            if (fibonacciNums || justNums)
            {
                FiltrArray(justNums, fibonacciNums, arr);
            }
            string jsonString = JsonSerializer.Serialize(arr);
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, "SerializedArray.json");
                File.WriteAllText(path, jsonString);
            }else
            {
                throw new DirectoryNotFoundException($"Directory not found: {directory}");
            }
        }
        public static int[] JsonDeserealizeArray(string directory,string filename)
        {
            string path = Path.Combine(directory, filename + ".json");
            if (File.Exists(path))
            {
                string FileContent = File.ReadAllText(path);
                int[] arr = JsonSerializer.Deserialize<int[]>(FileContent) ?? Array.Empty<int>();
                //?? Array.Empty<int>() таким образом он возвращает не null а пустой массив
                return arr;

            }else
            {
                throw new DirectoryNotFoundException($"Directory not found: {directory}");
            }
        }
        public static int[] JsonDeserealizeArray(string source)
        {

            if (File.Exists(source))
            {
                string FileContent = File.ReadAllText(source);
                int[] arr = JsonSerializer.Deserialize<int[]>(FileContent) ?? Array.Empty<int>();
                //?? Array.Empty<int>() таким образом он возвращает не null а пустой массив
                return arr;
            }
            else
            {
                throw new FileNotFoundException($"File not found: {source}");
            }
        }
    }
}
