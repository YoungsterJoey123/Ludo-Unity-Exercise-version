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
        StartCoroutine(rollDice());//starter hele spillet
        
    }
    public IEnumerator rollDice()
    {
        
        
        while (winnerFound < 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                yield return new WaitForSeconds(0.2f);//venter 0,2 sekunder
                dice = UnityEngine.Random.Range(1, 7);//RNG fra 1 til 6
                bool winner = players[i].GetComponent<Player>().DecideAndMovePiece(dice);//kører progarmmet
                if (winner)
                {
                    winnerFound = i + 1;
                    break;
                }
                
            }
        }
        print("winner is player " + winnerFound);
    }
}
