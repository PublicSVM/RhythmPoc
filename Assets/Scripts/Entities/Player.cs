using UnityEngine;

namespace Assets.Scripts.Entities
{
    class Player : MonoBehaviour
    {
        public float Force = 20;
        public float SpeedLimit = 10;

        public Vector3 Velocity
        {
            get { return _rigidbody.velocity; }
            private set { _rigidbody.velocity = value; }
        }

        private Vector3 _vertical;
        private Vector3 _horizontal;
        private Vector3 _stop;

        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _vertical = new Vector3(0, 0, Force);
            _horizontal = new Vector3(Force, 0, 0);
            _stop = new Vector3(0, 0, 0);
        }

        void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            var vertical = Input.GetAxis("Vertical");
            _rigidbody.AddForce(_vertical * vertical);

            var horizontal = Input.GetAxis("Horizontal");
            _rigidbody.AddForce(_horizontal * horizontal);

            if (Mathf.Abs(vertical) < 0.1 && Mathf.Abs(horizontal) < 0.1)
            {
                if (Velocity.magnitude > 0.2)
                    Velocity *= 0.8f;
                else
                    Velocity = _stop;
            }

            if (Velocity.magnitude > SpeedLimit)
            {
                Velocity = Velocity.normalized * SpeedLimit;
            }
        }
    }
}
