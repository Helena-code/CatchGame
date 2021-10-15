using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndWindow : MonoBehaviour, IVisualizer
{
    [SerializeField] private Button _repeatButton;
    [SerializeField] private TextMeshProUGUI _totalScore;

    private void Awake()
    {
        _repeatButton.onClick.AddListener(GameController.Instance.StartGame);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {

        gameObject.SetActive(true);
    }

    public void UpdateScoreText(string score)
    {
        _totalScore.text = score;
    }
}
