using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 3.0f;

    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 5.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.2f;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    void Update()
    {
        getNewMousePosition();
        Vector3 nextRotation = applyDampingForXRotation();
        applyDampingBetwennRotationChanges(nextRotation);
        
        // Substract forward vector of the GameObject to point its forward vector to the target 
        transform.position = _target.position - transform.forward * _distanceFromTarget;

    }

    void getNewMousePosition()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationX += mouseY;
        _rotationY += mouseX;
    }

    Vector3 applyDampingForXRotation()
    {
        _rotationX = Mathf.Clamp(_rotationX, -40, 40);
        Vector3 nextRotation = new Vector3(_rotationX, _rotationY, 0);

        return nextRotation;
    }

    void applyDampingBetwennRotationChanges(Vector3 nextRotation)
    {
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;
    }
}
