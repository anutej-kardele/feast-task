using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour
{
    public bool hasPlayerEntered = false;

    public void OnTriggerEnter(Collider other){

        if(other.gameObject.tag.Equals("Player")){
            hasPlayerEntered = true;
        }
    }

    public void OnTriggerExit(Collider other){

        if(other.gameObject.tag.Equals("Player")){
            hasPlayerEntered = false;
        }
    }

}
