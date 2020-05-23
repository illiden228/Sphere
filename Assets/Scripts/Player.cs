using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded = true;
    private int _money = 0;

    public int Money => _money;

    public event UnityAction Dying;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Obstacle>() != null)
        {
            Dying?.Invoke();
            _rigidbody.gravityScale = 0;
            _rigidbody.velocity = new Vector2(0, 0);
            enabled = false;
        }
        if (collision.TryGetComponent(out Money money))
        {
            _money += money.Amount;
            MoneyChanged?.Invoke(_money);
        }
    }
}
