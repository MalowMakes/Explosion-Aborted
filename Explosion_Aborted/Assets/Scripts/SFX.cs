using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource source;
    public AudioClip gunshot;
    public AudioClip empty;
    public AudioClip reload;
    public AudioClip robot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gunSound()
    {
        source.PlayOneShot(gunshot);
    }

    public void emptySound()
    {
        source.PlayOneShot(empty);
    }

    public void robotSound()
    {
        source.PlayOneShot(robot);
    }

    public void reloadSound()
    {
        source.PlayOneShot(reload);
    }

    public void stopReloadSound()
    {

    }
}
