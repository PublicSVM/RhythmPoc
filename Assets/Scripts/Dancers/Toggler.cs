using Assets.Scripts.Events;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Dancers
{
    class Toggler : MonoBehaviour
    {
        public Conductor Conductor;
        public AudioClip AudioClip;
        public int ActiveBeat;

        private AudioSource _audioSource;
        private Collider _collider;
        private Renderer _renderer;

        private bool Enabled
        {
            get { return _renderer.enabled; }
            set
            {
                _collider.enabled = value;
                _renderer.enabled = value;
            }
        }


        void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.spatialBlend = 0.75f;

            _collider = GetComponent<Collider>();
            _renderer = GetComponent<Renderer>();

            Conductor.Subscribe(Toggle);
        }

        private void Toggle(int beat, int measure)
        {
            if (beat == ActiveBeat)
            {
                Enabled = !Enabled;
                _audioSource.PlaySafe(AudioClip);
            }
        }
    }
}
