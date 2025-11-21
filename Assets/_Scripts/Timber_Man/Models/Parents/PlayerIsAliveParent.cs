using UnityEngine;

namespace _Scripts.Timber_Man.Models.Parents
{
    public class PlayerIsAliveParent : MonoBehaviour
    {
        public void SetActiveGameObject(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}