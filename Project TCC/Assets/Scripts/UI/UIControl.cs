using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIControl : MonoBehaviour
{
    [Header("Mundo")]
    public int frameRate;
    public bool paused;
    public bool canPause;

    [Header("Telas")]
    public GameObject pauseScreen;

    void Start()
    {
        ChangeFPS (frameRate);

        if(canPause)
            DesabilitarMouse();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(canPause)
                Pause();
        }
    }

    void ChangeFPS(int frames)
    {
        Application.targetFrameRate = frames;
    }

    public void CarregarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Pause()
    {
        if(paused)
        {
            paused = false;
            Time.timeScale = 1;
            ActiveMenu(pauseScreen);
            DesabilitarMouse();
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            ActiveMenu(pauseScreen);
            HabilitarMouse();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ActiveMenu(GameObject menu)
    {
        if(menu.activeSelf)
            menu.SetActive(false);
        else
            menu.SetActive(true);
    }

    public void HabilitarMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DesabilitarMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
