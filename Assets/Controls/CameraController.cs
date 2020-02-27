using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private float panSpeed, panBorderThickness, scrollSpeed, zoomLimitMin, zoomLimitMax;
    private Vector2 panLimit, zoomLimit;
    private Camera camera;
    private Transform transform;

    void Awake()
    {
        camera = GetComponent<Camera>();
        transform = GetComponent<Transform>();
        InitializeSettings();
    }

    private void InitializeSettings()
    {
        panSpeed = 200f;
        panBorderThickness = 150f;
        scrollSpeed = 500f;
        zoomLimitMin = 2f;
        zoomLimitMax = 10f;
    }
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || ( (Input.mousePosition.y >= Screen.height - panBorderThickness) && Input.mousePosition.y < Screen.height) )
        {
            pos.y += panSpeed / Mathf.Max(10, (Screen.height - Input.mousePosition.y ) ) * Time.deltaTime;
        }

        if (Input.GetKey("a")  || ( (Input.mousePosition.x <= panBorderThickness) && Input.mousePosition.x > 0) )
        {
            pos.x -= panSpeed / Mathf.Max(10, (Input.mousePosition.x) ) * Time.deltaTime;
        }

        if (Input.GetKey("s")  || ( (Input.mousePosition.y <= panBorderThickness) && Input.mousePosition.y > 0) )
        {
            pos.y -= panSpeed / Mathf.Max(10, (Input.mousePosition.y) ) * Time.deltaTime;
        }

        if (Input.GetKey("d")  || ( (Input.mousePosition.x >= Screen.width - panBorderThickness) && Input.mousePosition.x < Screen.width) )
        {
            pos.x += panSpeed / Mathf.Max(10, (Screen.width - Input.mousePosition.x ) ) * Time.deltaTime;
        }

        float zoom = camera.orthographicSize;
        zoom -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
        zoom = Mathf.Clamp(zoom, zoomLimitMin, zoomLimitMax);
        camera.orthographicSize = zoom;
        panLimit = new Vector2( (-1.62f * zoom) + 16.25f, (-0.87f *zoom) + 8.75f);

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        transform.position = pos;
        
    }
}