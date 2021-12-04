using System.Collections.Generic;
using UnityEngine;

namespace Code.Platform
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private Vector3 _target = Vector3.zero;

        private List<Transform> _platforms;
        private Vector3 _direction;

        private float _platformLength;

        private int _firstIndex;
        private int _lastIndex;

        private int Count => _platforms.Count;
        

        public void Initialize(List<Transform> platforms, float platformLength)
        {
            _platforms = platforms;
            _platformLength = platformLength;
            
            _direction = (_target - _platforms[0].position).normalized;
            _firstIndex = 0;
            _lastIndex = Count - 1;
        }

        private void Update()
        {
            Movement();
            MoveAtEnd();
        }

        private void Movement()
        {
            foreach (Transform platform in _platforms)
            {
                platform.position = Vector3.MoveTowards(platform.position, _target, _speed * Time.deltaTime);
            }
        }

        private void MoveAtEnd()
        {
            if (_platforms[_firstIndex].position == _target)
            {
                _platforms[_firstIndex].position = _platforms[_lastIndex].position - _direction * _platformLength;
                
                _firstIndex = (_firstIndex + 1) % Count;
                _lastIndex = (_lastIndex + 1) % Count;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_target, 0.25f);
        }
    }
}