using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private UIMoney _moneyUIText;
    private Rigidbody2D _rigidbody;
    private bool _isGround = true;
    private int _moneys = 0;

    public event UnityAction OnDie;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _moneyUIText = GetComponent<UIMoney>();
        _moneyUIText.TakeMoney(_moneys);
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
        Money money;
        if(collision.GetComponent<Obstacle>() != null)
        {
            OnDie?.Invoke();
            enabled = false;
        }
        if (collision.TryGetComponent<Money>(out money))
        {
            _moneys += money.Value;
            _moneyUIText.TakeMoney(_moneys);
        }
        
    }

}
