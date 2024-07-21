using UnityEngine;

public class PCInput : MonoBehaviour, IPlayerInput
{
    public float GetHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetVertical()
    {
        return Input.GetAxis("Vertical");
    }

    public bool isJumping()
    {
        return Input.GetKey(KeyCode.Space);
    }

    public bool isShooting()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }
}
