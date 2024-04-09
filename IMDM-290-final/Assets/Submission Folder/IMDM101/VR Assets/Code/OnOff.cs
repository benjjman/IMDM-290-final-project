using System.Collections;
using UnityEngine;

public class OnOff : MagicEye
{
    public Texture offImage;
    public Texture onImage;
    public float waitTime;

    public bool playAudio;
    public bool loopAudio;
    public bool muteAudio;

    public AudioClip audioClip;

    AudioSource aSrc;
    Material main;
    Coroutine opener;

    WaitForSeconds wait;
    void Start()
    {
        aSrc = GetComponent<AudioSource>();
        main = GetComponent<Renderer>().material;
        main.mainTexture = offImage;
        wait = new WaitForSeconds(waitTime);
    }

    public void Load()
    {
        GetComponent<Renderer>().sharedMaterial.mainTexture = offImage;
        GetComponent<AudioSource>().clip = audioClip;
    }

    internal override void Open()
    {
        base.Open();

        if (playAudio && !aSrc.isPlaying)
        {
            aSrc.loop = loopAudio;
            aSrc.Play();
        }

        opener = StartCoroutine(Opener());
    }


    internal override void Close()
    {
        base.Close();

        StopCoroutine(opener);

        if (aSrc.isPlaying)
        {
            if (muteAudio)
            {
                aSrc.Stop();
            }
            else
            {
                aSrc.loop = false;
            }
        }

        main.mainTexture = offImage;
    }

    IEnumerator Opener()
    {
        yield return wait;

        main.mainTexture = onImage;
    }
}
