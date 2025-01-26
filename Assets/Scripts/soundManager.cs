using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    private static soundManager instance;
    public static soundManager Instance
    {
        get
        {
            if(instance == null)
            {
                UnityEngine.Debug.LogError("Sound manager is null");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private AudioClip song;
    [SerializeField] private List<AudioClip> sfx;
    [SerializeField] private List<AudioSource> children;

    void Start()
    {
        //Setup song sound player
        GameObject s = new GameObject("song");
        AudioSource a = s.AddComponent<AudioSource>();
        a.loop = false;
        a.playOnAwake = false;
        a.clip = song;
        s.transform.SetParent(gameObject.transform);
        children.Add(a);

        //Setup sfx players
        for (int i = 0; i < sfx.Count; i++)
        {
            GameObject g = new GameObject("sfx" + i);
            AudioSource f = g.AddComponent<AudioSource>();
            f.loop = false;
            f.playOnAwake = false;
            f.clip = sfx[i];
            g.transform.SetParent(gameObject.transform);
            children.Add(f);
        }

    }

    //Function to play game song
    public void startSong()
    {
        children[0].Play();
    }

    //function to play a sound effect from the list
    public void playSFX(int i)
    {
        children[i + 1].Play();
    }
}
