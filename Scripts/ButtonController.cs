using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    FadeInOut fade;

    public void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        fade.FadeOut();
    }

    // Fades in and loads level 1 scene
    public IEnumerator LoadLevel1()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level_1");
    }
    // When play button is pressed LoadLevel1() coroutine starts
    public void OnPlayButton()
    {
        StartCoroutine(LoadLevel1());
    }

    // LoadMainMenu() Fades in and loads main menu scene
    public IEnumerator LoadMainMenu()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main_Menu");
    }
    // When menu button is pressed LoadMainMenu() coroutine starts
    public void OnMenuButton()
    {
        StartCoroutine(LoadMainMenu());
    }

    // When exit button is pressed the game will stop playing
    public void OnExitButton()
    {
        Application.Quit();
    }
}
