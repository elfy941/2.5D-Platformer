using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _characterController;
    
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float gravity = 1f;
    [SerializeField]
    private float jumpHeight = 25.0f;

    private float _yVelocity;

    private bool _canDoubleJump;

    private HealthSystem _healthSystem;
    void Start() {
        _characterController = GetComponent<CharacterController>();
    }
    
    void Update() {
        CalculateMovement();
        if (_characterController.transform.position.y < -30) {
            _healthSystem.Kill();
        }
    }

    public void SetHealthSystem(HealthSystem healthSystem) {
        _healthSystem = healthSystem;
    }
    private void CalculateMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * speed;

        if (_characterController.isGrounded) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _yVelocity = jumpHeight;
                _canDoubleJump = true;
            }
        } else {
            if (AbleToDoubleJump()) {
                _yVelocity += jumpHeight;
                _canDoubleJump = false;
            }
            _yVelocity -= gravity;
        }
        
        velocity.y = _yVelocity;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private bool AbleToDoubleJump() {
        return Input.GetKeyDown(KeyCode.Space) && _canDoubleJump;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision");
        var collectible = other.GetComponent<ICollectible>();
        collectible?.Collect();
    }
}
