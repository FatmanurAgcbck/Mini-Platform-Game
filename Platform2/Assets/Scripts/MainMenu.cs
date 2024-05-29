using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject stopScreen;

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame()
    {
        Debug.Log("Oyundan çıkıldı");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    
    
    public void TogglePause()
    {
        if (isPaused)
        {
            // Oyunu devam ettir
            Time.timeScale = 1f; // Zaman ölçeğini 1 yaparak oyunu devam ettirir
            isPaused = false;
            stopScreen.SetActive(false);
            
        }
        else
        {
            //oyunu durdur
            Time.timeScale = 0f; // Zaman ölçeğini 0 yaparak oyunu duraklatır
            isPaused = true;
            stopScreen.SetActive(true);
        }
    }

    
}
