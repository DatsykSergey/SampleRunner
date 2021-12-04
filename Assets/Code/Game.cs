using Code.Platform;
using Code.Player;
using UnityEngine;

namespace Code
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Platforms platforms;
        [SerializeField] private PlatformMover _platformMover;
        [SerializeField] private Character _character;
    
        private void Awake()
        {
            _platformMover.Initialize(platforms.Create(), platforms.PlatformLenght);
            _character.Initialize();
        }
    }
}
