using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;

    public GameObject bullet;
    private EnemyDetectPlayer enemyDetectPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyDetectPlayer = transform.GetChild(0).GetComponent<EnemyDetectPlayer>(); 
    }

    // shoting 
    [SerializeField] private float fireRate = 1.5f;
    private float timeElasped = 0;
    
    void Update()
    {
        transform.LookAt(player, Vector3.up); // looking towards player

        if(enemyDetectPlayer.hasPlayerEntered){

            if(timeElasped > fireRate){
                // fire bullet 

                GameObject gb = Instantiate(bullet);
                // BulletFire bulletFire = gb.GetComponent<BulletFire>();
                // bulletFire.startPosition = transform.position;
                // bulletFire.endPosition = player.position;

                // bulletFire.ShootBullet();

                gb.transform.position = transform.position;
                Rigidbody rb = gb.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 750);

                //Vector3 shotAt = transform.forward * 3f;
                //bulletFire.endPosition = ;

                timeElasped = 0;
            }
            else timeElasped += Time.deltaTime;
        }
    }
}
