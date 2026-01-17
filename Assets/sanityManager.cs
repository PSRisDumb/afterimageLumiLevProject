using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanityManager : MonoBehaviour
{
    private float sanityDrainTimer;
    public float sanityDrain;
    public int sanity;
    // Start is called before the first frame update
    void Start()
    {
        sanity = 100;

    }

    // Update is called once per frame
    void Update()
    {
        sanityDrainTimer += Time.deltaTime;
        if (sanityDrainTimer >= sanityDrain)
        {
            sanity -= 1;
            sanityDrainTimer = 0;
        }
    }
}
