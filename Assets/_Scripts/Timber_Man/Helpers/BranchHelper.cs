using System;
using _Scripts.Timber_Man.Models.Enums;
using UnityEngine;

namespace _Scripts.Timber_Man.Helpers
{
    public static class BranchHelper
    {
        public static bool IsPlayerAlive(PlayerState playerState, BranchType branchType)
        {
            Debug.Log($"{(int)playerState} ,,,{(int)branchType}");
            return (int)playerState != (int)branchType;
        }

        public static bool IsFarzad(string text)
        {
            return text.Equals("farzad", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}