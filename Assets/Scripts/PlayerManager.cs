using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _movementSpeed = 5f;
    private Rigidbody2D _rb;

    private InputAction _moveInputAction;
    private bool _isGrounded = false;

    [SerializeField] private float _maxDistanceFromCameraBeforeDeath = 5f;
    public GameObject targetCanvas;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveInputAction = InputSystem.actions.FindAction("Move");

    }



    private void FixedUpdate()
    {
        if((transform.position.y + _maxDistanceFromCameraBeforeDeath) <= Camera.main.transform.position.y)
        {
            gameObject.SetActive(false);
            targetCanvas.gameObject.SetActive(true);
        }

        Vector2 moveInput = _moveInputAction.ReadValue<Vector2>();

        //movement for L&R
        _rb.linearVelocity = new Vector2(moveInput.x * _movementSpeed, _rb.linearVelocity.y);

        //Jump
        if(moveInput.y > 0.5f && _isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;

        }
    }

    void OnCollisonEnter2D(Collision2D other)
    {
        _isGrounded = true;

    }


    void OnCollisonExit2D(Collision2D other)
    {
        _isGrounded = false;

    }

}
