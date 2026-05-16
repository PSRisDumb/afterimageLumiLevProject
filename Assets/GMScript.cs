using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    public GameObject door;
    public int weight;

    public GameObject[] paintingPuzzle;
    public bool[] hasPiece = new bool[8];

    // Start is called before the first frame update

    private void Awake()
    {
        for (int i = 0; i < 8; i++) {
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
        if (weight == 10)
        {
            door.SetActive(false);
        }

    }

    public void updatePuzzle(int pieceID)
    {
        hasPiece[pieceID] = true;
        for (int i = 0; i < 8; i++)
        {
            if (hasPiece[i])
            {
                paintingPuzzle[i].SetActive(true);
            }
        }
    }
}

