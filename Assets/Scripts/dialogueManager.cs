using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public Image characterBase;
    public Sprite[] characters;

    public CameraMoveAround PlayerMovement;
    public float DialougeSpeed;

    private string[] currentLines;
    private int[] currentSpeaker;
    public string[] tutorialLines1;//the opening dialogue with jerry
    public int[] tut1Speaker; //see whos talking 
    public string[] tutorialLines2;//the opening dialogue with jerry
    public int[] tut2Speaker; //see whos talking 
    private bool tut2GO; // See if tut lines 2 has gone
    public string[] tutorialLines3;//the opening dialogue with jerry
    public int[] tut3Speaker; //see whos talking 
    private bool tut3Go;
    public string[] safeRoomLines1; // lines when the first ghost goes after you
    public int[] saf1speaker; //see whos talking 
    public bool saf1GO = false;
    public string[] safeRoomLines2; // lines when the first ghost goes after you
    public int[] saf2speaker; //see whos talking 
    public bool saf2GO = false;
    public float textSpd;
    
    private int index;
    private bool mouseClicked;

    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    public GameObject flashlight;
    public GameObject GMS;
    public puzzleCollision puzzleCollision;

    public GameObject lightSource;
    private float lineChange;

    public TextMeshProUGUI explanation;
    private bool expl1; // explains how to move and that no sanity will be lost at that pt
    private bool expl2; // explains how to look around, how to pick up smth, and what you need to do
    private float explT; //timer for the explinations to run
    // Start is called before the first frame update
    void Start()
    {
        //begin the game in the dark with tut lines playing
        lightSource.SetActive(false);
        PlayerMovement.enabled = false;
        currentLines = tutorialLines1;
        currentSpeaker = tut1Speaker;
        dialogueText.text = string.Empty;
        StartDialogue(currentLines, tut1Speaker);

        expl1 = true;
        explanation.text = "";
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(dialogueText.text == currentLines[index])
            {
                nextLine(currentLines, currentSpeaker);
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = currentLines[index];
            }
        }

        if (expl1)
        {
            explT += Time.deltaTime;
            if (explT >= 3)
            {
                explanation.text = "WASD to walk";
                PlayerMovement.enabled = true;
                PlayerMovement.speed = DialougeSpeed;
            }
            if(explT >= 5)
            {
                explanation.text = "Q & E to look around";
            }
            if (explT >= 7)
            {
                explanation.text = "no sanity will be lost in this room during the tutorial";
            }
            if(explT >= 10) 
             {
                    explanation.text = "";
                    tut2GO = true;
                    expl1 = false;
             }
        }
        if (tut2GO) {
            puzzleCollision.AS.PlayOneShot(puzzleCollision.normalAmbience);
            lineChange += Time.deltaTime;

            if (lineChange >= 3f)
            {
                lightSource.SetActive(true);
                PlayerMovement.speed = 10;
                //flashlight.SetActive(true);
                currentLines = tutorialLines2;
                currentSpeaker = tut2Speaker;
                StartDialogue(currentLines, tut2Speaker);
                lineChange = 0;
                tut2GO = false;
                tut3Go = true;
            }
        }
        
        if (GMS.GetComponent<GMScript>().piece == true && tut3Go)
        {
            currentLines = tutorialLines3;
            currentSpeaker = tut3Speaker;
            StartDialogue(currentLines, currentSpeaker);
            tut3Go = false;
        }

        if (saf1GO)
        {
            currentLines = safeRoomLines1;
            currentSpeaker = saf1speaker;
            StartDialogue(currentLines, currentSpeaker);
            saf1GO = false;
            lightSource.SetActive(false);
            flashlight.SetActive(true);
        }

        if (saf2GO)
        {
            currentLines = safeRoomLines2;
            currentSpeaker = saf2speaker;
            StartDialogue(currentLines, currentSpeaker);
            saf2GO = false;
        }
    }

    void StartDialogue(string[] lines, int[] speaker)
    {
        index = 0;
        dialogueBox.SetActive(true);
        dialogueText.text = string.Empty;
        StartCoroutine(TypeLine(lines, speaker));
    }

    IEnumerator TypeLine(string[] lines, int[] speaker)
    {
        if(speaker[index] == 0)
        {
            characterBase.sprite = characters[0];
        }
        else if(speaker[index] == 1)
        {
            characterBase.sprite = characters[1];
        }
        else
        {
            characterBase.sprite = characters[2];

        }

        if (!mouseClicked)
        {
            foreach(char c in lines[index].ToCharArray())
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(textSpd);

            }
        }
        else if (mouseClicked)
        {
            dialogueText.text = lines[index];
        }
    }

    void nextLine(string[] lines, int[] speaker)
    {
        if  (index < lines.Length - 1)
        {

            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine(lines, speaker));
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
}

