using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneExit : MonoBehaviour
{
    [SerializeField] private string nameOfScene;
    public static LoadSceneExit Instance { get; private set; }
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadOnCLick()
    {
        LoadScene(nameOfScene);
    }

    public void OnCLickExit()
    {
        Application.Quit();
    }
}
