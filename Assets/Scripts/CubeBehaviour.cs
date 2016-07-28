using Assets.Scripts.Events;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Set in Unity
    public Conductor Orchestrator;
    public AudioSource AudioSource;
    public AudioClip AudioClip;
    public int ActiveBeat;

    // Data members
    private float _fade;


    public CubeBehaviour()
    {
        _fade = 0;
    }

    void Start()
    {
        Orchestrator.Subscribe(OnBeat);
    }

    void FixedUpdate()
    {
        if (_fade > 0)
        {
            _fade--;
            Rotate();
        }
    }

    internal void OnBeat(int beat, int measure)
    {
        if (beat == ActiveBeat)
        {
            AudioSource.PlayOneShot(AudioClip);
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
