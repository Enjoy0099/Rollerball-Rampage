using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;

    public List<GameObject> bullet;

    private GameObject player;

    float firetimeduration = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(NameManager.PLAYER_TAG);
        for (int i = 0; i < 50; i++)
        {
            GameObject newbullet = Instantiate(bulletPrefab, player.transform.position, bulletPrefab.transform.rotation);
            newbullet.transform.parent = transform;
            bullet.Add(newbullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Player>().fireUp && firetimeduration < Time.time)
        {
            firetimeduration = Time.time + 0.3f;
            GameObject[] enemyList = GameObject.FindGameObjectsWithTag(NameManager.ENEMY_TAG);
            for (int i = 0; i < enemyList.Length; i++)
            {
                Vector3 lookToEnemy = enemyList[i].transform.position - player.transform.position;
                Vector3 starPos = player.transform.position + (lookToEnemy.normalized * 2);
                Quaternion rotate = Quaternion.LookRotation(lookToEnemy, Vector3.up) * Quaternion.Euler(90, 0, 0);
                // Create bullet and send enemy gameObject in bullet as a target
                for (int j = 0; j < bullet.Count; j++)
                {
                    if (!bullet[j].gameObject.activeInHierarchy)
                    {
                        bullet[j].gameObject.SetActive(true);
                        bullet[j].transform.position = starPos;
                        bullet[j].transform.rotation = rotate;
                        bullet[j].gameObject.GetComponent<Bullet>().enemy = enemyList[i].gameObject;
                        break;
                        
                    }
                }
                
            }
            //Create a different bullet for each enemy
            /*foreach (GameObject enemy in enemyList)
            {
                Vector3 lookToEnemy = enemy.transform.position - player.transform.position;
                Vector3 starPos = player.transform.position + (lookToEnemy.normalized * 2);
                Quaternion rotate = Quaternion.LookRotation(lookToEnemy, Vector3.up) * Quaternion.Euler(90, 0, 0);

                // Create bullet and send enemy gameObject in bullet as a target
                for (int i = 0; i < bullet.Count; i++)
                {
                    if (!bullet[i].gameObject.activeInHierarchy)
                    {
                        bullet[i].transform.position = starPos;
                        bullet[i].transform.rotation = rotate;

                        bullet[i].gameObject.SetActive(true);
                        bullet[i].gameObject.GetComponent<Bullet>().enemy = enemy.gameObject;

                        break;
                    }
                }
            }*/

        }

    }


    
        
        
}
