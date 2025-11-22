using UnityEngine;

namespace _Scripts.Timber_Man.Behaiveir
{
    public abstract class BaseHeat : MonoBehaviour
    {
        public abstract void damage();
    }

    public class PlayerHit : BaseHeat
    {
        public override void damage()
        {
            throw new System.NotImplementedException();
        }
    }
}