internal class Program
{
  static void Main(string[] args)
  {
    //var rnd = new DynamicRandomizer();
    //rnd.SetRangeDinamic();

    var rnd = new StaticRandomizer();
    rnd.SetRangeStatic(1, 20);

    new GuessTheNumber(rnd).Game();
  }
}

public interface IRandomizer
{
  public int Randomize();
}

public interface IStatic
{
  void SetRangeStatic(int start, int end);
}

public interface IDinamic
{
  void SetRangeDinamic();
}

internal class StaticRandomizer : IRandomizer, IStatic
{
  private int Start;
  private int End;

  public int Randomize() => new Random().Next(Start, End);

  public void SetRangeStatic(int start, int end)
  {
    Start = start; End = end;
  }
}

internal class DynamicRandomizer : IRandomizer, IDinamic
{
  private int Start;
  private int End;

  public void SetRangeDinamic()
  {
    Console.Write("Input a start of range: ");
    Start = int.Parse(Console.ReadLine());

    Console.Write("Input a end of range: ");
    End = int.Parse(Console.ReadLine());
  }
  public int Randomize()
  {
    return new Random().Next(Start, End);
  }
}

internal class GameSettings
{
  public int AttemptsCount = 6;
}

public class GuessTheNumber
{
  private GameSettings settings = new GameSettings();
  private IRandomizer _randomizer;

  public GuessTheNumber(IRandomizer randomizer)
  {
    _randomizer = randomizer;
  }

  public void Game()
  {
    int number = _randomizer.Randomize();

    for (int attempt = 1; attempt <= settings.AttemptsCount; attempt++)
    {
      int numberInput;

      Console.Write("Attempt #{0}\nGuess the number: ", attempt);
      string input = Console.ReadLine();
      numberInput = int.Parse(input);

      if (numberInput == number)
      {
        Console.WriteLine("YOU WIN!!!");
        break;
      }
      else if (numberInput < number)
      {
        Console.WriteLine("The number is greater");
      }
      else if (numberInput > number)
      {
        Console.WriteLine("The number is less");
      }
    }
  }
}
