using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneNumberScript : MonoBehaviour
{
    public PhonePuzzleManager manager;
    public int number;

    private void OnTriggerEnter(Collider other)
    {
        if (manager.isNumberAllowed)
            manager.AddToCombo(number);
        PickUpableObject Object = other.gameObject.GetComponent<PickUpableObject>();
        Object.TravelingStart(manager.player.transform.position);
    }
}
