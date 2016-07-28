using Assets.scripts.Orchestra;
using UnityEngine;

public class SoundStore : MonoBehaviour
{
    public Orchestration orchestrator;
    public AudioSource source;

    public AudioClip up;
    public AudioClip down;
    public AudioClip left;
    public AudioClip right;

    private int _beat;
    private int _measure;
    private bool _played;

    public SoundStore()
    {
        _beat = -1;
        _measure = -1;
        _played = true;
    }

    void Start()
    {
        orchestrator.SubscribeToElapsed(PlaySoundClip);
    }

    internal void PlaySoundClip(int beat, int measure)
    {
        _beat = beat;
        _measure = measure;
        _played = false;
    }

    void Update()
    {
        if (!_played)
        {
            if (_beat == 0)
            {
                source.PlayOneShot(up, 1f);
            }
            else
            {
                source.PlayOneShot(down, 1f);
            }
            _played = true;
        }
    }
}
