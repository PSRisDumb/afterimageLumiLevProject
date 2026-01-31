using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveAround : MonoBehaviour
{
    public GameObject CamerasHolder; //Parent of Camera AND positions

    public GameObject One; // GameObject which holds the position that the camera should go to
    public GameObject two; // different one
    public GameObject three; // diff
    public GameObject four; // diff
    public GameObject Cam; // The Camera

    public Material seeThrough;
    private string Last = "Southern";
    public Material Base;

    public List<GameObject> CamList; // List of all cams

    public Rigidbody rb; //Player

    public int speed; //Speed of player
    public float Jumppower;
    public int CamPos; //Interger to itterate through Cam List with

    public GameObject HeldObject;
    public bool HoldingObjectBool;
    public GameObject itemHolder;
    public bool NuhUhDrop;

    public GameObject Flashlight;

    public float ThrowPower;
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
        CamerasHolder.transform.position = transform.position;

        //Camera E / Q

        if (Input.GetKeyDown(KeyCode.E)) // When the player presses E
        {
            if (CamPos == CamList.Count - 1) // If is at max
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
                CamPos = CamList.Count - 1;
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
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position+Cam.transform.forward * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position + Cam.transform.forward * -1 * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + Cam.transform.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 90);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(rb.position + Cam.transform.right * -1 * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 270);
        }
        if (Input.GetKey(KeyCode.Space) && CanJump())
        {
            Debug.Log("Hit");
            GetComponent<Rigidbody>().AddForce(0, Jumppower, 0,ForceMode.Impulse);
        }
        Debug.Log(rb.velocity);

        //  Flashlight

        var lookAtPos = Input.mousePosition;
        Ray ray = Cam.GetComponent<Camera>().ScreenPointToRay(lookAtPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Flashlight.transform.LookAt(hit.point);

            //Throwing Thingys
            if (HoldingObjectBool && !NuhUhDrop)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    HoldingObjectBool = false;
                    HeldObject.transform.parent = null;
                    HeldObject.transform.LookAt(hit.point);
                    HeldObject.GetComponent<Rigidbody>().AddForce(HeldObject.transform.forward*ThrowPower, ForceMode.Impulse);
                    HeldObject.GetComponent<PickUpableObject>().Mc.enabled = true;
                    HeldObject = null;
                }
            }
        }

        //Pick up Thingys
        if (HoldingObjectBool)
        {
            HeldObject.transform.position = itemHolder.transform.position;
            HeldObject.transform.parent = itemHolder.transform;
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
                    objectRenderer.material = seeThrough; ;
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


    bool CanJump()
    {
            Vector3 origin = transform.position + Vector3.down * 1f;
            float radius = 0.5f;
        RaycastHit[] hits = Physics.SphereCastAll(origin, radius, Vector3.forward, 1);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }

    public IEnumerator WaitOneSecTillAllowDrop()
    {
         yield return new WaitForSeconds(1);
        NuhUhDrop = false;
    }
}
