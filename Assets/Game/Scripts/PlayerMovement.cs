using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _leftJoystick;
    [SerializeField] private Joystick _rightJoystick;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _fuelConsumptionRate;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerResources _playerResources;

    private bool _isMoving;

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector2 input = _leftJoystick.Direction;
        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            if (!_isMoving) StartFuelConsumption();
            _rb.linearVelocity += new Vector3(moveDirection.x, 0, moveDirection.z) * _moveSpeed;
        }
        else
        {
            StopFuelConsumption();
        }

        float verticalInput = _rightJoystick.Direction.y;
        if (Mathf.Abs(verticalInput) > 0.01f)
        {
            if (!_isMoving) StartFuelConsumption();
            _rb.linearVelocity += Vector3.up * (verticalInput * _verticalSpeed);
        }
        else if (moveDirection.sqrMagnitude <= 0.01f)
        {
            StopFuelConsumption();
        }
    }

    private void HandleRotation()
    {
        float rotationInput = _rightJoystick.Direction.x;
        _rb.AddTorque(Vector3.up * (rotationInput * _rotationSpeed), ForceMode.Acceleration);
    }

    private void StartFuelConsumption()
    {
        _isMoving = true;
        _playerResources.SetFuelConsumption(_isMoving);
    }

    private void StopFuelConsumption()
    {
        _isMoving = false;
        _playerResources.SetFuelConsumption(_isMoving);
    }
}
