using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private float panSpeed, scrollSpeed, zoomLimitMin, zoomLimitMax;
    private Vector2 panLimit;
    private Vector3 touchStart;
    private Camera camera;
    private Transform transform;

    void Awake()
    {
        camera = Camera.main;
        transform = Camera.main.transform;
        InitializeSettings();
    }

    private void InitializeSettings()
    {
        panSpeed = 0.01f;
        scrollSpeed = 500f;
        zoomLimitMin = 2f;
        zoomLimitMax = 10f;
    }
    void Update()
    {
        Vector3 pos = camera.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - camera.ScreenToWorldPoint(Input.mousePosition);
            pos += direction * panSpeed;
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