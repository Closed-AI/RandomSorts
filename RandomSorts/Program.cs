using System.Text.Json;
using System.Configuration;
using System.Collections.Specialized;
using RandomSorts.Sorts;
using System.Text.Json.Serialization;
using System.Net;
using System.Text;
using System.Net.Http.Json;

namespace RandomSorts
{
    internal class Program
    {
        const string CONFIG_URL_PARAMETR_NAME = "RequestURL";

        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            // генерация списка
            List<int> nums = new List<int>();

            var rand = new Random(DateTime.Now.Millisecond);

            int size = rand.Next(20, 101);

            // вывод сгенерированного списка
            Console.WriteLine("Сгенерированная последовательность:\n");

            for (int i = 0; i < size; ++i)
            {
                nums.Add(rand.Next(-100, 101));
                Console.Write(nums[i] + " ");
            }

            // выбор алгоритма и сортировка списка
            ISorter sorter = new BubbleSorter();

            var sorterNumder = rand.Next(0, 6);

                 if (sorterNumder == 0) sorter = new BubbleSorter();
            else if (sorterNumder == 1) sorter = new InsertionSorter();
            else if (sorterNumder == 2) sorter = new SelectionSorter();
            else if (sorterNumder == 3) sorter = new QuickSorter();
            else if (sorterNumder == 4) sorter = new MergeSorter();
            else if (sorterNumder == 5) sorter = new HeapSorter();

            sorter.Sort(nums);

            // вывод отсортированного списка
            Console.WriteLine("\n\nОтсортированная последовательность:\n");

            foreach (var num in nums)
                Console.Write(num + " ");
            
            // отправка списка на сервер в формате json
            string json = JsonSerializer.Serialize(nums);
            await PostRequestAsync(json);
        }

        private static async Task PostRequestAsync(string requestData)
        {
            WebRequest request = WebRequest.Create(ConfigurationManager.AppSettings[CONFIG_URL_PARAMETR_NAME]);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    // ответ сервера
                    //Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
        }
    }
}