Console.WriteLine("Выберите тип кубика:\n1. d100\n2. d20\n3. d12\n4. d8\n5. d6\n6. d4");
Console.Write("\nВвод >>> ");

int input = Convert.ToInt32(Console.ReadLine());
if(input < 1 || input > 6)
{
    Console.WriteLine("Нет такого типа кубиков!");
    return;
}

Console.Write("\nВведите количество бросков >>> ");
int amount = Convert.ToInt32(Console.ReadLine());

if (amount < 0)
{
    Console.Write("Нельзя бросить кубик меньше нуля раз!");
    return;
}

Console.Write("\nВведите бонус >>> ");
int bonus = Convert.ToInt32(Console.ReadLine());

Dice dice = input switch
{
    1 => new Dice(100),
    2 => new Dice(20),
    3 => new Dice(12),
    4 => new Dice(8),
    5 => new Dice(6),
    6 => new Dice(4)
};

List<int> values = new();

for (int i = 0; i <= amount; i++)
    values.Add(dice.GetValue());

Console.WriteLine("\nВаши значения:");

foreach(int value in values)
    Console.Write($"{value} + ");

Console.Write($"{bonus}(бонус)");

Console.WriteLine($"\nСумма: {values.Sum() + bonus}");

public class Dice
{
    public Dice(int max) => Maximum = max;

    public string Title => "d" + Maximum;
    public int Maximum { get; init; }

    public int GetValue() => new Random().Next(1, Maximum + 1);
}