using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Models.Branchs.Abstraction;

namespace _Scripts.Timber_Man.Models.Branchs
{
    public class RightBranch : BaseBranch
    {
        public override BranchType Type => BranchType.BranchRight;
    }
}