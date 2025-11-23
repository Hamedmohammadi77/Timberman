using _Scripts.Timber_Man.Models.Branchs.Abstraction;
using _Scripts.Timber_Man.Models.Enums;

namespace _Scripts.Timber_Man.Models.Branchs
{
    public class NoBranch : BaseBranch
    {
        public override BranchType Type => BranchType.NoBranch;
    }
}