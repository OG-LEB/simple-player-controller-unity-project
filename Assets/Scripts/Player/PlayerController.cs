using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PCInput _pcInput;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerGFXRotation _playerGFXRotation;
    [SerializeField] private PlayerShoot _playerShoot;

    private void Update()
    {
        _playerMovement.UpdateMoveAxis(new Vector2(_pcInput.GetHorizontal(), _pcInput.GetVertical()));
        _playerGFXRotation.UpdateMoveVector(new Vector2(_pcInput.GetHorizontal(), _pcInput.GetVertical()));

        if (_pcInput.isJumping())
            _playerMovement.Jump();

        _playerShoot.UpdateIsShootingBool(_pcInput.isShooting());
    }
}
