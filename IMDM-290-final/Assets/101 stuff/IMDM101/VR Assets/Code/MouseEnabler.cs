            using UnityEngine;

public class MouseEnabler : MonoBehaviour
{
    void Start()
    {
        var m = transform.Find("Camera Offset/Main Camera");
        var p = m.GetComponent<ManualPose>();
        p.enabled = true;
    }
}
