using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knobScript : MonoBehaviour
{
    public float rate;
    public float heartRate;

    public bool updateMonitor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            heartRate += rate * Time.fixedDeltaTime;
        }
    }

}
