using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private Vector3 _input;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (_input.sqrMagnitude > 0.05f)
        {
            var direction = _camera.transform.TransformDirection(_input);
            direction.y = 0;
            direction.Normalize();
             
            transform.forward = direction;

            _controller.Move(direction * Time.deltaTime * _speed);
            _animator.SetFloat("Speed", _controller.velocity.magnitude);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }
}
