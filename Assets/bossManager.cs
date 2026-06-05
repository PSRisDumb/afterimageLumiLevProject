using System.Collections;
using UnityEngine;

public class bossManager : MonoBehaviour
{
    public GameObject roof;
    public GameObject playerObj;
    public GameObject bossObj;
    public GameObject rot1;
    public GameObject rot2;
    public GameObject rot3;

    public Transform player;

    public Transform bossPrevious;
    public Transform bossTarget;

    public CameraMoveAround playerScript;

    public Vector3 fallSpeed;
    public Vector3 bossOffset;


    public float offset;
    public float timeOfFlight = 20f;

    private float elapsedTime = 0f;
    private bool isMoving = false;
    private bool alreadySlowed;

    public bool attackThrough;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerScript = playerObj.GetComponent<CameraMoveAround>();
        StartCoroutine(roofFallingRoutine());
        StartCoroutine(randomRoofFallingRoutine());
        StartCoroutine(cameraSwitch());
        StartCoroutine(bossAnim());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime/timeOfFlight);

            bossObj.transform.position = Vector3.Lerp(bossPrevious.position, bossTarget.position - bossOffset, t);

            if(t >= 1)
            {
                isMoving = false;
                if(bossTarget != null)
                {
                    if(bossTarget.position == playerScript.CamList[playerScript.CamPos].transform.localPosition && !alreadySlowed)
                    {
                        alreadySlowed = true;
                        StartCoroutine(slowEffect());
                    }
                }
            }
        }
        
    }

    public void roofFalling(float x, float y, float z)
    {
        Instantiate(roof, new Vector3(x,  y + offset, z), Quaternion.identity);
    }

    public void camAttack()
    {
        bossPrevious = bossObj.transform;
        bossTarget = playerScript.CamList[playerScript.CamPos].GetComponent<Transform>();
        elapsedTime = 0f;
        isMoving = true;
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
        roofFalling(Random.Range(-40, 40), 0, Random.Range(-40, 40));
        StartCoroutine(randomRoofFallingRoutine());
    }
    public IEnumerator cameraSwitch()
    { 
        yield return new WaitForSeconds(11);
        camAttack();
        StartCoroutine(cameraSwitch());
    }
    public IEnumerator slowEffect()
    {
        playerScript.speed = 0.02f;
        yield return new WaitForSeconds(2);
        playerScript.speed = 10;
        yield return new WaitForSeconds(3);
        alreadySlowed = false;
    }
    public IEnumerator bossAnim()
    {
        yield return new WaitForSeconds(.3f);
        bossObj.transform.rotation.Set(rot1.GetComponent<Transform>().rotation.x, rot1.GetComponent<Transform>().rotation.y, rot1.GetComponent<Transform>().rotation.z, rot1.GetComponent<Transform>().rotation.w);
        yield return new WaitForSeconds(.3f);
        bossObj.transform.rotation.Set(rot2.GetComponent<Transform>().rotation.x, rot2.GetComponent<Transform>().rotation.y, rot2.GetComponent<Transform>().rotation.z, rot2.GetComponent<Transform>().rotation.w);
        yield return new WaitForSeconds(.3f);
        bossObj.transform.rotation.Set(rot3.GetComponent<Transform>().rotation.x, rot3.GetComponent<Transform>().rotation.y, rot3.GetComponent<Transform>().rotation.z, rot3.GetComponent<Transform>().rotation.w);
        StartCoroutine(bossAnim());
    }
}
