using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpableObject : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject playerGameObject;
    public float timeTillThrowLerpEnables;
    public float travelTime;
    public EaseType easetype;

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
    public Coroutine TravelingCourritineHolder;
    public void TravelingStart(Vector3 target)
    {
        if (TravelingCourritineHolder != null)
        {
            StopCoroutine(TravelingCourritineHolder);
        }
        TravelingCourritineHolder = StartCoroutine(Traveling(target));
    }
    private IEnumerator Traveling(Vector3 targetVector)
    {
        yield return new WaitForSeconds(timeTillThrowLerpEnables);

        Vector3 startPos = transform.position;
        for (float t = 0; t < travelTime; t += Time.deltaTime)
        {
            float param = t / travelTime;
            float easedParam = Easing.Ease(easetype, param);
            transform.position = Vector3.Lerp(startPos, targetVector, easedParam);
            yield return null;
        }
    }
}
