using UnityEngine;
using System.Timers;

namespace Assets.Scripts.Orchestra
{
    public class Orchestration : MonoBehaviour
    {
        private Timer _timer;
        private TrackEvents _track;

        private int _cooldown;

        public Orchestration()
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

        public void SubscribeToElapsed(BeatEventHandler Method)
        {
            _track.BeatEvent += Method;
        }
        public void UnsubscribeToElapsed(BeatEventHandler Method)
        {
            _track.BeatEvent -= Method;
        }
    }
}
