using System;
using _Scripts.Timber_Man.Pools;
using UnityEngine;
using Zenject;

namespace _Scripts.Timber_Man.Controllers
{
    public class TreeController : MonoBehaviour
    {
        [Inject] private readonly BranchPool _branchPool;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var branch = _branchPool.OnSpawned(new Vector2());
                Debug.Log(branch.name);
            }
        }
    }
}