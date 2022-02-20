using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public bool created = false;
    public float damage;
    public Vector3 destination;
    public float speed = 0.1f;
    public int playerId = -1;

    float timer = 3f;
    
    // Update is called once per frame
    void Update() {
        if(!created) {
            return;
        }
        this.transform.position += (new Vector3(destination.x, destination.y, destination.z) * Time.deltaTime * speed);
        if (timer <= 0)
            this.gameObject.SetActive(false);
        else
            timer -= Time.deltaTime;
    }

    public void Create(Vector3 rotation, float gunDamage, float missleSpeed) {
        //transform.rotation = rotation;
        destination = Vector3.up;
        timer = 3f;
        created = true;
        damage = gunDamage;
        speed = missleSpeed;
        GetComponent<Rigidbody>().AddForce(rotation);
        this.gameObject.SetActive(true);
    }

}
