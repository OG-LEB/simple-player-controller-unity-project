using UnityEngine;
public interface IPlayerInput 
{
    float GetHorizontal();
    float GetVertical();
    bool isJumping();
    bool isShooting();
}
