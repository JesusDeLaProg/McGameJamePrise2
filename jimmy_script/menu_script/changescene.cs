using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour {

    public void retourmenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2) ;
    }
}
