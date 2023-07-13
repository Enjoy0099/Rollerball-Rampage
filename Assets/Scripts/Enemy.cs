using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 5f;
    private Rigidbody enemyBody;
    private GameObject player;
    Player playerScript;
    private int AlmightyPush;

    public bool boss_Power = false;
    public bool power_Speed = false;
    public bool power_size = false;
    public bool power_Strength = false;
    public bool power_AlmightyPush = false;

    private void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag(NameManager.PLAYER_TAG);
        playerScript = player.GetComponent<Player>();
        if (boss_Power)
        {
            AlmightyPush = 5;
        }
        else if (power_Speed)
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
        if(boss_Power)
        {
            Vector3 lookDirection = (player.transform.position - transform.position);

            enemyBody.AddForce(lookDirection * enemySpeed * Time.deltaTime, ForceMode.Impulse);
        }
        else if(power_Speed)
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
        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
        if(Vector3.Distance(transform.position, player.transform.position) < playerScript.smashRange && playerScript.almighty_Push)
        {
            Vector3 awayDirection = transform.position - player.transform.position;

            enemyBody.AddForce(awayDirection * 5, ForceMode.Impulse);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(NameManager.PLAYER_TAG) && boss_Power)
        {
            Rigidbody playerBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - enemyBody.transform.position;

            playerBody.AddForce(awayDirection * AlmightyPush, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag(NameManager.PLAYER_TAG) && power_AlmightyPush)
        {
            Rigidbody playerBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - enemyBody.transform.position;

            playerBody.AddForce(awayDirection * AlmightyPush, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag(NameManager.PLAYER_TAG) && playerScript.almighty_Push)
        {
            Destroy(gameObject);
        }
    }
}
