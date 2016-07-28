using UnityEngine;
using System.Timers;

namespace Assets.scripts.Orchestra
{
    public class Orchestration : MonoBehaviour
    {
        private const int INTERVAL = 429;

        private Timer _timer;
        private TrackEvents _track;

        void Start()
        {
            _timer = new Timer();
            _timer.Interval = INTERVAL;
            _timer.Elapsed += BeatsAndMeasures;
            _timer.Enabled = true;

            _track = new TrackEvents();
        }

        void Update()
        {
        }

        private void BeatsAndMeasures(object sender, ElapsedEventArgs e)
        {
            _track.FireBeatEvent();
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
