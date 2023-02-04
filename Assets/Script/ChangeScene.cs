using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private static ChangeScene _instance;

    public static ChangeScene Instance { get => _instance; set => _instance = value; }
    private void Awake()
    {
        Instance = this;
    }

    public void Scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

