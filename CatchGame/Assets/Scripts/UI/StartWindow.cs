using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour, IVisualizer
{
    [SerializeField] private Button _startButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(GameController.Instance.StartGame);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

}
