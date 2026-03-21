using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floaterScript : MonoBehaviour
{
    public GameObject player;
    public int sanityDrain;
    public int spd;

    public GameObject sanityScr;
    private float sanity; 
    // Start is called before the first frame update
    void Start()
    {
        sanityScr = GameObject.Find("sanity manager");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 baseMovement = Vector3.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);

        float ghostFloat = Mathf.PingPong(Time.time * 0.1f, 0.1f)-0.05f;
        transform.position = baseMovement + new Vector3(0, ghostFloat, 0);
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
