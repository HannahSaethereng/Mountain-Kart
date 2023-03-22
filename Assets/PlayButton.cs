using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    //public GameObject camping;
   // public GameObject freev;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackGroundChanger()
    {
       //camping.setActive(false);
       // freev.setActive(true);
       SceneManager.LoadScene("Questions");
    }

}
