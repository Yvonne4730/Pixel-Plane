
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    protected Vector3 direction;

    public void Initialize(Vector3 dir, float spd)
    {
        direction = dir.normalized;
        speed = spd;
    }

    protected virtual void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (ScreenBounds.IsOutOfScreen(transform.position))
        {
            OnOutOfScreen();
        }
    }

    protected virtual void OnOutOfScreen()
    {
        BulletPoolManager.Instance.RecycleBullet(this);
    }
}