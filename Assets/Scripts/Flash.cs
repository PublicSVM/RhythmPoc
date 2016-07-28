using Assets.scripts.Orchestra;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Orchestration Orchestrator;

    private int _beat;
    private int _measure;
    private float _fade;

    private Vector3 _currentScale;

    public Flash()
    {
        _currentScale = new Vector3(1, 1, 1);
        _beat = -1;
        _measure = -1;
        _fade = 0;
    }

    void Start()
    {
        Orchestrator.SubscribeToElapsed(TransformToBeat);
    }

    void Update()
    {
        if (_fade == -1)
        {
            if (_beat == 0)
            {
                _currentScale = new Vector3(1, 2, 1);
            }
            else
            {
                _currentScale = new Vector3(2, 1, 1);
            }
            _fade = 1;
        }
        else
        {
            _fade += 0.1f;
            _currentScale /= _fade;
        }
        transform.localScale = _currentScale;
    }

    internal void TransformToBeat(int beat, int measure)
    {
        _beat = beat;
        _measure = measure;
        _fade = -1;
    }
}
