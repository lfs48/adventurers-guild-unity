using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private float panSpeed, panBorderThickness;
    private Vector2 panLimit;
    private Transform transform;

    void Awake()
    {
        panSpeed = 2f;
        panBorderThickness = 200f;
        panLimit = new Vector2(9f, 5f);
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || ( (Input.mousePosition.y >= Screen.height - panBorderThickness) && Input.mousePosition.y < Screen.height) )
        {
            pos.y += panSpeed * 200 / Mathf.Max(10, (Screen.height - Input.mousePosition.y ) ) * Time.deltaTime;
        }

        if (Input.GetKey("a")  || ( (Input.mousePosition.x <= panBorderThickness) && Input.mousePosition.x > 0) )
        {
            pos.x -= panSpeed * 200 / Mathf.Max(10, (Input.mousePosition.x) ) * Time.deltaTime;
        }

        if (Input.GetKey("s")  || ( (Input.mousePosition.y <= panBorderThickness) && Input.mousePosition.y > 0) )
        {
            pos.y -= panSpeed * 200 / Mathf.Max(10, (Input.mousePosition.y) ) * Time.deltaTime;
        }

        if (Input.GetKey("d")  || ( (Input.mousePosition.x >= Screen.width - panBorderThickness) && Input.mousePosition.x < Screen.width) )
        {
            pos.x += panSpeed * 200 / Mathf.Max(10, (Screen.width - Input.mousePosition.x ) ) * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}