using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float handTimer;
    public float handSpawn;
    public int handsChance;
    public GameObject handsPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

        //hand spawn stuff 
        handTimer += Time.deltaTime;
        if(handTimer >= handSpawn)
        {
            //need to make chance count
            Instantiate(handsPrefab);
            handTimer = 0;
        }
    }


}
