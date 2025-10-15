
using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Å© ñYÇÍÇ∏Ç…í«â¡ÅI

public class GameSceneManager : MonoBehaviour
{
    public string nextSceneName;

    private string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton() 
    {
    
    }

    public void RetryButton()
    {
        Scene currentscene = SceneManager.GetActiveScene();

        if (currentscene != null) 
        {
            sceneName = currentscene.name;

            SceneManager.LoadScene(sceneName);
        }

        
    }

    public void NextButton()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
