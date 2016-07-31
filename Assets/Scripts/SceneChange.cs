using UnityEngine;
using Assets.Scripts.Events;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string ActivationKey;
    public string SceneName;

    void Update()
    {
        if (Input.GetKeyDown(ActivationKey))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
