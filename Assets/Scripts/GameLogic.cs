using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    int dice;
    int winnerFound = -1;
    GameObject[] players = new GameObject[4];
    private void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = transform.GetChild(i).gameObject;
        }
        StartCoroutine(rollDice());
        
    }
    public IEnumerator rollDice()
    {
        
        
        while (winnerFound < 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                yield return new WaitForSeconds(0.2f);
                dice = UnityEngine.Random.Range(1, 7);
                bool winner = players[i].GetComponent<Player>().DecideAndMovePiece(dice);
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
