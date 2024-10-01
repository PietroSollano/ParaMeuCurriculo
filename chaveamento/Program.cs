
    static void Main()
    {
        // Lista de participantes do torneio
        List<string> fighters = new List<string>
        {
            "Lutador 1", "Lutador 2", "Lutador 3", "Lutador 4",
            "Lutador 5", "Lutador 6", "Lutador 7", "Lutador 8"
        };

        // Embaralhar a lista para distribuir as lutas de forma aleatória
        Shuffle(fighters);

        Console.WriteLine("Chaveamento do Torneio de MMA:");
        int round = 1;

        // Gerar as rodadas do torneio até restar um lutador
        while (fighters.Count > 1)
        {
            Console.WriteLine($"\nRound {round}:");
            List<string> winners = new List<string>();

            // Emparelhar os lutadores para as lutas
            for (int i = 0; i < fighters.Count; i += 2)
            {
                Console.WriteLine($"{fighters[i]} vs {fighters[i + 1]}");

                // Simular a escolha de um vencedor (aleatoriamente)
                string winner = RandomWinner(fighters[i], fighters[i + 1]);
                winners.Add(winner);

                Console.WriteLine($"Vencedor: {winner}");
            }

            fighters = winners;
            round++;
        }

        // Exibir o campeão
        Console.WriteLine($"\nCampeão do torneio: {fighters[0]}");
    }

    // Função para embaralhar a lista de lutadores
    static void Shuffle(List<string> list)
    {
        Random rand = new Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    // Função para escolher aleatoriamente o vencedor de uma luta
    static string RandomWinner(string fighter1, string fighter2)
    {
        Random rand = new Random();
        return rand.Next(0, 2) == 0 ? fighter1 : fighter2;
    }

