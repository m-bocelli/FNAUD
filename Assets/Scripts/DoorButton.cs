using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private LightButton _lightButton;

    private void Update()
    {
        if (gameObject.GetComponent<Renderer>().isVisible) 
        {
            SwitchDoor();
        }
    }

    private void SwitchDoor()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            
        }
    }

}
