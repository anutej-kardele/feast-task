using System.Collections;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [HideInInspector] public Transform playerPosi;

    public void Start(){

        playerPosi = GameObject.FindGameObjectWithTag("Player").transform;

        transform.LookAt(playerPosi, Vector3.up);
    }

}
