using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightButton : MonoBehaviour
{
    [SerializeField] private GameObject _light;

    private void Update()
    {
        if (gameObject.GetComponent<Renderer>().isVisible) 
        {
            SwitchLight();
        }
    }

    private void SwitchLight()
    {
        if (Input.GetKeyDown(KeyCode.Q)) _light.SetActive(!_light.activeSelf);
    }

}
