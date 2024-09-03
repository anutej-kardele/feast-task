using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject reloadPanel;

    public void Awake(){
    }
    public void Start(){
        EventManager.gameOver += DisableObject;
    }
    
    public void DisableObject(){
        reloadPanel.SetActive(true);

        EventManager.gameOver -= DisableObject;
    }

}
