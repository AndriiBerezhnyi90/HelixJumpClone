using UnityEngine;

public class AxisRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private UserInput _userInput;
    private Vector2 _rotate;
    private Vector2 _rotation;

    private void Awake()
    {
        _userInput = new UserInput();
    }

    private void OnEnable()
    {
        _userInput.Enable();
    }

    private void OnDisable()
    {
        _userInput.Disable();
    }

    private void Update()
    {
        _rotate = _userInput.Axis.Rotation.ReadValue<Vector2>();

        Rotate(_rotate);
    }

    private void Rotate(Vector2 rotate)
    {
        float scaledSpeed = _rotateSpeed * Time.deltaTime;
        _rotation.y -= rotate.x * scaledSpeed;

        transform.localEulerAngles = _rotation;
    }
}