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

    public GMScript GMS;
    public GameStateManager stateManager;

    public AudioSource AS;
    public AudioClip numberHit;
    public AudioClip Correct;
    public AudioClip Clear;
    public AudioClip Ringing;

    public void Start()
    {
        player = GameObject.Find("Player");
        AS.PlayOneShot(Ringing);
        display.text = "ENTER A NUMBER";
    }
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
            stateManager.ProgressState();
            Instantiate(GMS.picPiece3, new Vector3(-24f, 18f, 260f), Quaternion.identity);
            AS.PlayOneShot(Correct);
            return;
        }
        else if (combo.Length > 2)
        {
            display.text = "WRONG WRONG WRONG";
            combo = "";
            AS.PlayOneShot(Clear);
        }
        else
        {
            display.text = "WAIT WAIT WAIT";
            AS.PlayOneShot(numberHit);
        }
        StartCoroutine(isNumberAllowedReset());
    }
    public IEnumerator isNumberAllowedReset()
    {
        yield return new WaitForSeconds(timeTillNewNumAllowed);
        isNumberAllowed = true;
        display.text = combo;
    }
}
