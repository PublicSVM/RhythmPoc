namespace Assets.Scripts.Events
{
    public delegate void TrackEventHandler(int beat, int measure);

    public class TrackEvents
    {
        public event TrackEventHandler TrackEvent;

        private int _beat = -1;
        private int _measure = 0;

        protected virtual void OnBeat(int beat, int measure)
        {
            if (TrackEvent != null)
            {
                TrackEvent.Invoke(beat, measure);
            }
        }

        public void FireBeatEvent()
        {
            _beat++;
            if (_beat == 4)
            {
                _measure++;
                _beat = 0;
            }

            OnBeat(_beat, _measure);
        }
    }
}
