using _Scripts.Timber_Man.Models.Enums;
using UnityEngine;

namespace _Scripts.Timber_Man.Behaviour.Damagable.Abstraction
{
    public abstract class Basedamaga : MonoBehaviour
    {
        public abstract void Attack(PlayerState player);
    }
}