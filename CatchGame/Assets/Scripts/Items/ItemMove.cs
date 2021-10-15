using UnityEngine;
using Scripts.GameBalance;
using System.Linq;

public class ItemMove : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private float _baseSpeed;
    private float _coeffSpeed;

    private void Awake()
    {
        _baseSpeed = GameBalance.Instance.BaseItemSpeed;
        SetItemSpeed();
    }
    private void Update()
    {
        _transform.Translate(Vector2.down * Time.deltaTime * _baseSpeed * _coeffSpeed);
    }

    public void SetItemSpeed()
    {
        var type = GetComponent<IInteractible>().GetItemType();
        var typeParams = GameBalance.Instance.ItemSettings.FirstOrDefault(t => t.ItemType == type);
        _coeffSpeed = typeParams.Speed;
    }
}
