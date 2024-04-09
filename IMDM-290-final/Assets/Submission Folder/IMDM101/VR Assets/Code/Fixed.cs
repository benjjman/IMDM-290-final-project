using UnityEngine;

public class Fixed : MonoBehaviour
{
    public Texture image;

    public void Load()
    {
        GetComponent<Renderer>().sharedMaterial.mainTexture = image;
    }

}
