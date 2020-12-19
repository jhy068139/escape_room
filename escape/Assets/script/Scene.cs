using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void MoveMain()
    {
        SceneManager.LoadScene("Main_game");
    }

    public void MoveStart()
    {
        SceneManager.LoadScene("start");

    }
    public void MoveExplain()
    {
        SceneManager.LoadScene("explain");

    }

    public void MoveEnding()
    {
        SceneManager.LoadScene("ending");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Movelevel2()
    {
        SceneManager.LoadScene("Level2");
        Cursor.lockState = CursorLockMode.None;
    }
    public void Movelevel3()
    {
        SceneManager.LoadScene("Level3");
        Cursor.lockState = CursorLockMode.None;
    }

    public void MoveSelect()
    {
        SceneManager.LoadScene("Select");
        Cursor.lockState = CursorLockMode.None;
    }
    public void Movehome()
    {
        SceneManager.LoadScene("start");
        Cursor.lockState = CursorLockMode.None;
    }

}
