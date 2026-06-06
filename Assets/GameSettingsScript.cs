using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsScript : MonoBehaviour
{
    public static GameSettingsScript instance;
    public float BGMusicVolume;
    public float SFXVolume;
    public float footstepVolume;

    public Slider BGMusicSlider;
    public Slider SFXSlider;
    public Slider footStepSlider;

    public AudioSource SFXtest;
    public AudioSource MainMenuBGMusic;

    // Main Game Scene -----
    public GameObject Player;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        Player = GameObject.Find("Player");
        if (Player != null)
        {
            Player.GetComponent<CameraMoveAround>().SFXAudioSource.volume = SFXVolume;
            Player.GetComponent<puzzleCollision>().backGroundMusicAudioSource.volume = BGMusicVolume;
            Player.GetComponent<CameraMoveAround>().footStepSound.volume = footstepVolume;
            Destroy(gameObject);
        }
    }
    public void ChangeValue(int X) // 1 BgMusic, 2 sfx, 3 Footsteps
    {
        if (X == 1)
        {
            BGMusicVolume = BGMusicSlider.value;
            MainMenuBGMusic.volume = BGMusicVolume;
        }
        else if (X == 2)
        {
            SFXVolume = SFXSlider.value;
            SFXtest.volume = SFXVolume;
            SFXtest.Play();
        }
        else if (X == 3)
        {
            footstepVolume = footStepSlider.value;
            SFXtest.volume = footstepVolume;
            SFXtest.Play();
        }
        else
            Debug.LogError("Settings Broke");
    }
}
