using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    [SerializeField]
    private Camera _followCamera;

    [SerializeField]
    private float _lowerLimit = 5f;

    [SerializeField]
    private float _upperLimit = 300f;

    [SerializeField]
    private float _flightLimit = 65f;

    void Update()
    {      
        movement();
    }

    void movement(){
        directionMovement();
        if(isInWorld(transform.position)) {

            upDownMovement();}
        else if(transform.position.y <= _lowerLimit){
           if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * _playerSpeed * Time.deltaTime;
            }
       }
        else if(transform.position.y >= _upperLimit){
           if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * _playerSpeed * Time.deltaTime;
            }
       }       

    } 

    void directionMovement(){
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movementInput = Quaternion.Euler(0,_followCamera.transform.eulerAngles.y ,0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        transform.Translate(movementDirection * _playerSpeed * Time.deltaTime);
    }

    void upDownMovement(){
        float verticalInput = Input.GetAxis("Vertical1");

        Vector3 movementInput = Quaternion.Euler(0,_followCamera.transform.eulerAngles.y ,0) * new Vector3(0, verticalInput, 0);
        Vector3 movementDirection = movementInput.normalized;

        transform.Translate(movementDirection * _playerSpeed * Time.deltaTime);
    }    
    bool isInWorld(Vector3 pos){
        return _lowerLimit < pos.y && pos.y < _upperLimit;
    }

}
