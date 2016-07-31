using UnityEngine;
using Assets.Scripts.Events;

public class Mover : MonoBehaviour
{
    public Conductor Conductor;

    public GameObject From;
    public AudioClip FromSound;
    public int FromMeasure;

    public GameObject To;
    public AudioClip ToSound;
    public int ToMeasure;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        transform.position = From.transform.position;

        Conductor.Subscribe(OnBeat);
    }

    private void OnBeat(int beat, int measure)
    {
        if (measure % 8 == FromMeasure)
        {
            Move(From, To, beat);
            _audioSource.PlayOneShot(FromSound);
        }
        else if (measure % 8 == ToMeasure)
        {
            Move(To, From, beat);
            _audioSource.PlayOneShot(ToSound);
        }
    }

    private void Move(GameObject startObject, GameObject endObject, int beat)
    {
        var start = startObject.transform.position;
        var end = endObject.transform.position;
        float x = end.x + (start.x - end.x) * ((3f - beat) / 4f);
        float y = end.y + (start.y - end.y) * ((3f - beat) / 4f);
        float z = end.z + (start.z - end.z) * ((3f - beat) / 4f);

        transform.position = new Vector3(x, y, z);
    }
}
