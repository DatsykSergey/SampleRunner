using UnityEditor;
using UnityEngine;

namespace Code.Player
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private int _currentIndex;
        [SerializeField] private Vector3[] _positions;

        private readonly PlayerInput _input = new PlayerInput();

        public void Initialize()
        {
            transform.position = _positions[_currentIndex];
        }
        
        private void Update() => 
            UpdateInput();

        private void FixedUpdate() => 
            UpdateMovement();

        private void UpdateInput()
        {
            int delta = _input.MoveDirection();
            
            if(delta != 0)
                _currentIndex = Mathf.Clamp(_currentIndex + delta, 0, _positions.Length - 1);
        }

        private void UpdateMovement()
        {
            Vector3 current = transform.position;
            if (IsShouldMove(current))
                transform.position = Vector3.MoveTowards(current, _positions[_currentIndex], _speed * Time.deltaTime);
        }

        private bool IsShouldMove(Vector3 current) => 
            current != _positions[_currentIndex];

        private void OnDrawGizmos()
        {
            if (_positions.Length == 0)
                return;

            Gizmos.color = Color.blue;

            for (int i = 0; i < _positions.Length; i++)
            {
                Vector3 position = _positions[i];
                Gizmos.DrawSphere(position, 0.2f);
                Handles.Label(position + Vector3.up / 2f, $"{i}-th");
            }
        }
    }
}