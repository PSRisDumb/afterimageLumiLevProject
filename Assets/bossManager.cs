using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class bossManager : MonoBehaviour
{
    public GameObject roof;
    public GameObject playerObj;

    public Transform player;

    public PlayerMovement playerScript;

    public Vector3 fallSpeed;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(roofFallingRoutine());
        StartCoroutine(randomRoofFallingRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void roofFalling(float x, float y, float z)
    {
        Instantiate(roof, new Vector3(x,  y + offset, z), Quaternion.identity);
    }

    public void camAttack()
    {

    }

    public IEnumerator roofFallingRoutine()
    {
        yield return new WaitForSeconds(5);
        roofFalling(player.position.x, player.position.y, player.position.z);
        StartCoroutine(roofFallingRoutine());
    }
    public IEnumerator randomRoofFallingRoutine()
    {
        yield return new WaitForSeconds(2);
        roofFalling(UnityEngine.Random.Range(-40, 40), 0, UnityEngine.Random.Range(-40, 40));
        StartCoroutine(randomRoofFallingRoutine());
    }
    public IEnumerator cameraSwitch()
    {
        yield return new WaitForSeconds(10);

    }
}
