namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "10m.txt";

            List<int> numbers = ReadNumbersFromFile(filePath);

            if (numbers.Count > 0)
            {
                int count = 0;
                int sum = 0;
                int max = numbers[0];
                int min = numbers[0];
                List<int> longestIncreasingSequence = new List<int>();
                List<int> longestDecreasingSequence = new List<int>();
                List<int> tempIncreasingSequence = new List<int>();
                List<int> tempDecreasingSequence = new List<int>();

                foreach (int number in numbers)
                {
                    count++;
                    sum += number;
                    if (number > max)
                    {
                        max = number;
                    }
                    if (number < min)
                    {
                        min = number;
                    }

                    if (tempIncreasingSequence.Count == 0 || tempIncreasingSequence.Last() < number)
                    {
                        tempIncreasingSequence.Add(number);
                    }
                    else if (tempIncreasingSequence.Count > longestIncreasingSequence.Count)
                    {
                        longestIncreasingSequence = new List<int>(tempIncreasingSequence);
                        tempIncreasingSequence = new List<int>();
                        tempIncreasingSequence.Add(number);
                    }
                    else
                    {
                        tempIncreasingSequence = new List<int>();
                        tempIncreasingSequence.Add(number);
                    }

                    if (tempDecreasingSequence.Count == 0 || tempDecreasingSequence.Last() > number)
                    {
                        tempDecreasingSequence.Add(number);
                    }
                    else if (tempDecreasingSequence.Count > longestDecreasingSequence.Count)
                    {
                        longestDecreasingSequence = new List<int>(tempDecreasingSequence);
                        tempDecreasingSequence = new List<int>();
                        tempDecreasingSequence.Add(number);
                    }
                    else
                    {
                        tempDecreasingSequence = new List<int>();
                        tempDecreasingSequence.Add(number);
                    }
                }
                if (tempIncreasingSequence.Count > longestIncreasingSequence.Count)
                {
                    longestIncreasingSequence = new List<int>(tempIncreasingSequence);
                }
                if (tempDecreasingSequence.Count > longestDecreasingSequence.Count)
                {
                    longestDecreasingSequence = new List<int>(tempDecreasingSequence);
                }

                double average = (double)sum / (double)count;
                double median = CalculateMedian(numbers);

                Console.WriteLine($"Max number: {max}");
                Console.WriteLine($"Min number: {min}");
                Console.WriteLine($"Median: {median}");
                Console.WriteLine($"Avg: {average}");

                if (longestIncreasingSequence.Count > 1)
                    Console.WriteLine($"Longest increasing sequence: {string.Join(", ", longestIncreasingSequence)}");

                if (longestDecreasingSequence.Count > 1)
                    Console.WriteLine($"Longest decreasing sequence: {string.Join(", ", longestDecreasingSequence)}");
            }
            else
            {
                Console.WriteLine("File has no numbers.");
            }
        }

        static List<int> ReadNumbersFromFile(string filePath)
        {
            List<int> numbers = new List<int>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            numbers.Add(number);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return numbers;
        }

        static double CalculateMedian(List<int> numbers)
        {
            int count = numbers.Count;
            numbers.Sort();

            if (count % 2 == 0)
            {
                return (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0;
            }
            else
            {
                return numbers[count / 2];
            }
        }
    }
}