using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCplayerMovement : MonoBehaviour
{
    public float _speed = 10f ;
    Transform _player;
    CharacterController _character;
    
    float _gravity = -9.81f;
    Vector3 Velocity;

    Transform _groundCheck;
    float _groundDistance = 0.2f;
    LayerMask _groundMask;
    bool _isGrounded;


    void Start()
    {
        //Gets Transform Component form the game object on which the script is placed
        _player = this.transform;
        // Checks if Player transform is null
        if(_player == null)
        {
            Debug.LogError("player is null");
        }
        // Gets charactercontroller component from transform
        _character = _player.GetComponent<CharacterController>();
        // Checks if Character controller is null 
        if (_character == null)
        {
            Debug.LogError("character is null");
        }
        // Gets Ground Check transform
        _groundCheck = this.transform.GetChild(2).transform;
        // Checks if _groundCheck is null
        if(_groundCheck == null)
        {
            Debug.LogError("Ground Check is null");
        }
        _groundMask = LayerMask.GetMask("Ground");
        


    }

    // Updates independent of frame rate or on a set frame rate 
    void FixedUpdate()
    {
        // Checks if player is grounded or not
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        // checks if player is grounded to set velocity 
        if(_isGrounded && Velocity.y < 0f)
        {
            Velocity.y = -0.5f;
        }
        // Gets input from (WASD) from -1 to 1
        float Xaxis = Input.GetAxis("Horizontal");
        float Zaxis = Input.GetAxis("Vertical");


        // Creating a Vector3 move with values of float xAxis and float zAxis 
        Vector3 move = _player.right * Xaxis + _player.forward * Zaxis;

        // using Move to change position of player 
        _character.Move(move * _speed * Time.deltaTime);
        
        // creating custom gravity 
        Velocity.y += _gravity * Time.deltaTime * Time.deltaTime;

        _character.Move(Velocity);
        

    }
}
