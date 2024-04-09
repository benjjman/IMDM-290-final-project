using UnityEngine;

public class ShyLoader : MonoBehaviour
{
    public Shy Serial()
    {
        return transform.Find("PictureFrame").GetComponent<Shy>(); ;
    }
}

