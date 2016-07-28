using UnityEngine;
using System.Timers;

namespace Assets.Scripts.Events
{
    public class Conductor : MonoBehaviour
    {
        private Timer _timer;
        private TrackEvents _track;
        private int _cooldown;

        public Conductor()
        {
            _track = new TrackEvents();
            _cooldown = 0;
        }

        void FixedUpdate()
        {
            if (_cooldown == 0)
            {
                _track.FireBeatEvent();
                _cooldown = 20;
            }
            else
            {
                _cooldown--;
            }
        }

        public void Subscribe(TrackEventHandler Method)
        {
            _track.TrackEvent += Method;
        }
        public void Unsubscribe(TrackEventHandler Method)
        {
            _track.TrackEvent -= Method;
        }
    }
}
