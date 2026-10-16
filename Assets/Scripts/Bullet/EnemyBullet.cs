// 文件路径: Assets/Scripts/Bullet/EnemyBullet.cs
using UnityEngine;

public class EnemyBullet : BulletBase
{
    private void Awake()
    {
        direction = Vector3.down;
    }
}