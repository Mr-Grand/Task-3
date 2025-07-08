namespace Task_3;

internal class Program
{
    private static void Main(string[] args)
    {
        PlayerDataBase players = new();

        Player player1 = new("Danik", 11);
        players.AddPlayer(player1);
        Player player2 = new("Oleg", 99);
        players.AddPlayer(player2);
        Player player3 = new("Alex", 30);
        players.AddPlayer(player3);


        players.ShowPlayers();
        Console.WriteLine("Нажмите клавишу, чтобы очистить вывод" +
                          " и проверить следующие методы");

        Console.ReadKey(true);
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write("\f\u001bc\x1B[3J");
        Console.SetCursorPosition(0, 0);


        players.ShowPlayers();

        players.BanPlayerID(players.GetPlayerId(1)); // Баним первого игрока
        players.RemovePlayer(players.GetPlayerId("Oleg")); // Удаляем игрока по имени

        Console.WriteLine("\nИгроки после изменений:");
        players.ShowPlayers();
    }

    private class PlayerDataBase
    {
        private List<Player> players = new();

        public void ShowPlayers()
        {
            foreach (Player player in players)
            {
                Console.WriteLine("___________________________________");
                Console.WriteLine($"Name - {player.UserName}\nID - {player.Id}" +
                                  $"\nLevel - {player.Lvl}\nBan status - {player.IsBanned}");
            }
        }

        public void ShowIndexPlayer(int index)
        {
            Console.WriteLine("_____________________________________");
            Console.WriteLine($"Name - {players[index].UserName}\nID - {players[index].Id}" +
                              $"\nLevel - {players[index].Lvl}" +
                              $"\nBan status - {players[index].IsBanned}");
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Guid playerId)
        {
            int index = 0; //Сохраняем номер обьекта по индексу и удаляем его потом.
            //т.к. Нельзя удалять обьект во время цикла его перебора
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
            else return Guid.Empty; //Метод обязан что-то возвращать
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

    private class Player
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
}