using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBarrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        print("collision enter");
        if (other.transform.TryGetComponent(out Damageable damageable))
        {
            print("hit a ship");
            Damageable.DamageMessage message = new Damageable.DamageMessage()
            {
                amount = 6,
                damageSource = transform.position
            };
            damageable.ApplyDamage(message);
        }
    }
}
