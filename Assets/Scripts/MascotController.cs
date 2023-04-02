using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascotController : MonoBehaviour
{
    [SerializeField] private Transform positionHolder;
    private Vector3[] locations;

    [Range(1,20)]
    [SerializeField] private int activityLevel = 3; // How active the mascot is (lower value == less chance to move)

    private float updateInterval = 5f; // How often mascot has a chance to move in seconds
    private float updateTimer = 0f;

    private Dictionary<Vector3, Vector3> rotations;

    public delegate void OnChangePosition();
    OnChangePosition onChangePosition;

    private void Awake()
    {
        locations = new Vector3[positionHolder.childCount];
        rotations = new Dictionary<Vector3, Vector3>();
        for (int i = 0; i < locations.Length; i++)
        { 
            // Get locations and euler angles of each possible mascot location
            locations[i] = positionHolder.GetChild(i).position;
            // Rotations of each location into hash map, accessible by its vector3 location
            rotations.Add(locations[i], positionHolder.GetChild(i).localEulerAngles);
        }
    }

    private void Update()
    {
        updateTimer += Time.deltaTime;
        if (updateTimer > updateInterval) {
            if (Random.Range(1, 20) <= activityLevel) 
            {
                ChangePosition(locations[Random.Range(0, locations.Length -1)]);
                print("move");
            }
            updateTimer -= updateInterval;
        }
    }


    private void ChangePosition(Vector3 location)
    {
        // Tell other scripts mascot is changing position
        onChangePosition?.Invoke();
        transform.position = location;
        transform.rotation = Quaternion.Euler(0f, rotations[location].y, 0f);
    }

}
