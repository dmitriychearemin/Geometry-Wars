using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
   
    public void openSurvivalMode()
    {
        SceneManager.LoadScene(1);
    }

    public void openLobby()
    {
        SceneManager.LoadScene(0);
    }



}
