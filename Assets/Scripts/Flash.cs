using Assets.Scripts.Orchestra;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Orchestration Orchestrator;
    
    private float _fade;

    private Vector3 _currentScale;

    public Flash()
    {
        _currentScale = new Vector3(1, 1, 1);
        _fade = 0;
    }

    void Start()
    {
        Orchestrator.SubscribeToElapsed(TransformToBeat);
    }

    void Update()
    {
        _fade += 0.1f;
        _currentScale /= _fade;
        transform.localScale = _currentScale;
    }

    internal void TransformToBeat(int beat, int measure)
    {
        if (beat == 0)
        {
            _currentScale = new Vector3(1, 2, 1);
        }
        else
        {
            _currentScale = new Vector3(2, 1, 1);
        }
        _fade = 1;
    }
}
