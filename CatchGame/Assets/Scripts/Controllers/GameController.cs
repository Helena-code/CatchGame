using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private HUDController _hudController;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private SpawnerLogic _spawner;

    private GameData _gameData;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Another instance of GameController already exists!");
        }
        Instance = this;

        Time.timeScale = 0;
        
        _gameData = new GameData();
        _gameData.Init();
        SetBorders();
        _hudController.BeginGame();
        _gameData.EndGame += EndGame;
    }

    public void ChangeScore(int points, bool adding)           
    {
        _gameData.ChangeScore(points,adding);
        _hudController.UpdateScoreText(_gameData.Score);
    }

    public void ChangeHealth(bool adding)
    {
        _gameData.ChangeHealth(adding);
        _hudController.UpdateHealthText(_gameData.Health);
    }

    public void StartGame()
    {
        _spawner.ClearFallingItems();
        ClearData();
        _hudController.HideAllWindows();
        Time.timeScale = 1;
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        _hudController.ShowEndGame();
    }

    public void ClearData()
    {
        _gameData.ClearScore();
        _gameData.SetStartHealth();
        _hudController.UpdateHealthText(_gameData.Health);
        _hudController.UpdateScoreText(_gameData.Score);
    }
    private void SetBorders()
    {
        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        _leftBorder.position = new Vector2(leftBot.x, leftBot.y) ;
        _rightBorder.position = new Vector2(rightTop.x, leftBot.y);
    }
}
