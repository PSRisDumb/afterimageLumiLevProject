using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneNumberScript : MonoBehaviour
{
    public PhonePuzzleManager manager;
    public int number;
    public bool isClear;

    private void OnTriggerEnter(Collider other)
    {
        if (isClear)
        {
            manager.combo = "";
            manager.display.text = "CLEAR CLEAR CLEAR";
            StartCoroutine(manager.isNumberAllowedReset());
        }
        else if (manager.isNumberAllowed)
            manager.AddToCombo(number);
        PickUpableObject Object = other.gameObject.GetComponent<PickUpableObject>();
        Object.TravelingStart(manager.player.transform.position);
    }
}
