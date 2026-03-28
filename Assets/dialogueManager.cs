using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueManager : MonoBehaviour
{
    private string[] currentLines;
    public string[] tutorialLines1;//the opening dialogue with jerry
    public string[] tutorialLines2;//the opening dialogue with jerry
    private bool tut2GO; // See if tut lines 2 has gone
    public string[] tutorialLines3;//the opening dialogue with jerry
    public string[] safeRoomLines1; // lines when the first ghost goes after you
    public string[] safeRoomLines2; // lines when the first ghost goes after you
    public string[] safeRoomLines3; // lines when the first ghost goes after you

    public float textSpd;

    private int index;
    private bool mouseClicked;

    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    public GameObject GMS;

    public GameObject lightSource;
    private float lineChange;

    // Start is called before the first frame update
    void Start()
    {
        lightSource.SetActive(false);
        currentLines = tutorialLines1;
        dialogueText.text = string.Empty;
        StartDialogue(currentLines);
        tut2GO = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(dialogueText.text == currentLines[index])
            {
                nextLine(currentLines);

            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = currentLines[index];
            }
        }

        if (tut2GO) {
            lineChange += Time.deltaTime;

            if (lineChange >= 5f)
            {
                lightSource.SetActive(true);
                currentLines = tutorialLines2;
                StartDialogue(currentLines);
                lineChange = 0;
                tut2GO = false;
            }
        }
        
        if (GMS.GetComponent<GMScript>().doorOpen == true)
        {
            StartDialogue(safeRoomLines1);
        }
        

    }

    void StartDialogue(string[] lines)
    {
        index = 0;
        dialogueBox.SetActive(true);
        dialogueText.text = string.Empty;
        StartCoroutine(TypeLine(lines));
    }

    IEnumerator TypeLine(string[] lines)
    {
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

    void nextLine(string[] lines)
    {
        if  (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine(lines));
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
}

