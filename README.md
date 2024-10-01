# ParaMeuCurriculo

Este código C# simula um torneio de MMA eliminatório com participantes emparelhados aleatoriamente. A cada rodada, dois lutadores se enfrentam e um vencedor é escolhido de maneira aleatória até que reste apenas um campeão. Abaixo está a explicação detalhada do funcionamento do código:

1. Lista de Participantes

A lista fighters armazena o nome dos lutadores. No início, são inseridos oito lutadores.
List<string> fighters = new List<string>
{
    "Lutador 1", "Lutador 2", "Lutador 3", "Lutador 4",
    "Lutador 5", "Lutador 6", "Lutador 7", "Lutador 8"
};

2. Embaralhamento Aleatório
A função Shuffle é usada para embaralhar a lista de lutadores de maneira aleatória para que as lutas ocorram de forma imprevisível.
Shuffle(fighters);
A função Shuffle funciona da seguinte forma:

Usa um laço para percorrer a lista de trás para frente.
Escolhe um índice aleatório j para trocar o elemento da posição atual com outro elemento.


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

3. Rodadas do Torneio
O torneio é gerado em rounds. Enquanto houver mais de um lutador na lista, o código continua a rodar as lutas. Para cada round, dois lutadores são emparelhados, e um vencedor é escolhido.
O loop principal percorre os lutadores, criando pares e selecionando um vencedor aleatoriamente por meio da função RandomWinner.

while (fighters.Count > 1)
{
    Console.WriteLine($"\nRound {round}:");
    List<string> winners = new List<string>();

    for (int i = 0; i < fighters.Count; i += 2)
    {
        Console.WriteLine($"{fighters[i]} vs {fighters[i + 1]}");

        string winner = RandomWinner(fighters[i], fighters[i + 1]);
        winners.Add(winner);

        Console.WriteLine($"Vencedor: {winner}");
    }

    fighters = winners;
    round++;
}
4. Escolha do Vencedor
A função RandomWinner recebe dois lutadores como argumento e escolhe aleatoriamente um deles para vencer. A função Random.Next(0, 2) retorna um número aleatório entre 0 e 1. Se o resultado for 0, o primeiro lutador vence; se for 1, o segundo lutador vence.


static string RandomWinner(string fighter1, string fighter2)
{
    Random rand = new Random();
    return rand.Next(0, 2) == 0 ? fighter1 : fighter2;
}
5. Resultado Final
Quando sobra apenas um lutador na lista, ele é declarado o campeão do torneio.


Console.WriteLine($"\nCampeão do torneio: {fighters[0]}");
Resumo
O código gera um torneio de MMA eliminatório, onde cada luta ocorre entre dois participantes escolhidos aleatoriamente. O torneio continua até que reste apenas um lutador, que é declarado o campeão. A aleatoriedade é usada tanto para definir as lutas quanto para escolher os vencedores.