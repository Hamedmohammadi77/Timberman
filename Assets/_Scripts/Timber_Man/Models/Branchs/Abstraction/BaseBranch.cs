using _Scripts.Timber_Man.Models.Enums;
using UnityEngine;

namespace _Scripts.Timber_Man.Models.Branchs.Abstraction
{
    public abstract class BaseBranch : MonoBehaviour
    {
        public abstract BranchType Type { get; }

        public abstract void Destroy();
    }
}