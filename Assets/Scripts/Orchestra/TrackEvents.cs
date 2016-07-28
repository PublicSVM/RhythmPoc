namespace Assets.scripts.Orchestra
{
    public delegate void BeatEventHandler(int beat, int measure);

    public class TrackEvents
    {
        public event BeatEventHandler BeatEvent;

        private int _beat = -1;
        private int _measure = 0;

        protected virtual void OnBeat(int beat, int measure)
        {
            if (BeatEvent != null)
            {
                BeatEvent.Invoke(beat, measure);
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
