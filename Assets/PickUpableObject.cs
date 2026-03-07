using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpableObject : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject playerGameObject;

    private void Start()
    {
        playerGameObject = GameObject.Find("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == playerGameObject)
        {
            var cameraMove = playerGameObject.GetComponent<CameraMoveAround>();
            if (!cameraMove.HoldingObjectBool)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    cameraMove.NuhUhDrop = true;
                    cameraMove.HoldingObjectBool = true;
                    Rb.freezeRotation = true;
                    cameraMove.HeldObject = gameObject;
                    StartCoroutine(cameraMove.WaitOneSecTillAllowDrop());
                }
            }
        }
    }
}
