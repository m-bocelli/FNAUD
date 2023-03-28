using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] private float minIntensity, maxIntensity;
    private Light _light;
    private Queue<float> flicker;


    void Awake()
    {
        _light = GetComponent<Light>();
        flicker = new Queue<float>(5);
    }

    private void Update()
    {

    }
}
