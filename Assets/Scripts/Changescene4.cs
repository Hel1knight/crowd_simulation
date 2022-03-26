using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Changescene4 : MonoBehaviour
{

    public string LevelToLoad;


    void start()
    {

    }

    public void changescene()
    {
        SceneManager.LoadScene("finale4");
    }



}
