//控制玩家角色的移动
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _offset;
    private bool _canMove;

    public void EnableControl()
    {
        _canMove = true;
    }

    public void DisableControl()
    {
        _canMove = false;
    }

    private void Update()
    {
        if (!_canMove) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0f;
            _offset = transform.position - touchPos;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0f;
            targetPos += _offset;
            transform.position = ClampPosition(targetPos);
        }
    }

    private Vector3 ClampPosition(Vector3 pos)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return pos;

        Bounds bounds = sr.bounds;
        float halfW = bounds.extents.x;
        float halfH = bounds.extents.y;

        pos.x = Mathf.Clamp(pos.x, ScreenBounds.Left + halfW, ScreenBounds.Right - halfW);
        pos.y = Mathf.Clamp(pos.y, ScreenBounds.Bottom + halfH, ScreenBounds.Top - halfH);
        pos.z = 0f;
        return pos;
    }
}