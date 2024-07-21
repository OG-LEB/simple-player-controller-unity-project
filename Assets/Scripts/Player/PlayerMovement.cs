using UnityEngine;
using UnityEngine.VFX;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private float _MoveYAxis;
    public float GravitationValue = -9.81f;
    public float JumpForce;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Gravitation();
        Move();
    }
    public void Move() 
    {
        _characterController.Move(_moveVector * Time.deltaTime * MoveSpeed);
    }
    public void Jump() 
    {
        if (_characterController.isGrounded)
        {
            _MoveYAxis = JumpForce;
        }
    }
    private void Gravitation() 
    {
        if (!_characterController.isGrounded)
        {
            _MoveYAxis += GravitationValue * Time.deltaTime;
        }
        else
        {
            if (_MoveYAxis < -1f)
            {
                _MoveYAxis = -1f;
            }
        }
        _moveVector.y = _MoveYAxis;
    }
    public void UpdateMoveAxis(Vector2 axis) 
    {
        _moveVector.x = axis.x;
        _moveVector.z = axis.y;
    }
}
