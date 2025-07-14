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
        Console.Write("\f\u001bc\x1B[3J"); // Console.Clear не чистит всю консоль
        Console.SetCursorPosition(0, 0);

        Console.WriteLine("Игроки до изменений:\n");
        players.ShowPlayers();

        players.BanPlayerId(1); // Баним первого игрока
        players.RemovePlayer(2); // Удаляем игрока по имени

        Console.WriteLine("\nЗабанили Даника, удалили Олега" +
                          "\nИгроки после изменений:");
        players.ShowPlayers();

        Console.WriteLine("\nРазбаним Даника");
        players.UnbanPlayerId(1);
        players.ShowPlayers(); 
    }
}