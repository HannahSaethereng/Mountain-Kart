using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.Random;

public class ManageQuestions : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI Question1;
    [SerializeField] private TextMeshProUGUI Answer2;
    [SerializeField] private TextMeshProUGUI Choice1;
    private int ranNum1;
    private int ranNum2;
    private char addSub;
    private int answer;
    private int counter;
    private bool correct = false;


   public void ButtonPress() { 

        Question();

    }




   private void isCorrect(int guess) {
       if(guess == answer) {
            correct = true;
       }
   }

    private void Question() {
     ranNum1 = Range(1,11);
     ranNum2 = Range(1,11);
     answer = ranNum1 + ranNum2;

     Question1.text = ranNum1 + " + " + ranNum2 + " = " + answer;
     Answer2.text = "" + answer;
     Choice1.text = "" + Range(answer-3,answer + 3);


     Question1.textStyle = TMP_Style.NormalStyle;
     Answer2.textStyle = TMP_Style.NormalStyle;
      

    }
     public void OnClick()
    {
        SceneManager.LoadScene("Test Scene");
    }


}
