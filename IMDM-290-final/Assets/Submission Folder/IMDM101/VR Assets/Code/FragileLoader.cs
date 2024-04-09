using UnityEngine;

public class FragileLoader : MonoBehaviour
{
    public Fragile Serial()
    {
        return transform.Find("PictureFrame").GetComponent<Fragile>(); ;
    }
}

