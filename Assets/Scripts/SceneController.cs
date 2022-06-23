using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ToGamePlay()
    {
        SceneManager.LoadScene("Gameplay 3D");
    }
    public void ToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
