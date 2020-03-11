using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public float volume_scale;

    public static AudioManager instance;

	// Use this for initialization
	void Awake () {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        volume_scale = PlayerPrefs.GetFloat("Sound");

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * volume_scale;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
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
    }

    public IEnumerator PlayWithFadeIn(string name, float speed)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float MaxVolume = s.volume;
        float CurrVolume = 0f;
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
            PlayerPrefs.SetFloat("Sound", volScale);
            s.source.volume = s.volume * volume_scale;
        }
    }

    //public void MusicFadeIn(string name, float speed)
    //{
    //    StartCoroutine(StopWithFadeOut(name, speed));
    //}

    //public void MusicFadeOut(string name, float speed)
    //{
    //    StartCoroutine(StopWithFadeOut(name, speed));
    //}

}
