using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpableObject : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject playerGameObject;
    public GameObject eToPickUpText;

    public float timeTillThrowLerpEnables;
    public float travelTime;
    public float InteractDistance;

   public EaseType easetype;

    private void Start()
    {
        playerGameObject = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Vector3.Distance(playerGameObject.transform.position,transform.position) < InteractDistance)
        {
            eToPickUpText.SetActive(true);
            eToPickUpText.transform.LookAt(playerGameObject.GetComponent<CameraMoveAround>().Cam.transform);
            eToPickUpText.transform.Rotate(0, 180, 0);
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
            else
                eToPickUpText.SetActive(false);
        }
        else
        {
            eToPickUpText.SetActive(false);
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
        Rb.useGravity = false;
        yield return new WaitForSeconds(timeTillThrowLerpEnables);
        Rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        for (float t = 0; t < travelTime; t += Time.deltaTime)
        {
            float param = t / travelTime;
            float easedParam = Easing.Ease(easetype, param);
            transform.position = Vector3.Lerp(startPos, targetVector, easedParam);
            yield return null;
        }
        Rb.useGravity = true;
    }
}
