using System;
using System.Linq;
using _Scripts.Timber_Man.Models.Branchs;
using _Scripts.Timber_Man.Models.Branchs.Abstraction;
using _Scripts.Timber_Man.Models.Enums;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Scripts.Timber_Man.Pools
{
    public class BranchPool
    {
        private IBranchPooling[] _branchPoolings;

        public BranchPool(IBranchPooling[] branchPoolings)
        {
            _branchPoolings = branchPoolings;
        }

        public BaseBranch OnSpawned(Vector2 position, BranchType? branchType = null)
        {
            if (branchType.HasValue)
            {
                var thisBranchPool = _branchPoolings.FirstOrDefault(f => f.Type == branchType.Value);
                if (thisBranchPool == null)
                {
                    throw new Exception($"no memorypool found Type {branchType} for Spawning");
                }

                return thisBranchPool.Spawn(position);
            }

            var index = Random.Range(0, _branchPoolings.Length);
            var randomBranch = _branchPoolings[index];
            return randomBranch.Spawn(position);
        }

        public void OnDespawn(BaseBranch baseBranch)
        {
            var thisBranch = _branchPoolings.FirstOrDefault(f => f.ClassType == baseBranch.GetType());
            if (thisBranch == null)
            {
                throw new Exception($"no memorypool found Type {baseBranch.Type} for destroying");
            }

            thisBranch.Despawn(baseBranch, new Vector2(0, 0));
        }
    }

    public interface IBranchPooling
    {
        BranchType Type { get; }

        Type ClassType { get; }

        BaseBranch Spawn(Vector2 position);

        void Despawn(BaseBranch baseEnemy, Vector2 position);
    }

    public abstract class BaseBranchPool<T> : MonoMemoryPool<T>, IBranchPooling where T : BaseBranch
    {
        public abstract BranchType Type { get; }
        public Type ClassType => typeof(T);

        public T BranchSpawn(Vector2 position)
        {
            var baseBranch = Spawn();
            baseBranch.transform.position = position;

            return baseBranch;
        }

        public BaseBranch Spawn(Vector2 position)
        {
            return BranchSpawn(position);
        }

        public void Despawn(BaseBranch baseEnemy, Vector2 position)
        {
            baseEnemy.transform.position = position;
            Despawn((T)baseEnemy);
        }
    }

    public class LeftBranchPool : BaseBranchPool<LeftBranch>
    {
        public override BranchType Type => BranchType.BranchLeft;
    }

    public class RightBranchPool : BaseBranchPool<RightBranch>
    {
        public override BranchType Type => BranchType.BranchRight;
    }

    public class NoBranchPools : BaseBranchPool<NoBranch>
    {
        public override BranchType Type => BranchType.NoBranch;
    }
}