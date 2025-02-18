using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressButton : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject characterSelectionScreen;
    // Start is called before the first frame update
    public void play() {
        characterSelectionScreen.SetActive(true);
        menuScreen.SetActive(false);
    }
    public void menu() {
        SceneManager.LoadScene(1);
    }
    public void exit() {
        Application.Quit();
    }
    public void back() {
        menuScreen.SetActive(true);
        characterSelectionScreen.SetActive(false);
    }
    public void sonSelected() {
        globalVariable.charCode = 1;
        SceneManager.LoadScene(0);
    }
    public void rhabuSelected() {
        globalVariable.charCode = 2;
        SceneManager.LoadScene(0);
    }
    public void secateSelected() {
        globalVariable.charCode = 3;
        SceneManager.LoadScene(0);
    }
}
