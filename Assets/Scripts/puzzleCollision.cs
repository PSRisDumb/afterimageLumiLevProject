using System.Collections;
using UnityEngine;

public class puzzleCollision : MonoBehaviour
{
    public GameObject GMS;
    public GameObject dialogue;
    public GameObject ghost;
    public GameObject enemies; // need to access to turn it off 
    public GameObject Sanity; // to to access to turn it on
    private bool ghostOn = false;
    private bool firstTimeLeavingSafeRoom = false;
    public GameStateManager stateManager;
    public AudioSource backGroundMusicAudioSource;
    public AudioClip safeRoomMusic;
    public AudioClip normalAmbience;
    public AudioClip chaseTheme;

    public bool safeRoom;
    public bool safeRoomFst = true;
    // Start is called before the first frame update
    void Start()
    {
        safeRoom = false; 
        backGroundMusicAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "puzzle piece")
        {
            Destroy(collision.gameObject);
            GMS.GetComponent<GMScript>().picUp = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "trigger" && ghostOn == false)
        {
            Destroy(other.gameObject);
            Instantiate(ghost, new Vector3(-11f,21,127), Quaternion.identity);
            ghostOn = true;
            dialogue.GetComponent<dialogueManager>().saf1GO = true;

        }

        
        if (other.gameObject.tag == "saferoom")
        {

            if (safeRoomFst == true)
            {
                dialogue.GetComponent<dialogueManager>().saf2GO = true;
                safeRoomFst = false;

            }
            

            safeRoom = true;
            Debug.Log("in safe room");
            backGroundMusicAudioSource.clip = safeRoomMusic;
            backGroundMusicAudioSource.Play();
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "saferoom")
        {
            safeRoom = false;
            Debug.Log("out of safe room");
            if (!firstTimeLeavingSafeRoom)
            {
                firstTimeLeavingSafeRoom = true;
                stateManager.ProgressState();
            }
            backGroundMusicAudioSource.clip = normalAmbience;
            backGroundMusicAudioSource.Play();
        }
    }
}
