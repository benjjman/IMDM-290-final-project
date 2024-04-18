using UnityEngine;

public class FragileSound : MonoBehaviour
{
    AudioSource aSrc;

    void Start()
    {
        aSrc = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter()
    {
        aSrc.Play();
    }
}
