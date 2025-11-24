using _Scripts.Timber_Man.Models.Enums;

namespace _Scripts.Timber_Man.Helpers
{
    public static class BranchHelper
    {
        public static bool IsPlayerAlive(PlayerState playerState, BranchType branchType)
        {
            return (int)playerState != (int)branchType;
        }
    }
}