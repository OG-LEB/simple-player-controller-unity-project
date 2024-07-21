using Unity.VisualScripting;
using UnityEngine;

public class PlayerGFXRotation : MonoBehaviour
{
    private Vector2 _moveVector;
    [SerializeField] private Transform _GFXObject;
    public float SmoothRotationTime = 0.1f;
    private float _turnSmoothVelocity;
    private void Update()
    {
        float targetAngle = Mathf.Atan2(_moveVector.x, _moveVector.y) * Mathf.Rad2Deg;
        float smoothAngle = Mathf.SmoothDampAngle(_GFXObject.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, SmoothRotationTime);
        _GFXObject.rotation = Quaternion.Euler(0, smoothAngle, 0);
    }
    public void UpdateMoveVector(Vector2 axis)
    {
        if (axis.magnitude > 0.25f)
            _moveVector = axis;
    }
}
