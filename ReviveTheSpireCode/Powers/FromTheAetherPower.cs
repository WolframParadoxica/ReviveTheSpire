using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace ReviveTheSpire.ReviveTheSpireCode.Powers;

public sealed class FromTheAetherPower : ReviveTheSpirePower
{
  public override PowerType Type => PowerType.Buff;

  public override PowerStackType StackType => PowerStackType.Counter;

  public override async Task AfterCardGeneratedForCombat(CardModel card, Player? creator)
  {
    if (creator is null || creator.Creature != Owner) return;
    Flash();
    await CardPileCmd.Draw(new BlockingPlayerChoiceContext(), Amount, Owner.Player!);
  }
}