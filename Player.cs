namespace Task_3;

public class Player
{
    private static int _counter = 1; // Добавил статик счетчик для реализации простого айди вместо Guid
    private static List<int> _allIds = new();
    public int Id { get; private set; }
    public string UserName { get; private set; }
    public int Level { get; private set; }
    public bool IsBanned { get; private set; }

    public Player(string userName, int level)
    {
        SetupId();
        IsBanned = false;
        UserName = userName;
        Level = level;
    }

    private void SetupId()
    {
        if (!_allIds.Contains(_counter))
        {
            Id = _counter;
        }
        else
        {
            Console.WriteLine("Id is already set");
            Id = _counter * _counter;
        }
        _allIds.Add(Id);
        _counter++;
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