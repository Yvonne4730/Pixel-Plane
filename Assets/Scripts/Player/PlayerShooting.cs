// 文件路径: Assets/Scripts/Player/PlayerShooting.cs
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float _shootTimer;
    private bool _canShoot;
    private float _shootInterval;

    [SerializeField] private Transform firePoint;

    private void Start()
    {
        _shootInterval = GameConfig.Instance.playerShootInterval;
    }

    public void EnableShooting()
    {
        _canShoot = true;
        _shootTimer = 0f;
    }

    public void DisableShooting()
    {
        _canShoot = false;
    }

    private void Update()
    {
        if (!_canShoot) return;

        _shootTimer += Time.deltaTime;
        if (_shootTimer >= _shootInterval)
        {
            _shootTimer = 0f;
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position + Vector3.up * 0.5f;
        BulletPoolManager.Instance.GetPlayerBullet(spawnPos, Vector3.up, GameConfig.Instance.playerBulletSpeed);
    }
}