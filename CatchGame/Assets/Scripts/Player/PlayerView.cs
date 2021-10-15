using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove.ChangedDirection += FlipView;
    }

    private void FlipView(Vector2 dir)
    {
        if (dir == Vector2.right)
        {
            _spriteRenderer.flipX = true;
            return;
        }
        _spriteRenderer.flipX = false;
    }
}
