using _Scripts.Timber_Man.Behaviour.HitBehaviour.abstraction;
using _Scripts.Timber_Man.Signals.Players;
using Zenject;

namespace _Scripts.Timber_Man.Behaviour.HitBehaviour
{
    public class PlayerHit : BaseHit
    {
        [Inject] private readonly SignalBus _signalBus;
        
        public override void Damage()
        {
            _signalBus.Fire(new PlayerDied());
        }
    }
}