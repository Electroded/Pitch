using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    [SerializeField] private bool _joystickInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Joystick _joystick;

    private Rigidbody2D _rb;
    private float _horizontalInput;
    private float _verticalInput;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_joystickInput)
        {
            JoystickInput();
        }
        else 
        { 
            KeyboardtInput();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_horizontalInput * _moveSpeed, _verticalInput * _moveSpeed);
    }

    private void KeyboardtInput()
    {
        _horizontalInput = Input.GetAxis(HorizontalInput);

        _verticalInput = Input.GetAxis(VerticalInput);
    }

    private void JoystickInput()
    {
        _horizontalInput = _joystick.Direction.x;

        _verticalInput = _joystick.Direction.y;

        /*if (_joystick.Direction.x != 0)
        {
            _rb.velocity = new Vector2(_joystick.Direction.x * _moveSpeed, _joystick.Direction.y * _moveSpeed);
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }*/
    }
}
