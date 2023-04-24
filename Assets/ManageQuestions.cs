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

    [SerializeField] private TextMeshProUGUI Question1;         // text that shows question
    [SerializeField] private TextMeshProUGUI Answer2;           // the number showing on the middle button
    [SerializeField] private TextMeshProUGUI Choice1;           // the number showing on the lef/right button
    [SerializeField] private TextMeshProUGUI Choice2;           // the number showing on the left/right button
    [SerializeField] private TextMeshProUGUI Counter;           // the text that shows how many correct answers
    [SerializeField] private TextMeshProUGUI WrongAnswer;       // the text that shows how many lives you have left
    [SerializeField] private TextMeshProUGUI feedbackText;      // the text that shows: Correct! Try again!
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    private int ranNum1;                                        // randomly generated number used for math question 1 +
    private int ranNum2;                                        // randomly generated number used for math question 1
    private char addSub;                                        // plus and minus sign
    private int answer;                                         // correct answer, randomly put into one of the buttons
    private static int counter = 0;                             // counts correct answers
    private static int wrongAnswers = -1;                       // count the wrong answer, starts with -1 because the first answers will always be wrong by starting the game
    public static bool correct = false;                         // did player click the right answer
    private static int guess;                                   // the button the player guessed

    private static int indexCorrect = -1;                       // which button the correct answer is in
    private static System.Random rand;                          // random generator



   public void ButtonPress() { 
    correct = false;

    if(guess == indexCorrect) {
        counter++;
        correct = true;
        feedbackText.text = "Correct!";
        audioSource.PlayOneShot(correctSound);  
    }
    else{ 
        wrongAnswers++; 
        correct = false;
        if (wrongAnswers>0) {
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
    //Debug.Log("Correct buttonPress returns: " + correct);
    Debug.Log("indexCorrect = " + indexCorrect + ", " + "guess = " + guess);
    guess = -1;
    int lives = 5 - wrongAnswers;
    Counter.text = "You have " + counter + " correct answers!";
    WrongAnswer.text = "You have " + lives + " lives left";
    
    float operatorRand = UnityEngine.Random.Range(0f, 1f);
    if (operatorRand < 0.7f) {
        Question();
    } 
    else {
        QuestionPlaceValue();
    }
        
    }



   public void GetGuess() {
     guess = 0;
     //Debug.Log("Correct button returns: " + correct);
   }

   public void GetGuess1() {
     guess = 1;
    //Debug.Log("Correct button returns: " + correct);
   }

     public void GetGuess2() {
     guess = 2; 
     //Debug.Log("Correct button returns: " + correct);
   }
  

    

    private void Question() {
    //Debug.Log("Correct question returns: " + correct);
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
     Question1.fontSize = 50;
     Answer2.textStyle = TMP_Style.NormalStyle;
      

    }
    private void QuestionPlaceValue() {
    
    int choice1;
    int choice2;
    int choice3;

    String ones = "ones";
    String tens = "tens";
    String hundreds = "hundreds";
    String place = "";

     
     choice1 = Range(0,10);
     choice2 = Range(0,10);
     
     //checks that the number is not the same
     while (choice2 == choice1) {
        choice2 = Range(0,10);
     }
     
     choice3 = Range(0,10);
     
     //checks that the number is not the same
     while (choice3 == choice2 || choice3 == choice1) {
        choice3 = Range(0,10);
     }


        
        String[] places = {"ones", "tens", "hundreds"};
        int index = Range(0,3);
        place = places[index];   
        
        if (choice1 == 0){
            Question1.text = "In the number " + choice2 + choice3 + ".\n What value is in the " + place + " place?";
        }
        else { 
            Question1.text = "In the number " + choice1 + choice2 + choice3 + ".\n What value is in the " + place + " place?";
        }
        
        if (place.Equals(ones)) {
            answer = choice3;
        }
        else if(place.Equals(tens)) {
            answer = choice2;
        }
        else if (place.Equals(hundreds)) {
            answer = choice1;
        }
        else {
        }

        Debug.Log("Place: " + place);
        Debug.Log("Answer: " + answer);

        int[] choices = new int[3];
        choices[0] = choice1;
        choices[1] = choice2;
        choices[2] = choice3;

        int n = choices.Length;
        
        //shuffles the choices
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
     Question1.fontSize = 20;
     Answer2.textStyle = TMP_Style.NormalStyle;
      

    }

    
     public void OnClick()
    {
        SceneManager.LoadScene("Test Scene");   }


}
