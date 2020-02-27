using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private float panSpeed, panBorderThickness, scrollLimitMin, scrollLimitMax;
    private Vector2 panLimit;
    private Vector3 scrollSpeed;
    public Transform mapTransform;

    void Awake()
    {
        panSpeed = 10000f;
        panBorderThickness = 150f;
        panLimit = new Vector2(9f, 5f);
        scrollSpeed = new Vector3(1f, 1f, 1f);
        scrollLimitMax = 0.02f;
        scrollLimitMin = .005f;
    }
    void Update()
    {
        Vector3 pos = mapTransform.position;
        Vector3 scale = mapTransform.localScale;

        if (Input.GetKey("w") || ( (Input.mousePosition.y >= Screen.height - panBorderThickness) && Input.mousePosition.y < Screen.height) )
        {
            pos.y -= panSpeed / Mathf.Max(10, (Screen.height - Input.mousePosition.y ) ) * Time.deltaTime * scale.y;
        }

        if (Input.GetKey("a")  || ( (Input.mousePosition.x <= panBorderThickness) && Input.mousePosition.x > 0) )
        {
            pos.x += panSpeed / Mathf.Max(10, (Input.mousePosition.x) ) * Time.deltaTime * scale.x;
        }

        if (Input.GetKey("s")  || ( (Input.mousePosition.y <= panBorderThickness) && Input.mousePosition.y > 0) )
        {
            pos.y += panSpeed / Mathf.Max(10, (Input.mousePosition.y) ) * Time.deltaTime * scale.y;
        }

        if (Input.GetKey("d")  || ( (Input.mousePosition.x >= Screen.width - panBorderThickness) && Input.mousePosition.x < Screen.width) )
        {
            pos.x -= panSpeed / Mathf.Max(10, (Screen.width - Input.mousePosition.x ) ) * Time.deltaTime * scale.x;
        }

        scale += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        scale.x = Mathf.Clamp(scale.x, scrollLimitMin, scrollLimitMax);
        scale.y = Mathf.Clamp(scale.y, scrollLimitMin, scrollLimitMax);
        scale.z = Mathf.Clamp(scale.z, scrollLimitMin, scrollLimitMax);

        mapTransform.position = pos;
        mapTransform.localScale = scale;
    }
}
