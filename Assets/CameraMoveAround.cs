using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveAround : MonoBehaviour
{
    public GameObject One; // GameObject which holds the position that the camera should go to
    public GameObject two; // different one
    public GameObject three; // diff
    public GameObject four; // diff
    public GameObject Cam; // The Camera

    public Material seeThrough;
    private string Last ="Southern";
    public Material Base;

    public List<GameObject> CamList; // List of all cams

    public Rigidbody rb; //Player

    public int speed; //Speed of player
    public int CamPos; //Interger to itterate through Cam List with

    public GameObject Flashlight;
    void Start()
    {
        Application.targetFrameRate = 60;
        //Add the cams to CamList
        CamList.Add(One); 
        CamList.Add(two);
        CamList.Add(three);
        CamList.Add(four);
        MakeInTheWayObjectsSeeThrough();
    }
    void Update()
    {

        //Camera E / Q

        if (Input.GetKeyDown(KeyCode.E)) // When the player presses E
        {
            if (CamPos == CamList.Count-1) // If is at max
            {
                Debug.Log("Back to 0"); // log it
                CamPos = 0;  // CamPos is reset to 0
            }
            else // If campos is not at max
            {
                CamPos++; // Campos + 1
            }
            Cam.transform.position = CamList[CamPos].transform.position; // Set the main Camera to the new pos
            Cam.transform.rotation = CamList[CamPos].transform.rotation; // Set the main cam rotation to new rotation
            MakeInTheWayObjectsSeeThrough();
        }
        if (Input.GetKeyDown(KeyCode.Q)) //Same exact stuff but inverse
        {
            if (CamPos == 0)
            {
                CamPos = CamList.Count-1;
            }
            else
            {
                CamPos--;
            }
            Cam.transform.position = CamList[CamPos].transform.position;
            Cam.transform.rotation = CamList[CamPos].transform.rotation;
            MakeInTheWayObjectsSeeThrough();
        }
        
        //Movement
        if (rb.velocity.x < 10)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Cam.transform.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Cam.transform.forward * -1 * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Cam.transform.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Cam.transform.right * -1 * speed * Time.deltaTime);
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(rb.velocity.x / 2, rb.velocity.y, rb.velocity.z / 2);
            }
        }
        //  Flashlight

        var lookAtPos = Input.mousePosition;
        Ray ray = Cam.GetComponent<Camera>().ScreenPointToRay(lookAtPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Flashlight.transform.LookAt(hit.point);
        }
    }
    void MakeInTheWayObjectsSeeThrough() //Makes unimportant walls invisiible/see through
    {
        foreach (GameObject thing in GameObject.FindGameObjectsWithTag(Last))
        {
            var objectRenderer = thing.GetComponent<Renderer>();
            objectRenderer.material = Base;
        }
        switch (CamPos)
        {
            case 0:
                foreach (GameObject thing in GameObject.FindGameObjectsWithTag("Southern"))
                {
                    var objectRenderer = thing.GetComponent<Renderer>();
                    objectRenderer.material = seeThrough;
                }
                Last = "Southern";
                break;
            case 1:
                foreach (GameObject thing in GameObject.FindGameObjectsWithTag("Western"))
                {
                    var objectRenderer = thing.GetComponent<Renderer>();
                    objectRenderer.material = seeThrough;
                }
                Last = "Western";
                break;
            case 2:
                foreach (GameObject thing in GameObject.FindGameObjectsWithTag("Northern"))
                {
                    var objectRenderer = thing.GetComponent<Renderer>();
                    objectRenderer.material = seeThrough;;
                }
                Last = "Northern";
                break;
            case 3:
                foreach (GameObject thing in GameObject.FindGameObjectsWithTag("Eastern"))
                {
                    var objectRenderer = thing.GetComponent<Renderer>();
                    objectRenderer.material = seeThrough;
                }
                Last = "Eastern";
                break;
        }
    }
}
