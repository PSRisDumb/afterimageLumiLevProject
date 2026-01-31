using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpableObject : MonoBehaviour
{
    public BoxCollider Mc;
    public GameObject playerGameObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == playerGameObject)
        {
            var cameraMove = playerGameObject.GetComponent<CameraMoveAround>();
            if (!cameraMove.HoldingObjectBool)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Mc.enabled = true;
                    cameraMove.NuhUhDrop = true;
                    cameraMove.HoldingObjectBool = true;
                    cameraMove.HeldObject = gameObject;
                    StartCoroutine(cameraMove.WaitOneSecTillAllowDrop());
                }
            }
        }
    }
}
