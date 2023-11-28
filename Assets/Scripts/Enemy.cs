using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;

    public float squareOfMovement = 20f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;

    private float xPosition;
    private float yPosition;
    private float zPosition;

    public float closeEnough = 2f;

     void Start()
    {
        xMin = zMin = -squareOfMovement;
        xMax = zMax = squareOfMovement; 
        newLocation();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            newLocation();
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
