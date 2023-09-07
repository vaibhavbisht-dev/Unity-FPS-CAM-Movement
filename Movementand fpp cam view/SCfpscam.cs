using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCfpscam : MonoBehaviour
{
    public float _senstivity = 100;

    Transform _cam,_playerBody;
    float xRotation = 0f;
    void Start()
    {
        // Gets Camera's tranform
        _cam = this.transform;
        // Check if camera is null or not
        if(_cam == null)
        {
            Debug.LogError("cam is null");
        }
        _playerBody = this.transform.parent.transform;
        if(_playerBody == null)
        {
            Debug.LogError("Player is null");
        }

        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Updates independent of frame rate or on a set frame rate 
    void FixedUpdate()
    {
        float MouseX = Input.GetAxis("Mouse X") * _senstivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * _senstivity * Time.deltaTime;

        _playerBody.Rotate(Vector3.up * MouseX);

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


    }
}
