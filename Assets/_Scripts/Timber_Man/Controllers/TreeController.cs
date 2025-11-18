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

        private List<BaseBranch> _branch_that_make_tree;

        private void Start()
        {
            _branch_that_make_tree = new List<BaseBranch>();

            for (int i = 0; i < 5; i++)
            {
                _branch_that_make_tree.Add(_branchPool.OnSpawned(new Vector2(0, i * 2), BranchType.NoBranch));
            }
        }

        public void Branch_Cuted(PlayerState playerState)
        {
            if (_branch_that_make_tree.Count == 0)
                return;

            var branch = _branch_that_make_tree[0];

            branch.Branch_Destroy();
            _branchPool.OnDespawn(branch);

            _branch_that_make_tree.RemoveAt(0);

            foreach (var b in _branch_that_make_tree)
            {
                b.MoveDown();
            }
        }


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (var branch in _branch_that_make_tree)
                {
                    branch.MoveDown();
                }
            }
        }
    }
}