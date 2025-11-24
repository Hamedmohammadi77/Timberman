using System.Collections.Generic;
using _Scripts.Timber_Man.Models.Branchs.Abstraction;
using _Scripts.Timber_Man.Models.Enums;
using _Scripts.Timber_Man.Pools;
using UnityEngine;
using Zenject;

namespace _Scripts.Timber_Man.Controllers
{
    public class TreeController : MonoBehaviour
    {
        [Inject] private readonly BranchPool _branchPool;

        private Queue<BaseBranch> _branchThatMakeTree;

        private void Start()
        {
            _branchThatMakeTree = new Queue<BaseBranch>();

            for (int i = 0; i < 5; i++)
            {
                _branchThatMakeTree.Enqueue(_branchPool.OnSpawned(new Vector2(0, i * 2), BranchType.NoBranch));
            }
        }

        public void BranchCut(PlayerState playerState)
        {
            if (_branchThatMakeTree.Count == 0)
                return;

            var branch = _branchThatMakeTree.Dequeue();

            branch.BranchDestroy(playerState, () => { _branchPool.OnDespawn(branch); });

            foreach (var b in _branchThatMakeTree)
            {
                b.MoveDown();
            }

            var newBranch = _branchPool.OnSpawned(new Vector2(0, _branchThatMakeTree.Count * 2));
            _branchThatMakeTree.Enqueue(newBranch);
        }
    }
}