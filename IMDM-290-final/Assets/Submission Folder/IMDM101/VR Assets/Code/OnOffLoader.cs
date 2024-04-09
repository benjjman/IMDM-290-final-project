using UnityEngine;

public class OnOffLoader : MonoBehaviour
{
    public OnOff Serial()
    {
        return transform.Find("PictureFrame").GetComponent<OnOff>(); ;
    }
}

