using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnTrigger : MonoBehaviour
{

    public GameObject enemyLogic;
    public GameObject enemyMesh;
    public Transform player;
    public float triggerDiastance = 4f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < triggerDiastance) { 
            enemyLogic.SetActive(true);
            enemyMesh.SetActive(false);

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this);
        }
    }
}
