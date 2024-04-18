using UnityEngine;

public class MagicLamp : MonoBehaviour
{
    // Keep track of the previous transform we hit. This will
    // allow us to detect first-time hits of new transforms.

    Transform lastTransform;
    MagicEye[] lastEyes;

    // Start is called before the first frame update
    void Start()
    {
        lastTransform = null;
        lastEyes = null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Did we hit someone new?

            if (hit.transform != lastTransform)
            {
                if (lastEyes != null)
                {
                    foreach (var lastEye in lastEyes)
                    {
                        lastEye.Close();
                    }
                }

                lastTransform = hit.transform;
                lastEyes = lastTransform.GetComponents<MagicEye>();

                if (lastEyes != null)
                {
                    foreach (var lastEye in lastEyes)
                    {
                        lastEye.Open();
                    }
                }
            }
        }
        else
        {
            if (lastEyes != null)
            {
                foreach (var lastEye in lastEyes)
                {
                    lastEye.Close();
                }

                lastTransform = null;
                lastEyes = null;
            }
        }
    }
}
