using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{

    public Sound[] sounds;

    public float volume_scale;

    public static BGMManager instance;

    // Use this for initialization
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        volume_scale = PlayerPrefs.GetFloat("Music");

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * volume_scale;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //if (SceneManager.GetActiveScene().name == "MainMenu")
        //    StartCoroutine(PlayWithFadeIn("Theme_MainMenu", 0.15f));
        //else
        //{
        //    switch (GameController.SAVE_POINT)
        //    {
        //        case "QAGameSavePoint":
        //            StartCoroutine(PlayWithFadeIn("After_Autumn", 0.01f));
        //            break;
        //        case "QAGameFinish":
        //            StartCoroutine(PlayWithFadeIn("After_QA", 0.01f));
        //            break;
        //        case "HurdleSavePoint":
        //            StartCoroutine(PlayWithFadeIn("After_QA", 0.01f));
        //            break;
        //        case "HurdlesFinish":
        //            StartCoroutine(PlayWithFadeIn("After_Hurdles", 0.01f));
        //            break;
        //        case "CareerStartSavePoint":
        //            StartCoroutine(PlayWithFadeIn("Theme_Career", 0.01f));
        //            break;
        //        case "JumpingGameSavePoint":
        //            StartCoroutine(PlayWithFadeIn("Theme_LoseFriend", 0.01f));
        //            break;
        //        case "JumpingGameFinish":
        //            StartCoroutine(PlayWithFadeIn("Theme_LoseFriend", 0.01f));
        //            break;
        //        case "DreamStartSavePoint":
        //            StartCoroutine(PlayWithFadeIn("Dream_Path", 0.01f));
        //            break;
        //        case "RocksFallingSavePoint":
        //            StartCoroutine(PlayWithFadeIn("Theme_Career", 0.01f));
        //            break;
        //        case "RocksFallingFinish":
        //            StartCoroutine(PlayWithFadeIn("Theme_Career", 0.01f));
        //            break;
        //        case "CareerFinalSavePoint":
        //            StartCoroutine(PlayWithFadeIn("Theme_Career", 0.01f));
        //            break;
        //        case "GhostStartSavePoint":
        //            StartCoroutine(PlayWithFadeIn("Ghost", 0.01f));
        //            break;
        //    }
        //}
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
            return;
        }
        s.source.Stop();
        s.source.volume = s.volume * volume_scale;
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
            return;
        }
        s.source.Pause();
    }

    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
            return;
        }
        s.source.UnPause();
    }

    public IEnumerator PlayWithFadeIn(string name, float speed)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float MaxVolume = s.volume;
        float CurrVolume = 0f;
        s.source.volume = CurrVolume * volume_scale;
        yield return new WaitForEndOfFrame();
        s.source.Play();
        while (CurrVolume <= MaxVolume)
        {
            CurrVolume += speed;
            s.source.volume = CurrVolume * volume_scale;
            yield return new WaitForSeconds(0.1f);
        }
        s.source.volume = MaxVolume * volume_scale;
    }

    public IEnumerator StopWithFadeOut(string name, float speed)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float CurrVolume = s.volume;
        while (CurrVolume >= 0)
        {
            CurrVolume -= speed;
            s.source.volume = CurrVolume * volume_scale;
            yield return new WaitForSeconds(0.1f);
        }
        s.source.Stop();
        s.source.volume = s.volume * volume_scale;
    }

    public IEnumerator VolumeFade(string name, float AimVolume ,float speed)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float CurrVolume = s.volume;
        if (AimVolume > s.volume)
        {
            while (CurrVolume <= AimVolume)
            {
                CurrVolume += speed;
                s.source.volume = CurrVolume * volume_scale;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (AimVolume < s.volume)
        {
            while (CurrVolume <= AimVolume)
            {
                CurrVolume -= speed;
                s.source.volume = CurrVolume * volume_scale;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public bool isPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s.source.isPlaying;
    }

    public void setVolume(float volScale)
    {
        foreach (Sound s in sounds)
        {
            volume_scale = volScale;
            PlayerPrefs.SetFloat("Music", volScale);
            s.source.volume = s.volume * volume_scale;
        }
    }

}
