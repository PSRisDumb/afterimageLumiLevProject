using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageManager : MonoBehaviour
{
    public List<Sprite> images;
    public List<float> waitTimes;
    public List<AudioClip> audioClips;
    public Image currImage;
    public Animator blink;
    public AudioSource AS;
    public AudioClip blinkNoise;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playIntro());
    }
    public IEnumerator playIntro()
    {
        for (int  i = 0;  i < images.Count;  i++)
        {
            yield return new WaitForSeconds(waitTimes[i]);
            blink.Play("Empty State");
            blink.Play("doodledoodle");
            yield return new WaitForSeconds(0.1156f);
            AS.PlayOneShot(blinkNoise);
            currImage.sprite = images[i];
            AS.PlayOneShot(audioClips[i]);
        }
        blink.Play("Empty State");
        blink.Play("doodledoodle");
        yield return new WaitForSeconds(0.1156f);
        AS.PlayOneShot(blinkNoise);
        yield return new WaitForSeconds(0.1156f);
        SceneManager.LoadScene(2);
    }
}
