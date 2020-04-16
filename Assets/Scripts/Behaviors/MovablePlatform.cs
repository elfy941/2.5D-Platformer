using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class MovablePlatform : MonoBehaviour {
    [SerializeField] private GameObject[] intermediaryPoints;

    [SerializeField] private float speed = 3;

    private int _index;
    private float _maxDistanceBetweenVectors = 1f;
    
    void FixedUpdate()
    { 
        if (Vector3.Distance(
            transform.position,
            intermediaryPoints[_index].transform.position) < _maxDistanceBetweenVectors) {
            _index++;
            if (_index == intermediaryPoints.Length) {
                _index = 0;
            }   
        } else {
            transform.position =
                Vector3.MoveTowards(
                    transform.position,
                    intermediaryPoints[_index].transform.position,
                    speed * Time.deltaTime);    
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag(Constants.PlayerTag)) {
            other.transform.parent = transform;    
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.CompareTag(Constants.PlayerTag)) {
            other.transform.parent = null;   
        }
    }

}

