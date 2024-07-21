using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    #region SingleTone
    private static BulletPool instance;
    public static BulletPool GetInstance() { return instance; }
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int PoolSize;
    public GameObject BulletPrefab;
    private Queue<GameObject> pool = new Queue<GameObject>();
    public float BulletLifeTime;
    public float moveSpeed;

    private void Start()
    {
        LoadPool();
    }
    private void LoadPool() 
    {
        pool = new Queue<GameObject>(PoolSize);

        for (int i = 0; i < PoolSize; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity, transform);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }
    public GameObject GetBullet() 
    {
        if (pool.Count > 0)
        {
            GameObject bullet = pool.Dequeue();
            bullet.GetComponent<Bullet>().LoadData(BulletLifeTime, moveSpeed);
            return bullet;
        }
        else
        {
            Debug.LogError("Bullet pool is empty");
            return null;
        }
    }
    public void AddToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        pool.Enqueue(bullet);
    }
}
