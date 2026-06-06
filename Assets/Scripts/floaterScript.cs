using System.Linq;
using UnityEngine;

public class floaterScript : MonoBehaviour
{
    public GameObject player;
    public int sanityDrain;
    public int spd;

    public GameObject sanityScr;
    private float sanity;

    public float Death; // death timer

    private int rotate;
    public puzzleCollision puzzleCollision;
    public AudioClip floaterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        sanityScr = GameObject.Find("sanity manager");
        player = GameObject.Find("Player");
        puzzleCollision = player.GetComponent<puzzleCollision>();
        if (puzzleCollision.backGroundMusicAudioSource.clip != puzzleCollision.chaseTheme)
        {
            puzzleCollision.backGroundMusicAudioSource.clip = puzzleCollision.chaseTheme;
            puzzleCollision.backGroundMusicAudioSource.Play();
        }
        player.GetComponent<CameraMoveAround>().SFXAudioSource.PlayOneShot(floaterSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        Death += Time.deltaTime;
        if(Death >= 15f)
        {
            Destroy(gameObject);
        }

        Vector3 baseMovement = Vector3.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);

        float ghostFloat = Mathf.PingPong(Time.time * 0.1f, 0.1f)-0.05f;
        transform.position = baseMovement + new Vector3(0, ghostFloat, 0);

        if(player.GetComponent<puzzleCollision>().safeRoom == true)
        {
            Destroy(gameObject);
        }



        if (player.GetComponent<CameraMoveAround>().CamPos == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (player.GetComponent<CameraMoveAround>().CamPos == 1)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (player.GetComponent<CameraMoveAround>().CamPos == 2)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (player.GetComponent<CameraMoveAround>().CamPos == 3)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            sanity -= sanityDrain;
            sanityScr.GetComponent<sanityManager>().sanity -= sanityDrain;
            // --- music stuff
            GameObject[] floaters = GameObject.FindGameObjectsWithTag("floater");
            if (floaters.Length < 2)
            {
                puzzleCollision.backGroundMusicAudioSource.clip = puzzleCollision.normalAmbience;
                puzzleCollision.backGroundMusicAudioSource.Play();
            }
            Destroy(gameObject);
        }

    }
        
   
}
