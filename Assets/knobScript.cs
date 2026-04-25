using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class knobScript : MonoBehaviour
{
    public GameObject heartMonitor;

    public bool isRateMonitor;
    public bool canInteract;

    public float rate;
    public float amp;
    public float heartRate;
    public float height;

    public bool updateMonitor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        heartMonitor.GetComponent<TextMeshPro>().SetText($"Heart rate: {Mathf.FloorToInt(heartRate)} Amp: {Mathf.FloorToInt(height)}");

    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isRateMonitor)
            {
                heartRate += rate * Time.fixedDeltaTime;
            }
            else
            {
                height += amp * Time.fixedDeltaTime;
            }
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider collisionLeave)
    {
        if (collisionLeave.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

}
