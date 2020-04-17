using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;
    private bool _isGround = true;
    private int _moneys = 0;

    public event UnityAction Dying;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _isGround = false;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGround = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Obstacle>() != null)
        {
            Dying?.Invoke();
            enabled = false;
        }
        if (collision.TryGetComponent<Money>(out Money money))
        {
            _moneys += money.Value;
            MoneyChanged?.Invoke(_moneys);
        }
        
    }

}
