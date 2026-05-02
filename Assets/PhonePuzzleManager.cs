using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhonePuzzleManager : MonoBehaviour
{

    public string combo;
    public string correctCombo = "911";
    public bool isNumberAllowed;
    public float timeTillNewNumAllowed;
    public GameObject player;
    public TMP_Text display;

    public void AddToCombo(int X)
    {
        if (!isNumberAllowed)
        {
            return;
        }
        isNumberAllowed = false;
        combo += X.ToString();
        Debug.Log(combo);
        if (combo == correctCombo)
        {
            //Give Puzzle Piece
            display.text = "CORRECT CORRECT CORRECT";
            Debug.Log("Puzzle Piece");
            return;
        }
        else if (combo.Length > 2)
        {
            display.text = "WRONG WRONG WRONG";
            combo = "";
        }
        else
            display.text = "WAIT WAIT WAIT";
        StartCoroutine(isNumberAllowedReset());
    }
    public IEnumerator isNumberAllowedReset()
    {
        yield return new WaitForSeconds(timeTillNewNumAllowed);
        isNumberAllowed = true;
        display.text = combo;
    }
}
