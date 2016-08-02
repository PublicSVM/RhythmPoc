using UnityEngine;

namespace Assets.Scripts.Player
{
    class FollowLight : MonoBehaviour
    {
        private const float SHADOW_LENGTH = 1.5f;

        public Player Player;

        private Transform _transform;

        void Start()
        {
            _transform = GetComponent<Transform>();
        }

        void Update()
        {
            var x = 90 + Player.Velocity.magnitude * SHADOW_LENGTH;
            var y = Vector3.Angle(Vector3.forward, Player.Velocity);
            if (Player.Velocity.x < 0) y = -y;
            _transform.localRotation = Quaternion.Euler(x, y, 0);
        }
    }
}
