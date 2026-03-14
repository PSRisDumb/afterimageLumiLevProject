using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floaterScript : MonoBehaviour
{
    public Transform player;
    public int sanityDrain;
    public int spd;

    public GameObject sanityScr;
    private float sanity; 
    // Start is called before the first frame update
    void Start()
    {
        sanityScr = GameObject.Find("sanity manager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, spd * Time.deltaTime);
        //transform.position = new Vector3(0,)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            sanity -= sanityDrain;
            sanityScr.GetComponent<sanityManager>().sanity -= sanityDrain;
            Destroy(gameObject);
        }
    }
 
   
}
