using Assets.Scripts.Orchestra;
using UnityEngine;

public class SoundStore : MonoBehaviour
{
    public Orchestration orchestrator;
    public AudioSource source;

    public AudioClip up;
    public AudioClip down;
    public AudioClip left;
    public AudioClip right;

    void Start()
    {
        orchestrator.SubscribeToElapsed(PlaySoundClip);
    }

    internal void PlaySoundClip(int beat, int measure)
    {
        if (beat == 0)
        {
            source.PlayOneShot(up, 1f);
        }
        else
        {
            source.PlayOneShot(down, 1f);
        }
    }
}
