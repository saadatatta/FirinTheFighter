using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    private Transform _player;
    private bool _ispressed;
    private Animator _animator;
    private bool _isRunning;

    void Start()
    {
        _player = GameManager.Instance.Player;
        _animator = _player.GetComponent<Animator>();
    }

    void Update()
    {
        if (!_ispressed)
            return;
        
        // DO SOMETHING HERE
        Debug.Log("Pressed");
        Translate();
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        _ispressed = true;
        _isRunning = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _ispressed = false;
        _isRunning = false;
        _animator.SetBool("IsRunning", _isRunning);
    }

    private void Translate()
    {
        ChangePlayerFaceDirection();
        _animator.SetBool("IsRunning", _isRunning);
        _player.position += _direction*_speed*Time.deltaTime;
    }

    private void ChangePlayerFaceDirection()
    {
        if (_direction == -Vector3.right)
        {
            _player.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            _player.localScale = new Vector3(1, 1, 1);
        }
    }
}