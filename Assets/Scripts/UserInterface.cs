using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private Text hours;
    private float hourLength = 10f;
    public delegate void OnGameWin();
    OnGameWin _onGameWin;

    private void Awake()
    {
        StartCoroutine(UpdateHour());
    }

    private IEnumerator UpdateHour() {
        while(hours.text != "6") {
            yield return new WaitForSeconds(hourLength);
            hours.text = "" + (System.Int32.Parse(hours.text) + 1) % 12;
        }
        _onGameWin?.Invoke();
        print("win");
    }


}
