// 文件路径: Assets/Scripts/Core/GameManager.cs
// M0 阶段：最小引导器，只负责在开局激活主角的操控与射击。
// M3 阶段将扩展为完整的游戏状态机（Start / Playing / Pause / GameOver）。

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("主角引用（留空则自动查找场景中的组件）")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerShooting playerShooting;

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
        if (playerController == null)
            playerController = FindObjectOfType<PlayerController>();
        if (playerShooting == null)
            playerShooting = FindObjectOfType<PlayerShooting>();

        StartGame();
    }

    // 进入游戏进行态：激活主角操控与射击
    private void StartGame()
    {
        if (playerController != null)
            playerController.EnableControl();
        if (playerShooting != null)
            playerShooting.EnableShooting();
    }
}
