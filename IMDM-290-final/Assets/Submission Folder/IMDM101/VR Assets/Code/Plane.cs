using UnityEngine;

public class Plane : MonoBehaviour
{
    public Texture image;

    public void Load()
    {
        GetComponent<Renderer>().sharedMaterial.mainTexture = image;
    }

}
