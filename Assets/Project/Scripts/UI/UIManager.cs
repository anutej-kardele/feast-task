using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TMP_Text timerText;
    public TMP_Text scoreText;
    public Slider healthSlider;

    private float timeElapsed = 0;
    
    private bool isGameOn = true;

    private void Start(){
        EventManager.playerHit += OnHealthChange;
        EventManager.enemyKilled += OnScoreChange;
        EventManager.gameOver += () => isGameOn = false;

        timerText.text = 0.ToString();
        scoreText.text = 0.ToString();
        healthSlider.value = 100;

        isGameOn = true;
    }

    public void Update(){

        if(isGameOn){
            // calculating time 
            timeElapsed += Time.deltaTime;

            // displaying time 
            timerText.text = $"{(int) timeElapsed} sec";
        }
    }

    public void OnHealthChange(int health){
        healthSlider.value = health;
    }

    public void OnScoreChange(int score){
        scoreText.text = score.ToString();
    }

}
