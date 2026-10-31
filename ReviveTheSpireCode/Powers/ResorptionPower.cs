using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models;
using ReviveTheSpire.ReviveTheSpireCode.Cards;

namespace ReviveTheSpire.ReviveTheSpireCode.Powers;

public sealed class ResorptionPower : ReviveTheSpirePower
{
  public override PowerType Type => PowerType.Buff;

  public override PowerStackType StackType => PowerStackType.Counter;

  protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.Static(StaticHoverTip.SummonStatic),HoverTipFactory.Static(StaticHoverTip.Block)];

  public override async Task AfterDeath(PlayerChoiceContext choiceContext, Creature creature, bool wasRemovalPrevented, float deathAnimLength)
  {
    if (wasRemovalPrevented) return;
    Flash();
    await PowerCmd.Apply<GrowthSpurtPower>(new BlockingPlayerChoiceContext(), Owner, Amount, Owner, ModelDb.Card<Resorption>());
  }
}