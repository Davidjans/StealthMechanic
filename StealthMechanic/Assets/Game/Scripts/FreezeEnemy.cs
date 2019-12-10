using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion;
using RootMotion.Dynamics;

public class FreezeEnemy : MonoBehaviour
{
    private Rigidbody m_RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            

            float hitVelocity = collision.relativeVelocity.magnitude;
            Debug.Log(hitVelocity +" Hitvelocity");
            Debug.Log(m_RigidBody.velocity.magnitude + " axe speed");
            Debug.Log(hitVelocity * 0.4f + " Hitvelocity halved");
            if (m_RigidBody.velocity.magnitude > hitVelocity * 0.4f)
            {
                if (hitVelocity > enemyHealth.ForceToRagdoll)
                {
                    PuppetMaster puppetMaster = collision.gameObject.GetComponentInParent<PuppetMaster>();
                    puppetMaster.state = PuppetMaster.State.Dead;
                    puppetMaster.pinWeight = 0;
                    puppetMaster.muscleWeight = 0;
                }
            }
            
        }
    }
}
