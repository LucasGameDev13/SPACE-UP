using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    [SerializeField] private AudioSource backGroundMusic;
    [SerializeField] private AudioSource mainMenuMusic;
    [SerializeField] private AudioSource thrustSoundTrigger;
    [SerializeField] private AudioSource soundsEffects;

    [SerializeField] private AudioClip musicBackGround;
    [SerializeField][Range(0, 1)] private float musicBackGroundVolume;
    [SerializeField] private AudioClip musicMainMenu;
    [SerializeField][Range(0, 1)] private float musicMainMenuVolume;


    [SerializeField] private AudioClip buttonsSound;
    [SerializeField][Range(0, 1)] private float buttonsSoundVolume;
    [SerializeField] private AudioClip thrustSound;
    [SerializeField][Range(0, 1)] private float thrustSoundVolume;
    [SerializeField] private AudioClip crashSound;
    [SerializeField][Range(0, 1)] private float crashSoundVolume;
    [SerializeField] private AudioClip checkPointSound;
    [SerializeField][Range(0, 1)] private float checkPointSoundVolume;
    [SerializeField] private AudioClip achieveSuccessSound;
    [SerializeField][Range(0, 1)] private float achieveSuccessSoundVolume;


    private bool isPlaying;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 && !isPlaying)
        {

            PlayMainMenuMusic();

            if (backGroundMusic.isPlaying)
            {

                backGroundMusic.Stop();
            }

            isPlaying = true;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2 && isPlaying)
        {

            PlayBackGroundMusic();

            if (mainMenuMusic.isPlaying)
            {

                mainMenuMusic.Stop();
            }

            isPlaying = false;      
        }
    }

    private void PlayMainMenuMusic()
    {
        GameSoundController(mainMenuMusic, musicMainMenu, musicMainMenuVolume, true);
    }

    private void PlayBackGroundMusic()
    {
        GameSoundController(backGroundMusic, musicBackGround, musicBackGroundVolume, true);
    }

    public void ButtonsSounds()
    {
        GameSoundController(soundsEffects, buttonsSound, buttonsSoundVolume, false);
    }

    public void ThrustSounds()
    {
        GameSoundController(thrustSoundTrigger, thrustSound, thrustSoundVolume, true);
    }

    public void ThrustSoundsStop()
    {
        thrustSoundTrigger.Stop();
    }

    public void CrashSound()
    {
        GameSoundController(soundsEffects, crashSound, crashSoundVolume, false);
    }

    public void CheckPointSound()
    {
        GameSoundController(soundsEffects, checkPointSound, checkPointSoundVolume, false);
    }

    public void SuccessSound()
    {
        GameSoundController(soundsEffects, achieveSuccessSound, achieveSuccessSoundVolume, false);
    }

    private void GameSoundController(AudioSource _audioSource, AudioClip _audioClip, float _volume, bool _loop)
    {
        _audioSource.clip = _audioClip;
        _audioSource.volume = _volume;
        _audioSource.loop = _loop;
        _audioSource.Play();
    }


}
