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

    private void Start(){
        EventManager.playerHit += OnHealthChange;
        EventManager.enemyKilled += OnScoreChange;
        
        timerText.text = 0.ToString();
        scoreText.text = 0.ToString();
        healthSlider.value = 100;
    }

    public void Update(){

        // calculating time 
        timeElapsed += Time.deltaTime;

        // displaying time 
        timerText.text = $"{(int) timeElapsed} sec";
    }

    public void OnHealthChange(int health){
        healthSlider.value = health;
    }

    public void OnScoreChange(int score){
        scoreText.text = score.ToString();
    }

}
