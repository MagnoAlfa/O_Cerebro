using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento2 : MonoBehaviour
{
    [SerializeField]
    Rigidbody rig;
    
    [SerializeField]
    float velocidade;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rig.velocity = new Vector3(Input.GetAxis("Horizontal") * velocidade, rig.velocity.y, Input.GetAxis("Vertical") * velocidade);
    }
}
