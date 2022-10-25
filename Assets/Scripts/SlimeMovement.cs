using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints;
    private float speed = 12f;
    int currentIndex = 0;
    private void Start() {
        foreach(GameObject wayPoint in GameObject.FindGameObjectsWithTag("Waypoints"))
        {
            waypoints.Add(wayPoint.transform);
        }
    }
    private void Update() {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, waypoints[currentIndex].position, step);
        if(Vector3.Distance(this.transform.position, waypoints[currentIndex].position) <= 0.2f)
        {
            currentIndex++;
            if(currentIndex > waypoints.Count-1)
            {
                Destroy(gameObject);
            }
        }
    }
}
