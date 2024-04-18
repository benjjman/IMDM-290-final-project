using UnityEngine;
using UnityEngine.SpatialTracking;

public class ManualPose : MonoBehaviour
{
    public float mouseSensitivity = 3;
    public float speed = 1;
    public bool freeMove = false;

    float xRot;
    float yRot;

    void Start()
    {
        TrackedPoseDriver tdp = GetComponent<TrackedPoseDriver>();
        tdp.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        yRot = transform.localEulerAngles.y;
        transform.Translate(0, 1, 0);
    }

    void Update()
    {
        if(freeMove == true){
            Vector3 path = speed * Time.deltaTime * transform.forward;

            transform.position += Input.GetAxis("Fire1") * path;
            transform.position -= Input.GetAxis("Fire2") * path;

            transform.position = transform.position.Clamp(-5, 5, .1f, 10, -5, 5);
        }
        xRot += -mouseSensitivity * Input.GetAxis("Mouse Y");
        xRot = Mathf.Clamp(xRot, -89, 89);
        yRot += mouseSensitivity * Input.GetAxis("Mouse X");


        while (yRot > 360) yRot -= 360;
        while (yRot < 0) yRot += 360;

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
    }
}


public static class Vector3Extensions
{
    public static Vector3 Clamp(
        this Vector3 v,
        float xMin, float xMax,
        float yMin, float yMax,
        float zMin, float zMax)
    {
        v.x = v.x < xMin ? xMin : v.x > xMax ? xMax : v.x;
        v.y = v.y < yMin ? yMin : v.y > yMax ? yMax : v.y;
        v.z = v.z < zMin ? zMin : v.z > zMax ? zMax : v.z;

        return v;
    }
}