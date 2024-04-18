using UnityEngine;
public class Drop : MagicEye
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    internal override void Open()
    {
        base.Open();

        rb.useGravity = true;
    }
}
