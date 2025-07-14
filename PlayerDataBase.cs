namespace Task_3;

public class PlayerDataBase
{
    private List<Player> _players = new();

    public void ShowPlayers()
    {
        foreach (Player player in _players)
        {
            Console.WriteLine(new string('-', 20));
            player.ShowPlayerInfo();
        }
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public void RemovePlayer(int playerId)
    {
        for (int i = 0; i <= _players.Count - 1; i++)
        {
            if (_players[i].Id == playerId)
            {
                _players.RemoveAt(i);
                break;
            }
        }
    }
    
    public void BanPlayerId(int playerId)
    {
        foreach (Player player in _players)
        {
            if (player.Id == playerId)
            {
                player.Ban();
                break;
            }
        }
    }

    public void UnbanPlayerId(int playerId)
    {
        foreach (Player player in _players)
        {
            if (player.Id == playerId)
            {
                player.Unban();
            }
        }
    }
}