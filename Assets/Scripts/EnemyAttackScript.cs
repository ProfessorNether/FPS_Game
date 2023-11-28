using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    private Enemy enemyMovement;
    private Transform player;
    public float closeEnough = 10f;

    private Renderer rend;

    private bool foundPlayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<Enemy>();
        rend = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position ) <= closeEnough)
        {
            foundPlayer = true;
            enemyMovement.enemy.SetDestination(player.position);
        } else if (foundPlayer)
        {
            enemyMovement.newLocation();
            foundPlayer = false;
        }
    }
}
