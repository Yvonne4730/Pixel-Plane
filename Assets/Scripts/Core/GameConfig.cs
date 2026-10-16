//存储游戏配置信息

using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Config")]
public class GameConfig : ScriptableObject
{
    [Header("主角设定")]
    public int playerInitLife = 3;
    public int playerMaxLife = 5;
    public float playerMoveSpeed = 10f;
    public float playerShootInterval = 0.25f;
    public float playerInvincibleDuration = 1.5f;

    [Header("子弹设定")]
    public float playerBulletSpeed = 15f;
    public float enemyBulletSpeed = 8f;

    [Header("敌人设定")]
    public float enemySpawnIntervalStart = 2f;
    public float enemySpawnIntervalMin = 0.8f;

    [Header("道具设定")]
    public float propSpawnInterval = 10f;
    public float shieldDuration = 3f;
    public float propFallSpeed = 3f;

    [Header("计分")]
    public int tankScore = 200;
    public int fighterScore = 100;

    private static GameConfig _instance;
    public static GameConfig Instance
    {
        get
        {
            if (_instance == null)
                _instance = Resources.Load<GameConfig>("GameConfig");
            return _instance;
        }
    }
}