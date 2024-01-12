using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Launch_Script : MonoBehaviour
{
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(3f, 0f, 2f);
        Quaternion rotation = Quaternion.Euler(0f, 45f, 0f);
        Instantiate(Bullet, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
