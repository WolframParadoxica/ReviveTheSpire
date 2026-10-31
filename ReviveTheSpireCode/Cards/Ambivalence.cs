using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.CardPools;
using ReviveTheSpire.ReviveTheSpireCode.Powers;

namespace ReviveTheSpire.ReviveTheSpireCode.Cards;

[Pool(typeof(RegentCardPool))]
public class Ambivalence() : ReviveTheSpireCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(1), new PowerVar<AmbivalencePower>(1M)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<AmbivalencePower>(choiceContext, Owner.Creature, DynamicVars.Power<AmbivalencePower>().BaseValue, Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Cards.UpgradeValueBy(1M);
        DynamicVars.Power<AmbivalencePower>().UpgradeValueBy(1);
    }
}