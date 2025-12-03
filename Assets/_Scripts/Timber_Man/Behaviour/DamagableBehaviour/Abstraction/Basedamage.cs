using _Scripts.Timber_Man.Behaviour.HitBehaviour.abstraction;
using UnityEngine;

namespace _Scripts.Timber_Man.Behaviour.DamagableBehaviour.Abstraction
{
    public abstract class Basedamage : MonoBehaviour
    {
        public abstract void Attack(BaseHit baseHit);
    }
}