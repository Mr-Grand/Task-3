namespace Task_3;

public class Player
{
    public int Id { get; }
    public static int Counter = 1; // Добавил статик счетчик для реализации простого айди вместо Guid
    public string UserName { get; private set; }
    public int Level { get; private set; }
    public bool IsBanned { get; private set; }

    public Player(string userName, int level)
    {
        Id = Counter;
        Counter++;
        IsBanned = false;
        UserName = userName;
        Level = level;
    }

    public void ShowPlayerInfo()
    {
        Console.WriteLine($"\nName - {UserName}\nID - {Id}" +
                          $"\nLevel - {Level}\nBan status - {IsBanned}");
    }

    public void Ban()
    {
        IsBanned = true;
    }

    public void Unban()
    {
        IsBanned = false;
    }
}