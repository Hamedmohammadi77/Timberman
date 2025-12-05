using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Settings;
using _Scripts.Timber_Man.Signals.UI.OptionSignals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Timber_Man.Panels
{
    public class StorageChangePanel : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;
        private Button _storageChangeButton;
        private StorageType _thisStorageType = StorageType.BayeganStorage;
        private TextMeshProUGUI _storageChangeText;

        void Start()
        {
            _storageChangeText = GetComponentInChildren<TextMeshProUGUI>();
            _storageChangeText.text = _thisStorageType.ToString();

            _storageChangeButton = GetComponent<Button>();

            _storageChangeButton.onClick.AddListener(StorageChange);
        }

        private void StorageChange()
        {
            switch (_thisStorageType)
            {
                case StorageType.BayeganStorage:
                    _thisStorageType = StorageType.PlayerPrefsStorage;
                    break;
                case StorageType.PlayerPrefsStorage:
                    _thisStorageType = StorageType.BayeganStorage;
                    break;
            }

            Debug.Log(_thisStorageType);
            _storageChangeText.text = _thisStorageType.ToString();

            _signalBus.Fire(new StorageChangeSignal
            {
                StorageSetting = new StorageSetting
                {
                    RepositoryType = _thisStorageType
                }
            });
        }
    }
}