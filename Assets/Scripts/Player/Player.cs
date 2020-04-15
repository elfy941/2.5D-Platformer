using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
    void Start() {
        _characterController = GetComponent<CharacterController>();
    }
    
    void Update() {
        CalculateMovement();
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
}
