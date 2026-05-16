using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    public GameObject door;
    public int weight;

    public GameObject[] paintingPuzzle;
    public bool[] hasPiece = new bool[8];

    public bool piece = false;
    public bool picUp = false;

    public GameObject picPiece;

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
        if (weight == 10 && piece == false)
        {
            Instantiate(picPiece, new Vector3(-3.7f, 18f, 137f), Quaternion.identity);
            piece = true;
        }


        if (picUp)
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

