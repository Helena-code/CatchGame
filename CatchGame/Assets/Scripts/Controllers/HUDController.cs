using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private GameObject _endGameWindow;

    private IVisualizer _startWindowI;
    private IVisualizer _endGameWindowI;

    private void Awake()          
    {
        _scoreText.text = "";
        _healthText.text = "";
        _startWindowI = _startWindow.GetComponent<IVisualizer>();
        _endGameWindowI = _endGameWindow.GetComponent<IVisualizer>();
        HideAllWindows();
    }

    public void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void UpdateHealthText(int value)
    {
        _healthText.text = value.ToString();
    }

    public void BeginGame()
    {
        _startWindowI.Show();
    }

    public void HideAllWindows()
    {
        _startWindowI.Hide();
        _endGameWindowI.Hide();
    }

    public void ShowEndGame()
    {
        _endGameWindow.GetComponent<EndWindow>().UpdateScoreText(_scoreText.text);
        _endGameWindowI.Show();
    }
}
