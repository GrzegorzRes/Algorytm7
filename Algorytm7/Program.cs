var numbers1 = new List<int>() { 8, -1, 3, 4 };
var numbers2 = new List<int>() { -4, 5, 1, 0 };
var numbers4 = new List<int>() { -3 , -10, -1, -5};
var numbers5 = new List<int>() { };
var numbers6 = new List<int>() { -1, -2 };
var numbers7 = new List<int>() { 1 };


PrintSubsetWithTheBiggersSum(numbers1);
PrintSubsetWithTheBiggersSum(numbers2);
PrintSubsetWithTheBiggersSum(numbers4);
PrintSubsetWithTheBiggersSum(numbers5);
PrintSubsetWithTheBiggersSum(numbers6);
PrintSubsetWithTheBiggersSum(numbers7);


void PrintSubsetWithTheBiggersSum(List<int> numbers)
{
    try {
        var subsetNumbers = TakeSubsetWithTheBiggersSum(numbers);
        Console.WriteLine($"\n{String.Join(", ", subsetNumbers)}");
        Console.WriteLine($"Suma: {subsetNumbers.Sum()}");
    } catch (Exception ex)
    {
        Console.WriteLine("\nList musi zawierać min 3 liczby");
    }
}

List<int> TakeSubsetWithTheBiggersSum(List<int> list)
{
    if(list.Count < 2)
    {
        throw new ArgumentException("List must be at least 3 numbers", nameof(list));
    }
    int sum = 0;
    var sortedNumber = list.OrderByDescending(x => x);
    var result = sortedNumber.SkipLast(1).TakeWhile(x => sum < sum + x);
    if (!result.Any())
    {
        result = sortedNumber.Take(2);
    }
    return result.ToList();
}