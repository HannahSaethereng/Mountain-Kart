using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayLevel : MonoBehaviour
{
 public void ButtonPress2() { 
    replayLevel();
 }



   private void replayLevel() {
    SceneManager.LoadScene("Questions");
   }
}
