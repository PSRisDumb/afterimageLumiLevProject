using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class bossPieceScript : MonoBehaviour
{
    GameObject playerObj;

    bossManager BS;

    // Start is called before the first frame update
    void Start()
    {
        BS = GameObject.Find("bossManager").GetComponent<bossManager>();
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == playerObj)
        {
            BS.health--;
            Destroy(gameObject);
        }
    }
}
