using System.Collections;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [HideInInspector] public Vector3 startPosition;
    [HideInInspector] public Vector3 endPosition;

    public void ShootBullet(){

        StartCoroutine(nameof(Shoot));
    }
    public IEnumerator Shoot(){

        float travelTime = 1.5f;
        float timeElapsed = 0;

        while (timeElapsed < travelTime){

            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / travelTime);
            timeElapsed += Time.deltaTime;

            transform.LookAt(startPosition, Vector3.up);

            yield return null;
        }

        Destroy(this.gameObject);
    }
}
