using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour {
    [SerializeField] private GameObject actualPlatform;

    [SerializeField] private GameObject[] intermediaryPoints;

    [SerializeField] private float speed = 3;

    private int _index;
    private float _maxDistanceBetweenVectors = 1f;
    void Start() {
    }
    
    void Update()
    { 
        if (Vector3.Distance(
            actualPlatform.transform.position,
            intermediaryPoints[_index].transform.position) < _maxDistanceBetweenVectors) {
            _index++;
            if (_index == intermediaryPoints.Length) {
                _index = 0;
            }   
        } else {
            actualPlatform.transform.position =
                Vector3.MoveTowards(
                    actualPlatform.transform.position,
                    intermediaryPoints[_index].transform.position,
                    speed * Time.deltaTime);    
        }
    }
}
