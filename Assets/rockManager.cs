using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockManager : MonoBehaviour
{
    // Start is called before the first frame update
    bossManager boss;
    Rigidbody rb;
    void Start()
    {
        boss = GameObject.Find("bossManager").GetComponent<bossManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(boss.fallSpeed * Time.deltaTime, ForceMode.Acceleration);
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
