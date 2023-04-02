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
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            _light.SetActive(!_light.activeSelf);
            EnableEmission();
        }
    }

    private void EnableEmission()
    {
        if (_light.activeSelf) 
        {
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        } else {
            gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
    }

}
