 using UnityEngine;

public class Fragile : MonoBehaviour
{
    public Texture image;
    public AudioClip audioClip;

    Renderer r;

    public void Load()
    {
        GetComponent<Renderer>().sharedMaterial.mainTexture = image;
        GetComponent<AudioSource>().clip = audioClip;
    }
    private void Start()
    {
        r = GetComponent<Renderer>();
    }

    private void OnCollisionEnter()
    {
        Debug.Log("Fragile Collision");
        r.enabled = false;
    }
}
