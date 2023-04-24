using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.Random;
using System.Linq;
using System;

public class ManageQuestions : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI Question1;
    [SerializeField] private TextMeshProUGUI Answer2;
    [SerializeField] private TextMeshProUGUI Choice1;
    [SerializeField] private TextMeshProUGUI Choice2;
    [SerializeField] private TextMeshProUGUI Counter;
    [SerializeField] private TextMeshProUGUI WrongAnswer;
    [SerializeField] private TextMeshProUGUI feedbackText;
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    private int ranNum1;
    private int ranNum2;
    private char addSub;
    private int answer;
    private static int counter = 0;
    private static int wrongAnswers = -1;
    public static bool correct = false;
    private static int guess;
    private static int indexCorrect = -1; // which button has the correct answer


   public void ButtonPress() { 
    correct = false;

    if(guess == indexCorrect) {
        counter++;
        correct = true;
        if(guess==0){
        feedbackText.text = "Correct!";
        audioSource.PlayOneShot(correctSound);
       }
        
    }
    else{
        wrongAnswers++; 
        correct = false;
        if (guess==0) {
        feedbackText.text = "Sorry, wrong answer. Try again!";
        audioSource.PlayOneShot(wrongSound);
        }
    }
    //Debug.Log("correct counter = " + counter + ", " + "wrong answers = " + wrongAnswers);
    if ((counter == 10) && (wrongAnswers < 2)) {
            SceneManager.LoadScene("Winning Scene");
        }
    else if ((counter == 10) && (wrongAnswers < 5)) {
            SceneManager.LoadScene("Almost Won");
        }
    else if (wrongAnswers == 5) {
            SceneManager.LoadScene("Losing Scene");
        }
    else {

    }
    Debug.Log("Correct buttonPress returns: " + correct);
    //Debug.Log("indexCorrect = " + indexCorrect + ", " + "guess = " + guess);
    guess = -1;
    int lives = 5 - wrongAnswers;
    Counter.text = "You have " + counter + " correct answers!";
    WrongAnswer.text = "You have " + lives + " lives left";

        Question();
       
        
    }
 /* private bool isCorrect(String guess1)
    {
        correct = false;
        int guessValue;
        if (int.TryParse(guess1, out guessValue))
        {
            if (guessValue == answer)
            correct = true;
            Debug.Log("isCorrect returns: " + correct);
            return correct;
        }
        return false;
    }*/



   public void GetGuess() {
        guess = 0;
        Debug.Log("Correct button returns: " + correct);
   }

   public void GetGuess1() {
    guess = 1;
   Debug.Log("Correct button returns: " + correct);
   }

     public void GetGuess2() {
        guess = 2; 
        Debug.Log("Correct button returns: " + correct);
   }
  

    

    private void Question() {
    Debug.Log("Correct question returns: " + correct);
     ranNum1 = Range(1,11);
     ranNum2 = Range(1,11);

    float operatorRand = UnityEngine.Random.Range(0f, 1f);
    if (operatorRand < 0.5f) {
        addSub = '+';
        answer = ranNum1 + ranNum2;
    } 
    else {
        addSub = '-';
        answer = ranNum1 - ranNum2;
        if (answer < 0) {
            int temp = ranNum1;
            ranNum1 = ranNum2;
            ranNum2 = temp;
            answer = ranNum1 - ranNum2;

        }
    }

    int choice1;
    int choice2;

    Question1.text = ranNum1 + " " + addSub + " " + ranNum2 + " = ";

     choice1 =  Range(answer-5,answer + 5);
        while (choice1 == answer || choice1 < 0) {
            choice1 =  Range(answer-5,answer + 5);
        }
     
     choice2 = Range(answer-5,answer + 5);
            while (choice2 == answer || choice2 == choice1 || choice2 < 0) {
                choice2 = Range(answer-5,answer + 5);
            }
            
            int[] choices = new int[3];
        choices[0] = answer;
        choices[1] = choice1;
        choices[2] = choice2;

        int n = choices.Length;
        while (n > 1)
        {
            int k = UnityEngine.Random.Range(0, n--);
            int temp = choices[n];
            choices[n] = choices[k];
            choices[k] = temp;
        }

        Answer2.text = "" + choices[0];
        Choice1.text = "" + choices[1];
        Choice2.text = "" + choices[2];

        //figure out which button have the right answer
        for (int i = 0; i < 3; i++) {
            if (choices[i] == answer){
                indexCorrect = i;
            }
        }
        Debug.Log("Correct answer is in: " + indexCorrect);


        
     Question1.textStyle = TMP_Style.NormalStyle;
     Answer2.textStyle = TMP_Style.NormalStyle;
      

    }
    
     public void OnClick()
    {
        SceneManager.LoadScene("Test Scene");   }


}
