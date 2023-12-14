using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;

    public float squareOfMovement = 55f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;

    private float xPosition;
    private float yPosition;
    private float zPosition;

    public float closeEnough = 5f;
    public float attackDistance = 2f;

    public GameObject player;

    void Start()
    {
        xMin = zMin = -squareOfMovement;
        xMax = zMax = squareOfMovement; 
        newLocation();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            newLocation();
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(0.5f);
        }
    }
    public void newLocation()
    {
        xPosition = Random.Range(xMin, xMax);
        yPosition = transform.position.y;
        zPosition = Random.Range(zMin, zMax);
        enemy.SetDestination(new Vector3(xPosition, yPosition, zPosition));

    }
}
