namespace lesson_4_2;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = [-2, 10, 2, 31, 4, 5, 16, 7, 8, 9];
        const int target = 17;
        Get3Numbers(arr, target); // 4 варианта
        Console.WriteLine("********************");
        Get3Numbers(arr, 588); // нет вариантов
    }

    private static void Get3Numbers(IReadOnlyList<int> ar, int tar)
    {
        // Пример из лекции некорректен, HashMap использовать нельзя, так как числа могут повторяться и они могут быть значимыми, поэтому List
        var res = new List<Tuple<int, int, int>>();

        for (var j = 0; j < ar.Count; j++)
        {
            var iTarget = tar - ar[j];
            var lst = new List<int>();
            for (var i = j + 1; i < ar.Count; i++)
            {
                if (lst.Contains(iTarget - ar[i]))
                {
                    res.Add(new Tuple<int, int, int>(ar[j], iTarget - ar[i], ar[i]));
                    continue;
                }

                lst.Add(ar[i]);
            }
        }

        if (res.Count > 0)
        {
            Console.WriteLine($"Найдено {res.Count} вар., дают в сумме {tar} ");
            foreach (var n in res) Console.WriteLine($"Числа = {n.Item1}, {n.Item2}, {n.Item3}");
        }
        else
        {
            Console.WriteLine("Нет удовлетворяющих чисел");
        }
    }
}