using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyCanvas;

    private float handTimer;
    public float handSpawn;
    public int handsChance;
    public GameObject handsPrefab;
    //public List<GameObject> handsPrefabs;

    public List<GameObject> photos;
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
            Debug.Log("hands chance...");
            int Chance = Random.Range(0, 100);
            Debug.Log(Chance);
            if(handsChance >= Chance)
            {
                Instantiate(handsPrefab);
                //for (int i = 0; i < handsPrefabs.Count; i++)
                //{
                //for spawning the hands as a child to the canvas FIX
                //GameObject PrefabObject = Instantiate(handsPrefabs[i]);
                //PrefabObject.transform.parent = enemyCanvas.transform;
                //}


                Chance = 0;
                Debug.Log("hands chance sucsess: " + Chance + ">=" + handsChance);
            }
            else
            {
                Debug.Log("hands chance fail: " + Chance + " not >=" + handsChance);

            }
            handTimer = 0;
        }
    }


}
