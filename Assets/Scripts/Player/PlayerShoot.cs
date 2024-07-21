using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private BulletPool _bulletPool;
    private bool _shootingButton;
    private bool _isShooting;
    public float ShootDelayTime;
    [SerializeField] private Transform BulletSpawnPoint;
    private void Start()
    {
        _bulletPool = BulletPool.GetInstance();
    }
    private void Update()
    {
        if (_shootingButton && !_isShooting)
        {
            _isShooting = true;
            StartCoroutine(Shooting());
        }
        if (!_shootingButton && _isShooting)
        {
            _isShooting = false;
            StopAllCoroutines();
        }
    }
    private void Shoot()
    {
        GameObject bullet = _bulletPool.GetBullet();
        if (bullet == null)
            return;

        bullet.transform.position = BulletSpawnPoint.position;
        bullet.transform.rotation = BulletSpawnPoint.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().StartMovement();
    }
    IEnumerator Shooting()
    {
        while (_isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(ShootDelayTime);
        }
    }
    public void UpdateIsShootingBool(bool value)
    {
        _shootingButton = value;
    }
}
