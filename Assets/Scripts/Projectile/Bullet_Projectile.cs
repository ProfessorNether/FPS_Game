using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Bullet_Projectile : MonoBehaviour
{
    private GameObject player;
    public Rigidbody body;

    public float ThrowForce;
    public float ThrowUpwardForce;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform); // Make the rock look towards the target.
        body.AddForce(transform.forward * ThrowForce + transform.up * ThrowUpwardForce, ForceMode.Impulse); // Apply force to the projectile so that it flies forward
    }
}
