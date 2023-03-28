using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightButton : MonoBehaviour
{
    [SerializeField] private GameObject _light;

    private void OnMouseDown()
    {
        SwitchLight();
    }

    private void SwitchLight()
    {
        _light.SetActive(!_light.activeSelf);
    }

}
