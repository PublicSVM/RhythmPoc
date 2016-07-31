using UnityEngine;
using Assets.Scripts.Events;

public class Mover : MonoBehaviour
{
    private const float MAX_FADE = 75f;

    public Conductor Conductor;

    public GameObject From;
    public AudioClip FromSound;
    public int FromMeasure;

    public GameObject To;
    public AudioClip ToSound;
    public int ToMeasure;

    private AudioSource _audioSource;
    private float _fade;
    private Vector3 _start;
    private Vector3 _end;

    public Mover()
    {
        _fade = -1;
    }

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        transform.position = From.transform.position;

        Conductor.Subscribe(OnBeat);
    }

    void FixedUpdate()
    {
        if (_fade > -1)
        {
            float x = _start.x + (_end.x - _start.x) * ((MAX_FADE - _fade) / MAX_FADE);
            float y = _start.y + (_end.y - _start.y) * ((MAX_FADE - _fade) / MAX_FADE);
            float z = _start.z + (_end.z - _start.z) * ((MAX_FADE - _fade) / MAX_FADE);
            transform.position = new Vector3(x, y, z);
            _fade--;
        }
    }

    private void OnBeat(int beat, int measure)
    {
        if (measure % 8 == FromMeasure && beat == 0)
        {
            _start = From.transform.position;
            _end = To.transform.position;
            _audioSource.PlayOneShot(FromSound);
            _fade = MAX_FADE;
        }
        else if (measure % 8 == ToMeasure && beat == 0)
        {
            _start = To.transform.position;
            _end = From.transform.position;
            _audioSource.PlayOneShot(ToSound);
            _fade = MAX_FADE;
        }
    }
}
