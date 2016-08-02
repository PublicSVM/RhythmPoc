using Assets.Scripts.Events;
using Assets.Scripts.Extensions;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Conductor Conductor;
    public AudioClip AudioClip;
    public int ActiveBeat;

    private AudioSource _audioSource;
    private Renderer _renderer;
    private float _fade;


    public Rotator()
    {
        _fade = 0;
    }

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.spatialBlend = 0.75f;

        _renderer = GetComponent<Renderer>();

        Conductor.Subscribe(OnBeat);
    }

    void FixedUpdate()
    {
        if (_fade > 0)
        {
            _fade--;
            Rotate();

            if (_fade == 0)
            {
                _renderer.material.color = Color.yellow;
            }
        }
    }

    internal void OnBeat(int beat, int measure)
    {
        if (beat == ActiveBeat)
        {
            _audioSource.PlaySafe(AudioClip);
            _renderer.material.color = Color.green;
            _fade = 15f;
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.localRotation = new Quaternion(
            15f - 2f * _fade,
            30f - 2f * _fade,
            45f - 2f * _fade,
            0f);
    }
}
