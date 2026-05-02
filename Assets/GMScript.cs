using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    public GameObject player;

    public GameObject door;
    public int weight;
    public GameObject picPiece;
    public bool picUp = false;
    public bool piece; // to see if the piece exists

    // Start is called before the first frame update
    void Start()
    {
        weight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (weight == 10 && piece == false)
        {
            Instantiate(picPiece, new Vector3(-3.7f,18f,137f), Quaternion.identity);
            piece = true;
        }


        if (picUp)
        {
            door.SetActive(false);
        }

    }

}
