using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sanityManager : MonoBehaviour
{
    private float sanityDrainTimer;
    public float sanityDrain;
    public int sanity;
    

    public Slider sanityBar;
    // Start is called before the first frame update
    void Start()
    {
        sanity = 100;

    }

    // Update is called once per frame
    void Update()
    {
        //sanity bar
        /*
         * need to change color gradualy 100-70 green, 70-30 yellow, 30-0, red
         * dont snap to where sanity is
         */
        sanityBar.maxValue = 100;
        sanityBar.minValue = 0;
        sanityBar.value = sanity;

        //sanity loss
        if (sanity >= 0)
        {
            sanityDrainTimer += Time.deltaTime;
            if (sanityDrainTimer >= sanityDrain)
            {
                sanity -= 1;
                sanityDrainTimer = 0;
            }
        }
    }
}
