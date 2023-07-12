using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 5f;
    private Rigidbody enemyBody;
    private GameObject player;
    private int AlmightyPush;

    public bool power_Speed = false;
    public bool power_size = false;
    public bool power_Strength = false;
    public bool power_AlmightyPush = false;

    private void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag(NameManager.PLAYER_TAG);

        if (power_Speed)
            enemySpeed *= 2;
        else if (power_size)
            enemySpeed /= 2;
        else if (power_Strength)
            enemySpeed /= 3;
        else if (power_AlmightyPush)
            AlmightyPush = 5;
    }

    private void Update()
    {
        if(power_Speed)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            enemyBody.AddForce(lookDirection * enemySpeed * Time.deltaTime, ForceMode.Impulse);
        }
        else if(power_size)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            enemyBody.AddForce(lookDirection * enemySpeed * Time.deltaTime, ForceMode.Impulse);
        }
        else if(power_Strength)
        {
            Vector3 lookDirection = (player.transform.position - transform.position);

            enemyBody.AddForce(lookDirection * enemySpeed * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            enemyBody.AddForce(lookDirection * enemySpeed * Time.deltaTime, ForceMode.Impulse);

            
        }
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(NameManager.PLAYER_TAG) && power_AlmightyPush)
        {
            Rigidbody playerBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - enemyBody.transform.position;

            playerBody.AddForce(awayDirection * AlmightyPush, ForceMode.Impulse);
        }
    }
}
