// 文件路径: Assets/Scripts/Bullet/PlayerBullet.cs
using UnityEngine;

public class PlayerBullet : BulletBase
{
    private void Awake()
    {
        direction = Vector3.up;
    }
}