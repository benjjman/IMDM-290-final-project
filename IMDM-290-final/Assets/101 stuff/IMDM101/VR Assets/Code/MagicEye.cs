using UnityEngine;

public class MagicEye : MonoBehaviour
{
    internal virtual void Open()
    {
        Debug.Log($"Opening {name}");
    }
    internal virtual void Close()
    {
        Debug.Log($"Closing {name}");
    }
}
