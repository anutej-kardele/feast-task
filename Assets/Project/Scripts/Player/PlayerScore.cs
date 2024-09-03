using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int score;

    public void Awake(){
        score = 0;
    }

    public void OnTriggerEnter(Collider other){

        if(other.gameObject.tag.Equals("Enemy")){
            // increase score
            score++;
            EventManager.enemyKilled?.Invoke(score);

            // Destroy the bullet 
            Destroy(other.gameObject);
            
            if(score == 4){
                // game over 
                EventManager.gameOver?.Invoke();
            }
        }
    }
}
