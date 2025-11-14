using _Scripts.Timber_Man.Models.Branchs.Abstraction;
using _Scripts.Timber_Man.Models.Enums;

namespace _Scripts.Timber_Man.Models.Branchs
{
    public class RightBranch : BaseBranch
    {
        public override BranchType Type => BranchType.BranchRight;

        public override void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}