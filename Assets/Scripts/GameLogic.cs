using System;
using System.Collections;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    int winnerFound = -1;
    int dice = UnityEngine.Random.Range(1, 7);
    Player[] players = new Player[4];
    public GameLogic()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = new Player();
        }
        while (winnerFound < 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                int diceRoll = dice;
                bool winner = players[i].DecideAndMovePiece(diceRoll);
                if (winner)
                {
                    winnerFound = i;
                    break;
                }
            }
        }
        Console.WriteLine("winner is player " + winnerFound);
    }

}
