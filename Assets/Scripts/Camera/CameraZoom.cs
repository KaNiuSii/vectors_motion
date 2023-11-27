using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 0.5f;
    public float minSize = 2.0f;
    public float maxSize = 10.0f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (cam.orthographic)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);
        }
        else
        {
            Debug.LogWarning("CameraZoom script is designed for orthographic cameras.");
        }
    }
}
