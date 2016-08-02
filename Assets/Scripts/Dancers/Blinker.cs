using UnityEngine;
using Assets.Scripts.Events;
using Assets.Scripts.Extensions;

public class Blinker : MonoBehaviour
{
    public Conductor Conductor;
    public AudioClip AudioClip;
    public int ActiveBeat;

    private AudioSource _audioSource;
    private Renderer _renderer;
    private float _fade;

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.spatialBlend = 0.75f;

        _renderer = GetComponent<Renderer>();
        SetEnabled(false);

        Conductor.Subscribe(Blink);
    }

    void FixedUpdate()
    {
        if (_fade > 1)
        {
            _fade--;
        }
        else if (_fade == 1)
        {
            SetEnabled(false);
            _fade--;
        }
    }


    private void Blink(int beat, int measure)
    {
        if (beat == ActiveBeat)
        {
            SetEnabled(true);
            _audioSource.PlaySafe(AudioClip);
            _fade = 15;
        }
    }

    private void SetEnabled(bool enabled)
    {
        gameObject.SetActive(enabled);
        _renderer.enabled = enabled;
    }
}
