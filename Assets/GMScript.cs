using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    public GameObject door;
    public bool doorOpen;
    public int weight;

    // Start is called before the first frame update
    void Start()
    {
        weight = 0;
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (weight == 10)
        {
            doorOpen = true; 
            door.SetActive(false);
        }

    }
}
