namespace Task_3;

public class Player
{
    public Guid Id { get; }
    public string UserName { get; private set; }
    public int Lvl { get; private set; }
    public bool IsBanned { get; private set; }

    public Player(string username, int lvl)
    {
        Id = Guid.NewGuid();
        IsBanned = false;
        UserName = username;
        Lvl = lvl;
    }

    public void ShowPlayerInfo()
    {
        Console.WriteLine($"\nName - {UserName}\nID - {Id}\nLevel - {Lvl}\nBan status - {IsBanned}");
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