using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Changescene : MonoBehaviour
{

    public string LevelToLoad;


    void start()
    {

    }

    public void changescene()
    {
        SceneManager.LoadScene("finale");
    }



}
