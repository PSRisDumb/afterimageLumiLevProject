using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bossManager : MonoBehaviour
{
    public GameObject roof;
    public Transform player;

    public Vector3 fallSpeed;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(roofFallingRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roofFalling()
    {
        Instantiate(roof, new Vector3(player.position.x, player.position.y + offset, player.position.z), Quaternion.identity);
    }
    public IEnumerator roofFallingRoutine()
    {
        yield return new WaitForSeconds(5);
        roofFalling();
        StartCoroutine(roofFallingRoutine());
    }
}
