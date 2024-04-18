 using UnityEngine;

public class PlaneLoader : MonoBehaviour
{
    public Plane Serial()
    {
        return transform.Find("PictureFrame").GetComponent<Plane>(); ;
    }
}
