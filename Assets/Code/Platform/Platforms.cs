using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Platform
{
    public class Platforms : MonoBehaviour
    {
        [SerializeField] private GameObject[] _instances;
        [SerializeField] private int _count = 1;
        [SerializeField] private float _platformLenght = 1;

        public float PlatformLenght => _platformLenght;

        public List<Transform> Create()
        {
            if (_count <= 0)
                throw new Exception($"Invalid field in {gameObject.name} count is less or equal zero");
            
            List<Transform> _platrofms = new List<Transform>(_count);
            
            for (int i = 0; i < _count; i++)
            {
                GameObject platform = Instantiate(
                    original: NextInstance(i),
                    position: NextPosition(i),
                    rotation: quaternion.identity,
                    parent: transform);
                
                _platrofms.Add(platform.transform);
            }

            return _platrofms;
        }

        private GameObject NextInstance(int i) => 
            _instances[i % _instances.Length];

        private Vector3 NextPosition(int i) => 
            transform.position + transform.forward * i * PlatformLenght;
    }
}
