using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 5f;
    private Rigidbody enemyBody;
    private GameObject player;

    private void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag(NameManager.PLAYER_TAG);
    }

    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyBody.AddForce(lookDirection * enemySpeed * Time.deltaTime, ForceMode.Impulse);  

        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
