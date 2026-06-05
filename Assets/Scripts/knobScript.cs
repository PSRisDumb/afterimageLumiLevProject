using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class knobScript : MonoBehaviour
{
    public GameObject heartMonitor;
    public LineRenderer sineWave;
    public CameraMoveAround playerScript;

    public bool isRateMonitor;
    public bool canInteract;
    public bool isInteracting;

    public float rate;
    public float amp;
    public float heartRate;
    public float height;
    public float length;

    public int points;

    public bool updateMonitor;
    // Start is called before the first frame update
    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<CameraMoveAround>();
        sineWave = GameObject.Find("sineWave").GetComponent<LineRenderer>();
        points = 100;
        length = 10f;
        heartRate = .1f;
        height = .5f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        for (int i = 0;  i < points; i++)
        {
            float x = (i / (float)points) * length;
            float y = Mathf.Sin(x + Time.time * heartRate) * height;
            sineWave.SetPosition(i, new Vector3(x,y,0));
        }
        
        if (isInteracting)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (isRateMonitor)
                {
                    heartRate -= rate * Time.deltaTime;
                }
                else
                {
                    height -= amp * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (isRateMonitor)
                {
                    heartRate += rate * Time.deltaTime;
                }
                else
                {
                    height += amp * Time.deltaTime;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canInteract && !isInteracting)
        {
            playerScript.speed = 0;
            isInteracting = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.F) && canInteract && isInteracting)
        {
            playerScript.speed = 10;
            isInteracting = false;
        }
        sineWave.positionCount = points;
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
