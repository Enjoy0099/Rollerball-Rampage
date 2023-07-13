using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemy;
    private Player playerScript;
    float speed;
    Vector3 directionBullect;

    private void Awake()
    {
        speed = 5f;
        playerScript = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {

        enemy = GameObject.FindWithTag(NameManager.ENEMY_TAG);
        //DirectionEnemy();
        Invoke("DisappearBullet", 5f);
    }

    private void Update()
    {
        if(!enemy)
        {
            gameObject.SetActive(false);
        }

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void DirectionEnemy()
    {
        directionBullect = (enemy.transform.position - playerScript.transform.position);

        Vector3 starPos = playerScript.transform.position + (directionBullect.normalized * 2);

        Quaternion rotateTarget = Quaternion.LookRotation(directionBullect, Vector3.up) * Quaternion.Euler(90.0f, 0, 0);
        //Quaternion rotate = Quaternion.RotateTowards(transform.rotation, rotateTarget, 100);

        transform.rotation = rotateTarget;
        transform.position = starPos;


    }



    void DisappearBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(NameManager.ENEMY_TAG))
        {
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemy.GetComponent<Rigidbody>().AddForce(awayFromPlayer * 10.0f, ForceMode.Impulse);
            
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag(NameManager.GROUND_TAG))
        {
            gameObject.SetActive(false);
        }
        
    }

    private void OnDisable()
    {
        CancelInvoke("DisappearBullet");
    }
}
