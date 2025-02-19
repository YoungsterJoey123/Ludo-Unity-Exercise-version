using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    GamePiece[] pieces = new GamePiece[4];
    public Player()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i] = new GamePiece();
        }
    }
    public bool DecideAndMovePiece(int rollValue)
    {
        if (rollValue == 6)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].Position == 0)
                {
                    pieces[i].Move(1);
                    return false;
                }
            }
        }
        else
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].Position + rollValue <= 40)
                {
                    pieces[i].Move(rollValue);
                    return false;
                }
            }
        }
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].Position < 40)
            {
                pieces[i].Move(rollValue);
                return false;
            }
        }
        return true;
    }
}
