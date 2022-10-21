using System.Text.Json;
using System.Configuration;
using RandomSorts.Sorts;
using System.Text;

namespace RandomSorts
{
    internal class Program
    {
        const string CONFIG_URL_PARAMETR_NAME = "RequestURL";

        static void Main()
        {
            // генерация списка
            List<int> nums = new List<int>();

            var rand = new Random(DateTime.Now.Millisecond);

            int size = rand.Next(20, 101);

            StringBuilder stringBuilder = new StringBuilder(1000);
            // вывод сгенерированного списка
            stringBuilder.Append("Сгенерированная последовательность:\n");

            for (int i = 0; i < size; ++i)
            {
                nums.Add(rand.Next(-100, 101));
                stringBuilder.Append($"{nums[i]} ");
            }

            // выбор алгоритма и сортировка списка
            ISorter sorter = new BubbleSorter();

            var sorterNumder = rand.Next(0, 6);

            // если  sorterNumber == 0 sorter остаётся BubbleSorter - ом
            if (sorterNumder == 1) sorter = new InsertionSorter();
            else if (sorterNumder == 2) sorter = new SelectionSorter();
            else if (sorterNumder == 3) sorter = new QuickSorter();
            else if (sorterNumder == 4) sorter = new MergeSorter();
            else if (sorterNumder == 5) sorter = new HeapSorter();

            sorter.Sort(nums);

            // вывод отсортированного списка
            stringBuilder.Append("\n\nОтсортированная последовательность:\n");

            foreach (var num in nums)
                stringBuilder.Append($"{num} ");

            Console.WriteLine(stringBuilder.ToString());

            // отправка списка на сервер в формате json
            string json = JsonSerializer.Serialize(nums);

            PostRequestAsync(json).Wait();
        }

        private static async Task PostRequestAsync(string requestData)
        {
            using (var client = new HttpClient())
            {
                var url = ConfigurationManager.AppSettings[CONFIG_URL_PARAMETR_NAME];
                var content = new StringContent(requestData, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                string resultContent = await result.Content.ReadAsStringAsync();
                //ответ сервера
                //Console.WriteLine(resultContent);
            }
        }
    }
}