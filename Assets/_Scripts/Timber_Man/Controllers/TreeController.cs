using System;
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

        private Queue<BaseBranch> _branch_that_make_tree;

        private void Start()
        {
            _branch_that_make_tree = new Queue<BaseBranch>();

            for (int i = 0; i < 5; i++)
            {
                _branch_that_make_tree.Enqueue(_branchPool.OnSpawned(new Vector2(0, i * 2), BranchType.NoBranch));
            }
        }

        public void Branch_Cuted(PlayerState playerState)
        {
            if (_branch_that_make_tree.Count == 0)
                return;

            var branch = _branch_that_make_tree.Dequeue();

            branch.Branch_Destroy(playerState,(() => {_branchPool.OnDespawn(branch);}));

            foreach (var b in _branch_that_make_tree)
            {
                b.MoveDown();
            }

            var newBranch = _branchPool.OnSpawned(new Vector2(0, _branch_that_make_tree.Count * 2));
            _branch_that_make_tree.Enqueue(newBranch);
        }
    }
}