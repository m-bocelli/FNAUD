using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private int doorSpeed = 15;
    private bool isClosed;
    private Vector3 originalDoorPosition;
    private Vector3 newDoorPosition;
    private LightButton _lightButton;

    private void Awake()
    {
        isClosed = false;
        originalDoorPosition = door.transform.position;
        newDoorPosition = door.transform.position;
    }

    private void Update()
    {
        if (gameObject.GetComponent<Renderer>().isVisible)
        {
            SwitchDoor();
        }
        door.transform.position = Vector3.MoveTowards(door.transform.position, newDoorPosition, doorSpeed * Time.deltaTime);
    }

    private void SwitchDoor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isClosed = !isClosed;
            if (isClosed)
            {
                newDoorPosition = new Vector3(door.transform.position.x, 1.2f, door.transform.position.z);
            }
            else
            {
                newDoorPosition = originalDoorPosition;
            }
            EnableEmission();
        }
    }

    private void EnableEmission()
    {
        if (isClosed)
        {
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
    }

}
