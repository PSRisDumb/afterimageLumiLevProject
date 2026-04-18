using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneNumberScript : MonoBehaviour
{
    public PhonePuzzleManager manager;
    public int number;
    public float EjectForce;

    private void OnTriggerExit(Collider other)
    {
        manager.AddToCombo(number);
        GameObject Item = other.gameObject;
        Rigidbody rb = Item.GetComponent<Rigidbody>();
    }
}
