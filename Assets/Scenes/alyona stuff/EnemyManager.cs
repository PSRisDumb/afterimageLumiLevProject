using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyCanvas;

    public bool activateH;
    private float handTimer;
    public float handSpawn;
    public int handsChance;
    public List<GameObject> handsPrefabs;

    public bool activateP;
    private float photoTimer;
    public float photoSpawn;
    public int photoChance;
    public List<GameObject> photos;

    public bool activateF;
    public List<GameObject> floater;
    public int spawnRange;
    private float floaterTimer;
    public float floaterSpawn;
    public int floaterChance;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<puzzleCollision>().safeRoom == false)
        {
            //hand spawn stuff 
            if (activateH)
            {
                handTimer += Time.deltaTime;
                if (handTimer >= handSpawn)
                {
                    // Debug.Log("hands chance...");
                    int HChance = Random.Range(0, 100);
                    // Debug.Log(HChance);
                    if (handsChance >= HChance)
                    {

                        for (int i = 0; i < handsPrefabs.Count; i++)
                        {
                            //for spawning the hands as a child to the canvas FIX
                            RectTransform hand = Instantiate(handsPrefabs[i], enemyCanvas.transform).GetComponent<RectTransform>();

                        }


                        HChance = 0;
                        // Debug.Log("hands chance sucsess: " + HChance + ">=" + handsChance);
                    }
                    else
                    {
                        //Debug.Log("hands chance fail: " + HChance + " not >=" + handsChance);

                    }
                    handTimer = 0;
                }
            }

            //photo spawn stuff
            if (activateP)
            {
                photoTimer += Time.deltaTime;
                if (photoTimer >= photoSpawn)
                {
                    // Debug.Log("photo chance...");
                    int PChance = Random.Range(0, 100);
                    //Debug.Log(PChance);
                    if (photoChance >= PChance)
                    {
                        int photo = Random.Range(0, photos.Count);
                        RectTransform pos = Instantiate(photos[photo], enemyCanvas.transform).GetComponent<RectTransform>();
                        pos.anchoredPosition = new Vector2(Random.Range(-500f, 500f), Random.Range(-300f, 300f));

                        PChance = 0;
                        // Debug.Log("hands chance sucsess: " + PChance + ">=" + photoChance);
                    }
                    else
                    {
                        // Debug.Log("hands chance fail: " + PChance + " not >=" + photoChance);

                    }
                    photoTimer = 0;
                }
            }

            //spawns floaters
            if (activateF)
            {
                floaterTimer += Time.deltaTime;
                if (floaterTimer >= floaterSpawn)
                {
                    //Debug.Log("floater chance ...");
                    int fChance = Random.Range(0, 100);
                    //Debug.Log(fChance);
                    if (floaterChance >= fChance)
                    {
                        //MAKE SPAWN FOR FLOATER, need to figurse out how to make it spawn near the player

                        int num = Random.Range(0, 2);
                        float xPos = player.transform.position.x - Random.Range(-spawnRange, spawnRange);
                        float zPos = player.transform.position.z - Random.Range(-spawnRange, spawnRange);
                        Instantiate(floater[num], new Vector3(xPos, player.transform.position.y, zPos), Quaternion.identity);
                        fChance = 0;
                    }
                    floaterTimer = 0;
                }
            }
        }
    }

}

