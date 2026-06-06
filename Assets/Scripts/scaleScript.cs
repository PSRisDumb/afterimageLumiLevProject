using System.Collections;
using UnityEngine;

public class scaleScript : MonoBehaviour
{
    public GMScript GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("gameManager").GetComponent<GMScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bottleCap":
                GM.weight += 10;
                break;
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bottleCap":
                GM.weight -= 10;
                break;
        }
    }
}
