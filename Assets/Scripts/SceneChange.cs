using UnityEngine;
using Assets.Scripts.Events;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Conductor Conductor;
    public string SceneName;
    public int ChangeOnMeasure;
    public int ChangeOnBeat;

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
