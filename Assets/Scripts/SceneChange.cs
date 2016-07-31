using UnityEngine;
using Assets.Scripts.Events;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Conductor Conductor;
    public string SceneName;
    public int ChangeOnMeasure;
    public int ChangeOnBeat;

    // TODO Change to using a string (key) and string (next scene) instead of using the beat

    void Start()
    {
        Conductor.Subscribe(ChangeLevel);
    }

    void ChangeLevel(int beat, int measure)
    {
        if (measure == ChangeOnMeasure && beat == ChangeOnBeat)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
