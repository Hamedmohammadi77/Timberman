using UnityEngine;

namespace _Scripts.Timber_Man.UI
{
    public class OptionUI : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OpenOtionUI()
        {
            gameObject.SetActive(true);
        }

        public void CloseOtionUI()
        {
            gameObject.SetActive(false);
        }
    }
}