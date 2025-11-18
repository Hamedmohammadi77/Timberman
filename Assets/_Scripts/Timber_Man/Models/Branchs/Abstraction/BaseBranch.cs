using _Scripts.Timber_Man.Models.Enums;
using UnityEngine;

namespace _Scripts.Timber_Man.Models.Branchs.Abstraction
{
    public abstract class BaseBranch : MonoBehaviour
    {
        public abstract BranchType Type { get; }

        public void MoveDown()
        {
            transform.position= new Vector2(0, transform.position.y-2);
        }

        public void Branch_Destroy()
        {
            
        }
    }
}