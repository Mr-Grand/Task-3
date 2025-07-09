namespace Task_3;

public class PlayerDataBase
{
    private List<Player> players = new();

    public void ShowPlayers()
    {
        foreach (Player player in players)
        {
            Console.WriteLine(new string('-', 20));
            player.ShowPlayerInfo();
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Guid playerId)
    {
        int index = 0; // Сохраняем номер обьекта по индексу и удаляем его потом.
        // т.к. Нельзя удалять обьект во время цикла его перебора
        foreach (Player player in players)
            if (player.Id == playerId)
                index = players.IndexOf(player);
        players.RemoveAt(index);
    }

    public Guid GetPlayerId(string name)
    {
        foreach (Player player in players)
            if (player.UserName == name)
                return player.Id;
        return Guid.Empty;
    }

    public Guid GetPlayerId(int index)
    {
        if (index <= players.Count)
            return players.ElementAt(index - 1).Id;
        else
            return Guid.Empty; //Метод обязан что-то возвращать
    }

    public void BanPlayerID(Guid playerId)
    {
        foreach (Player player in players)
            if (player.Id == playerId)
                player.Ban();
    }

    public void UnbanPlayerID(Guid playerId)
    {
        foreach (Player player in players)
            if (player.Id == playerId)
                player.Unban();
    }
}