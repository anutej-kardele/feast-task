using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _currentPlayerHealth;

    public void Awake(){
        CurrentPlayerHealth = 100;
    }

    public int CurrentPlayerHealth{
        get { return _currentPlayerHealth;}
        set { 
            _currentPlayerHealth = value;

            if(value <= 0){
                EventManager.gameOver?.Invoke();
            }
        }
    }

    public void OnTriggerEnter(Collider other){

        if(other.gameObject.tag.Equals("Bullet")){
            
            CurrentPlayerHealth -= 20;
            EventManager.playerHit?.Invoke(CurrentPlayerHealth);

            // Destroy the bullet 
            Destroy(other.gameObject);
        }
    }
}
