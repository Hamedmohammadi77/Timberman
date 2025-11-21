using UnityEngine;

namespace _Scripts.Timber_Man.Models.Parents
{
    public class PlayerIsDeadParent : MonoBehaviour
    {
        public void SetActiveGameObject(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}