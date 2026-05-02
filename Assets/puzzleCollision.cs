using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCollision : MonoBehaviour
{
    public GameObject GMS;
    public GameObject dialogue;
    public GameObject ghost;
    private bool ghostOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "puzzle piece")
        {
            Destroy(collision.gameObject);
            GMS.GetComponent<GMScript>().picUp = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "trigger" && ghostOn == false)
        {
            Destroy(other.gameObject);
            Instantiate(ghost, new Vector3(-11f,21,127), Quaternion.identity);
            ghostOn = true;
            dialogue.GetComponent<dialogueManager>().saf1GO = true;

        }

        if (other.gameObject.tag == "saferoom")
        {
            dialogue.GetComponent<dialogueManager>().saf2GO = true;
            ghost.GetComponent<floaterScript>().safeRoom = true;

        }


    }
}
