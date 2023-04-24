using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   

    public void BackGroundChanger()
    {
       //camping.setActive(false);
       // freev.setActive(true);
       SceneManager.LoadScene("Questions");
    }

}
