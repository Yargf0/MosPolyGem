using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneExit : MonoBehaviour
{
    [SerializeField] private string nameOfScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnCLick()
    {
        LoadScene(nameOfScene);
    }

    public void OnCLickExit()
    {
        Application.Quit();
    }
}
