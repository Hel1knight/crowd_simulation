using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Changescene2 : MonoBehaviour
{

    public string LevelToLoad;


    void start()
    {

    }

    public void changescene()
    {
        SceneManager.LoadScene("finale2");
    }



}
