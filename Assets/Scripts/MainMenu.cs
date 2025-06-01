using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject InstructionsPanel, MainPanel;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
    }

  public void OpenInstructions()
    {
        MainPanel.SetActive(false);
        InstructionsPanel.SetActive(true);
    }

    public void Back()
    {
        MainPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
      
            Application.Quit();
       
    }
}
