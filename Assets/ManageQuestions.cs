using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.Random;

public class ManageQuestions : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI question;
    private int ranNum1;
    private int ranNum2;
    private char addSub;
    private int answer;
    private int counter;
    private bool correct = false;


   public void ButtonPress() { 

        Question();

    }




   private bool isCorrect(int guess) {
       if(guess == answer) {
            correct = true;
       }
   }
            
    

    private void Question() {
     ranNum1 = Range(1,11);
     ranNum2 = Range(1,11);
     answer = ranNum1 + ranNum2;

     question.text = ranNum1 + " + " + ranNum2 + " = " + answer;

     question.textStyle = TMP_Style.NormalStyle;
      

    }
     public void OnClick()
    {
        SceneManager.LoadScene("Test Scene");
    }


}
