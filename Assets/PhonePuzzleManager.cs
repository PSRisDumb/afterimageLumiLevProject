using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePuzzleManager : MonoBehaviour
{

    public string combo;
    public string correctCombo = "911";

    public void AddToCombo(int X)
    {
        combo += X.ToString();
        Debug.Log(combo);
        if (combo == correctCombo)
        {
            //Give Puzzle Piece
            Debug.Log("Puzzle Piece");
        }
        else if (combo.Length > 2)
        {
            combo = "";
        }
    }
}
