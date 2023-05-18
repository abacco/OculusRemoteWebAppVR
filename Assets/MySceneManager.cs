using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    public void EnterForest()
    {
        SceneManager.LoadScene("Forest");//, LoadSceneMode.Additive);
    }

    public void EnterHub()
    {
        SceneManager.LoadScene("Hub");//, LoadSceneMode.Additive);
    }
}
