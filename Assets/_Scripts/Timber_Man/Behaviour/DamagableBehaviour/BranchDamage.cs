using System;
using _Scripts.Timber_Man.Behaviour.DamagableBehaviour.Abstraction;
using _Scripts.Timber_Man.Behaviour.HitBehaviour.abstraction;
using UnityEngine;

namespace _Scripts.Timber_Man.Behaviour.DamagableBehaviour
{
    public class BranchDamage : Basedamage
    {
        public override void Attack(BaseHit baseHit)
        {
            baseHit.Damage();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            BaseHit baseHit = other.gameObject.GetComponent<BaseHit>();
            if (baseHit != null)
            {
                Attack(baseHit);
            }
        }
    }
}