using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photoScript : MonoBehaviour
{
    public GameObject sanityScr;
    public float sanityDrainT;
    public float sanityDrain;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sanityScr = GameObject.Find("sanity manager");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        sanityDrainT += Time.deltaTime;
        if (sanityDrainT >= sanityDrain)
        {
            sanityScr.GetComponent<sanityManager>().sanity -= 10;
            sanityDrainT = 0;
        }
        if (player.GetComponent<puzzleCollision>().safeRoom == true)
        {
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log("die");
    }
}
