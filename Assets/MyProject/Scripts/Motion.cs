using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private Camera _camera;

    private void Start() => _camera = Camera.main;

    public void ProcessMoving(bool isMoving, Vector3 motion)
    {
        if (isMoving)
        {
            Move(motion);
        }
        else
        {
            SetAnimationSpeed(0);
        }
    }

    private void Move(Vector3 motion)
    {
        var direction = _camera.transform.TransformDirection(motion);
        direction.y = 0;
        direction.Normalize();

        transform.forward = direction;

        _controller.Move(direction * Time.deltaTime * _speed);
        SetAnimationSpeed(_controller.velocity.magnitude);
    }

    private void SetAnimationSpeed(float speed) => _animator.SetFloat("Speed", speed);
}
