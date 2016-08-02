using UnityEngine;
using Assets.Scripts.Events;
using Assets.Scripts.Extensions;

public class Mover : MonoBehaviour
{
    private const int MAX_TICK = 75;

    public Conductor Conductor;

    public GameObject Target;
    public AudioClip AudioMovingAway;
    public int MoveAwayOnMeasure;
    public AudioClip AudioMovingBack;
    public int MoveBackOnMeasure;

    private AudioSource _audioSource;
    private float _tick;
    private Vector3 _start;
    private Vector3 _end;
    private bool _isMovingAway;

    public Mover()
    {
        _tick = -1;
    }

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _start = transform.position;
        _end = Target.transform.position;

        Conductor.Subscribe(OnBeat);
    }

    void FixedUpdate()
    {
        if (_tick > -1)
        {
            float x;
            float y;
            float z;

            if (_isMovingAway)
            {
                x = _start.x + (_end.x - _start.x) * ((MAX_TICK - _tick) / MAX_TICK);
                y = _start.y + (_end.y - _start.y) * ((MAX_TICK - _tick) / MAX_TICK);
                z = _start.z + (_end.z - _start.z) * ((MAX_TICK - _tick) / MAX_TICK);
            }
            else
            {
                x = _end.x + (_start.x - _end.x) * ((MAX_TICK - _tick) / MAX_TICK);
                y = _end.y + (_start.y - _end.y) * ((MAX_TICK - _tick) / MAX_TICK);
                z = _end.z + (_start.z - _end.z) * ((MAX_TICK - _tick) / MAX_TICK);
            }

            transform.position = new Vector3(x, y, z);
            _tick--;
        }
    }

    private void OnBeat(int beat, int measure)
    {
        if (measure % 4 == MoveAwayOnMeasure && beat == 0)
        {
            _audioSource.PlaySafe(AudioMovingAway);
            _tick = MAX_TICK;
            _isMovingAway = true;
        }
        else if (measure % 4 == MoveBackOnMeasure && beat == 0)
        {
            _audioSource.PlaySafe(AudioMovingBack);
            _tick = MAX_TICK;
            _isMovingAway = false;
        }
    }
}
