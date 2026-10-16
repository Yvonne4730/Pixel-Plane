
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance { get; private set; }

    [Header("Prefabs")]
    [SerializeField] private PlayerBullet playerBulletPrefab;
    [SerializeField] private EnemyBullet enemyBulletPrefab;

    private ObjectPool<PlayerBullet> _playerBulletPool;
    private ObjectPool<EnemyBullet> _enemyBulletPool;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        Transform bulletRoot = new GameObject("BulletContainer").transform;
        bulletRoot.SetParent(transform);

        _playerBulletPool = new ObjectPool<PlayerBullet>(playerBulletPrefab, bulletRoot, 20);
        _enemyBulletPool = new ObjectPool<EnemyBullet>(enemyBulletPrefab, bulletRoot, 30);
    }

    public PlayerBullet GetPlayerBullet(Vector3 position, Vector3 direction, float speed)
    {
        PlayerBullet bullet = _playerBulletPool.Get();
        bullet.transform.position = position;
        bullet.Initialize(direction, speed);
        return bullet;
    }

    public EnemyBullet GetEnemyBullet(Vector3 position, Vector3 direction, float speed)
    {
        EnemyBullet bullet = _enemyBulletPool.Get();
        bullet.transform.position = position;
        bullet.Initialize(direction, speed);
        return bullet;
    }

    public void RecycleBullet(BulletBase bullet)
    {
        if (bullet is PlayerBullet pb)
            _playerBulletPool.Release(pb);
        else if (bullet is EnemyBullet eb)
            _enemyBulletPool.Release(eb);
    }
}