using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    public GameObject door;
    public int weight;

    // Start is called before the first frame update
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
}
