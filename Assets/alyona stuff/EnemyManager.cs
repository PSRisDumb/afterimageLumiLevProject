using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyCanvas;

    private float handTimer;
    public float handSpawn;
    public int handsChance;
    public GameObject handsPrefab;
    public List<GameObject> handsPrefabs;

    private float photoTimer;
    public float photoSpawn;
    public int photoChance;
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
            int HChance = Random.Range(0, 100);
            Debug.Log(HChance);
            if(handsChance >= HChance)
            {
                Instantiate(handsPrefab);
                
                for (int i = 0; i < handsPrefabs.Count; i++)
                {
                //for spawning the hands as a child to the canvas FIX
                RectTransform hand = Instantiate(handsPrefabs[i], enemyCanvas.transform).GetComponent<RectTransform>();
        
                }
                

                HChance = 0;
                Debug.Log("hands chance sucsess: " + HChance + ">=" + handsChance);
            }
            else
            {
                Debug.Log("hands chance fail: " + HChance + " not >=" + handsChance);

            }
            handTimer = 0;
        }

        //photo spawn stuff
        photoTimer += Time.deltaTime;
        if (photoTimer >= photoSpawn)
        {
            Debug.Log("photo chance...");
            int PChance = Random.Range(0, 100);
            Debug.Log(PChance);
            if(photoChance >= PChance)
            {
                int photo = Random.Range(0,photos.Count);
                RectTransform pos = Instantiate(photos[photo], enemyCanvas.transform).GetComponent<RectTransform>();
                pos.anchoredPosition = new Vector2(Random.Range(-500f, 500f), Random.Range(-300f, 300f));

                PChance = 0;
                Debug.Log("hands chance sucsess: " + PChance + ">=" + photoChance);
            }
            else
            {
                Debug.Log("hands chance fail: " + PChance + " not >=" + photoChance);

            }
            photoTimer = 0;
        }
    }


}
