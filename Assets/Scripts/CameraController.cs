using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float degreesPerSec = 5f;
    [SerializeField] private float maxY = 30f;
    [SerializeField] private float minY;

    void Awake()
    {
        minY = 360 - maxY;
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera() {
        // Clamp turn radius
        if (transform.eulerAngles.y > 180 && transform.eulerAngles.y < minY)
        {
            transform.Rotate(new Vector3(0f, PanRight(), 0f) * Time.deltaTime);
        }
        else if (transform.eulerAngles.y < 180 && transform.eulerAngles.y > maxY)
        {
            transform.Rotate(new Vector3(0f, PanLeft(), 0f) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0f, PanLeft() + PanRight(), 0f) * Time.deltaTime);
        }
    }

    private float PanLeft()
    {
        return Input.mousePosition.x < Screen.width / 3 ? -degreesPerSec : 0f;
    }

    private float PanRight()
    {
        return Input.mousePosition.x > 2 * (Screen.width / 3) ? degreesPerSec : 0f;
    }

}
