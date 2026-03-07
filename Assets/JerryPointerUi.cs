using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryPointerUi : MonoBehaviour
{
    public float spinDuration = 1f;
    private Coroutine spinRoutine;

    public void RotateToDirection(int camPos)
    {
        if(spinRoutine != null)
        {
            StopCoroutine(spinRoutine);
        }
        spinRoutine = StartCoroutine(Rotate(camPos));
    }

    private IEnumerator Rotate(int camPos)
    {
        //West 90, East 270, North 0, South 180
        float dir = 0;
        switch (camPos)
        {
            case 0:
                dir = 0;
                break;
            case 1:
                dir = 270;
                break;
            case 2:
                dir = 180;
                break;
            case 3:
                dir = 90;
                break;
        }
        Quaternion startRot = transform.localRotation;
        Quaternion endRot = Quaternion.Euler(0,0,dir);
        for (float t = 0; t  < spinDuration; t += Time.deltaTime)
        {
            float param = t/spinDuration;
            float easedParam = Easing.Ease(EaseType.InQuint, param);
            transform.localRotation = Quaternion.Lerp(startRot, endRot, easedParam);
            yield return null;
        }
        transform.localRotation = endRot;
        spinRoutine = null;
    }
}
