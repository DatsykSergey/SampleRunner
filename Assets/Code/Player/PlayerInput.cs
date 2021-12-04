using UnityEngine;

namespace Code.Player
{
    public class PlayerInput
    {
        public int MoveDirection()
        {
            int direction = 0;
            if (Input.GetKeyDown(KeyCode.A))
                direction -= 1;
            if (Input.GetKeyDown(KeyCode.D))
                direction += 1;

            return direction;
        }
    }
}