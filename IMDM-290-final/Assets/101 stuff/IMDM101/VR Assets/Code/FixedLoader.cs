using UnityEngine;

public class FixedLoader : MonoBehaviour
{
    public Fixed Serial()
    {
        return transform.Find("PictureFrame").GetComponent<Fixed>(); ;
    }
}
