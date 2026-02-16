using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMoveAround : MonoBehaviour
{
    public GameObject CamerasHolder; //Parent of Camera AND positions

    public Animator blink;

    public GameObject One; // GameObject which holds the position that the camera should go to
    public GameObject two; // different one
    public GameObject three; // diff
    public GameObject four; // diff
    public GameObject Cam; // The Camera

    public Material seeThrough;
    private string Last = "Southern";
    private List<GameObject> seeThroughObjects = new();
    public Material Base;

    public List<GameObject> CamList; // List of all cams

    public Rigidbody rb; //Player

    public int speed; //Speed of player
    private int sidewaysMoveDirection;
    private int frontwardsMoveDirection;
    public float Jumppower;
    public int CamPos; //Interger to itterate through Cam List with

    public GameObject HeldObject;
    public bool HoldingObjectBool;
    public GameObject itemHolder;
    public bool NuhUhDrop;

    public GameObject Flashlight;
    public LayerMask flashlightLayerMask;

    public float ThrowPower;
    void Start()
    {
        Application.targetFrameRate = 60;
        HoldingObjectBool = false;
        //Add the cams to CamList
        CamList.Add(One);
        CamList.Add(two);
        CamList.Add(three);
        CamList.Add(four);
    }
    private void FixedUpdate()
    {
       Vector3 forward = Cam.transform.forward; // Define forward
       forward.y = 0; //Make sure Y does not matter
        forward = forward.normalized; //Normalize cuz better practice

        Vector3 right = Cam.transform.right; // Define forward
        right.y = 0; //Make sure Y does not matter
        right = right.normalized; //Normalize cuz better practice

        Vector3 MoveDirection = forward * frontwardsMoveDirection + right * sidewaysMoveDirection;

        Vector3 topCircle = transform.position + Vector3.up*0.5f;
        Vector3 bottomCircle = transform.position + Vector3.down*0.5f;
        float radius = 0.5f;
        Vector3 movement = MoveDirection * speed * Time.deltaTime;
        if (movement.magnitude > 0.001f)
        {
            bool hasHit = Physics.CapsuleCast(topCircle, bottomCircle, radius,
                                              movement.normalized, movement.magnitude, flashlightLayerMask);
            if (!hasHit)
                rb.MovePosition(rb.position + movement);
        }

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
            blink.Play("Blinkadoodle");
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
            blink.Play("Blinkadoodle");
            Cam.transform.rotation = CamList[CamPos].transform.rotation;
            MakeInTheWayObjectsSeeThrough();
        }

        //Movement, Connects to Fixed Update

        //Forwards/Backwards movement
        if (Input.GetKey(KeyCode.W))
            frontwardsMoveDirection = 1; 
        else if (Input.GetKey(KeyCode.S))
            frontwardsMoveDirection = -1;
        else
            frontwardsMoveDirection = 0;
        // Left/Right Movement
        if (Input.GetKey(KeyCode.D))
            sidewaysMoveDirection = 1;
        else if (Input.GetKey(KeyCode.A))
            sidewaysMoveDirection = -1;
        else
         sidewaysMoveDirection=0;
        //Jumping
        if (Input.GetKey(KeyCode.Space) && CanJump())
        {
            GetComponent<Rigidbody>().AddForce(0, Jumppower, 0,ForceMode.Impulse);
        }
        //  Flashlight

        var lookAtPos = Input.mousePosition;
        Ray ray = Cam.GetComponent<Camera>().ScreenPointToRay(lookAtPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, flashlightLayerMask))
        {
            Flashlight.transform.LookAt(hit.point);

            //Throwing Thingys
            if (HoldingObjectBool && !NuhUhDrop)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    HoldingObjectBool = false;
                    HeldObject.transform.parent = null;
                    Vector3 direction = (hit.point - transform.position).normalized;
                    Rigidbody heldRb = HeldObject.GetComponent<Rigidbody>();
                    rb.velocity = Vector3.zero;
                    heldRb.AddForce((direction+Vector3.up*0.67f)*ThrowPower, ForceMode.Impulse);
                    heldRb.freezeRotation = false;
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
        Vector3 Campos = Cam.transform.position;
        Vector3 direction = transform.position - Campos;
        float distance = Vector3.Distance(transform.position, Campos);
        RaycastHit[] hits = Physics.RaycastAll(Campos, direction, distance);

        List<GameObject> doNotRemove = new List<GameObject>();
        if (hits.Length > 0 )
        {
            if (seeThroughObjects!= null)
            {
                for (int I = seeThroughObjects.Count - 1; I >= 0; I--)
                {
                    GameObject thing = seeThroughObjects[I];
                    if (!hits.Any(hit => hit.collider.gameObject == thing))
                    {
                        var renderer = thing.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            SetOpaque(renderer.material);
                            seeThroughObjects.Remove(thing);
                            Color color = new Color();
                            color = renderer.material.color;
                            color.a = 1f;
                            renderer.material.color = color;
                        }
                    }
                }
            }
            foreach (RaycastHit hit in hits)
            {
                var renderer = hit.collider.gameObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    SetTransparent(renderer.material);
                    seeThroughObjects.Add(hit.collider.gameObject);
                    Color color = new Color();
                    color = renderer.material.color;
                    color.a = 0.4f;
                    renderer.material.color = color;
                }
            }
        }
    }

    void SetTransparent(Material mat)
    {
        mat.SetFloat("_Mode", 3); // Transparent mode
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;
    }

    void SetOpaque(Material mat)
    {
        mat.SetFloat("_Mode", 0); // Opaque mode
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        mat.SetInt("_ZWrite", 1);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.DisableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = -1;
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
