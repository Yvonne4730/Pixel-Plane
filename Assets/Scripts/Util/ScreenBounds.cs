//获取屏幕边界信息
using UnityEngine;

public static class ScreenBounds
{
    private static Camera _mainCam;

    private static Camera MainCam
    {
        get
        {
            if (_mainCam == null)
                _mainCam = Camera.main;
            return _mainCam;
        }
    }

    public static float Top => MainCam.orthographicSize;
    public static float Bottom => -MainCam.orthographicSize;
    public static float Right => MainCam.orthographicSize * MainCam.aspect;
    public static float Left => -MainCam.orthographicSize * MainCam.aspect;

    public static Vector2 GetRandomSpawnPositionX(float yOffset = 0f)
    {
        return new Vector2(Random.Range(Left, Right), Top + yOffset);
    }

    public static bool IsOutOfScreen(Vector3 position, float margin = 1f)
    {
        return position.y < Bottom - margin ||
               position.y > Top + margin ||
               position.x < Left - margin ||
               position.x > Right + margin;
    }
}