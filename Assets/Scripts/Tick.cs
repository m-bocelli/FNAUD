using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tick : MonoBehaviour
{
    private Text hours;

    void Start()
    {
        hours = gameObject.GetComponent<Text>();
        StartCoroutine(UpdateHour());
    }

    IEnumerator UpdateHour() {
        while(hours.text != "6") {
            yield return new WaitForSeconds(10f);
            hours.text = "" + (System.Int32.Parse(hours.text) + 1) % 12;
        }
    }
}
