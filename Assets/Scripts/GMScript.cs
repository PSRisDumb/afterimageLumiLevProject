using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    [Header("ScalePuzle")]
    public GameObject door;
    public int weight;

    public GameObject[] paintingPuzzle;
    public bool[] hasPiece = new bool[8];

    public bool piece = false;
    public bool picUp = false;

    public GameObject picPiece1;
    public GameObject picPiece2;
    public GameObject picPiece3;
    public TMP_Text puzzleCounterText;
    public int puzCount;
    // Start is called before the first frame update


    // Scale Puzzle ------------------------------------------------
    private void Awake()
    {
        for (int i = 0; i < 3; i++) {
            hasPiece[i] = false;
        }
    }

    void Start()
    {
        weight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (weight == 10 && piece == false)
        {
            Instantiate(picPiece1, new Vector3(-3.7f, 18f, 137f), Quaternion.identity);
            piece = true;
        }
    }

    public void updatePuzzle(int pieceID)
    {
        hasPiece[pieceID] = true;
        for (int i = 0; i < 3; i++)
        {
            if (hasPiece[i])
            {
                paintingPuzzle[i].SetActive(true);
            }
        }
        puzCount++;
        puzzleCounterText.text = puzCount + "/ 3";
    }
}

