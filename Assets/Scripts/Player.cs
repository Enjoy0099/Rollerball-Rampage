using System.Collections;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody mybody;

    private GameObject focalPoint;
    public GameObject powerUpIndicator;

    public bool hasPowerUp = false;
    private float powerUpForce = 15f;
    public bool fireUp = false;
    
    float jumpPower = 20f;
    public bool smashPower = false;
    public float smashRange = 5f;
    public bool almighty_Push = false;

    private void Start()
    {
        mybody = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindWithTag(NameManager.FOCALPOINT_TAG);
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis(NameManager.VERTICAL_INPUT);

        mybody.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime, ForceMode.Impulse); 

        powerUpIndicator.transform.position = transform.position + new Vector3(0f, -0.6f, 0f);    

        if(transform.position.y < -10f)
        {
            EditorApplication.isPlaying = false;
        }

        /*if(Input.GetKeyDown(KeyCode.Space) && !smashPower)
        {
            Smash();
        }*/

        if(transform.position.y > 4f)
        {
            HitGroundFullForce(smashPower);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(NameManager.POWERUP_TAG))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());
        }
        else if(other.CompareTag(NameManager.FIREUP_TAG))
        {
            fireUp = true;
            Destroy(other.gameObject);
            StartCoroutine(FireUpCountdownRoutine());
        }
        else if (other.CompareTag(NameManager.SMASH_TAG))
        {
            Smash();
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    IEnumerator FireUpCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        fireUp = false;
    }

    void Smash()
    {
        mybody.velocity = Vector3.zero;
        mybody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        gameObject.GetComponent<SphereCollider>().material.bounciness = 0f;
        smashPower = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(NameManager.ENEMY_TAG) && hasPowerUp)
        {
            Rigidbody enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - mybody.transform.position;

            enemyBody.AddForce(awayDirection * powerUpForce, ForceMode.Impulse);
        }
        if(collision.gameObject.CompareTag(NameManager.GROUND_TAG) && smashPower)
        {
            almighty_Push = true;
            smashPower = false;
            mybody.velocity = Vector3.zero;
            mybody.mass = 1f;
            gameObject.GetComponent<SphereCollider>().material.bounciness = 1f;
            Invoke("Almighty_Push", 0.2f);
        }
    }

    void HitGroundFullForce(bool smash)
    {
        if(smash)
            mybody.AddForce(Vector3.down * (jumpPower ), ForceMode.Impulse);
    }

    void Almighty_Push()
    {
        almighty_Push = false;
    }

}
