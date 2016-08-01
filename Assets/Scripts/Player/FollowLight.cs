using UnityEngine;

namespace Assets.Scripts.Player
{
    class FollowLight : MonoBehaviour
    {
        public Player Player;

        private Transform _transform;

        void Start()
        {
            _transform = GetComponent<Transform>();
        }

        void Update()
        {
            var x = 90 + Player.Velocity.magnitude * 3;
            var y = Vector3.Angle(Vector3.forward, Player.Velocity);
            if (Player.Velocity.x < 0) y = -y;
            _transform.localRotation = Quaternion.Euler(x, y, 0);
        }
    }
}
