using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _leftJoystick;
    [SerializeField] private Joystick _rightJoystick;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        /*Vector2 input = _leftJoystick.Direction;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y) * _moveSpeed;
        _rb.linearVelocity += new Vector3(moveDirection.x, 0, moveDirection.z);*/

        Vector2 input = _leftJoystick.Direction;
        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;
        _rb.linearVelocity += new Vector3(moveDirection.x, 0, moveDirection.z) * _moveSpeed;

        float verticalInput = _rightJoystick.Direction.y;
        _rb.linearVelocity += Vector3.up * (verticalInput * _verticalSpeed);
    }

    private void HandleRotation()
    {
        float rotationInput = _rightJoystick.Direction.x;
        transform.Rotate(Vector3.up * (rotationInput * _rotationSpeed * Time.deltaTime));
    }
}
