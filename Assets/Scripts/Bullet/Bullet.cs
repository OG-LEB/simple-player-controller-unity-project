using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _lifeTime;
    private float _moveSpeed;
    private bool _isMoving;

    public void StartMovement() 
    {
        _isMoving = true;
        StartCoroutine(moveTimer());
    }
    public void StopMovement(bool deadByTime) 
    {
        if (deadByTime)
            Debug.Log($"Пуля исчесла после окончания таймера");
        else
            Debug.Log($"Пуля исчесла после столкновения с врагом");

        BulletPool.GetInstance().AddToPool(gameObject);
        _isMoving = false;
        StopAllCoroutines();
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed);
        }
    }
    private IEnumerator moveTimer() 
    {
        yield return new WaitForSeconds(_lifeTime);
        StopMovement(true);
    }
    public void LoadData(float LifeTime, float moveSpeed) 
    {
        _lifeTime = LifeTime;
        _moveSpeed = moveSpeed;
    }
}
