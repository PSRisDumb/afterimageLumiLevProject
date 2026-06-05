using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handsScript : MonoBehaviour
{
    public float speed;
    public Vector2 targetPos;
    public RectTransform hand;

    public GameObject sanityScr;
    public float sanityDrainT;
    public float sanityDrain;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sanityScr = GameObject.Find("sanity manager");
        hand = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //hand movement
        hand.anchoredPosition = Vector2.MoveTowards(hand.anchoredPosition, targetPos, speed * Time.deltaTime);

        if(hand.anchoredPosition == targetPos)
        {
            sanityDrainT += Time.deltaTime;
            if(sanityDrainT >= sanityDrain)
            {
                //sanity drain when hit middle
                Debug.Log("hit middle");
                sanityScr.GetComponent<sanityManager>().sanity -= 10;
                sanityDrainT = 0;
            }

            
 
        }

        if(player.GetComponent<puzzleCollision>().safeRoom == true)
        {
            Destroy(gameObject);
        }


    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log("die");
    }

    public void Clicked()
    {
        Debug.Log("clicked");
    }
}
