using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.RelicPools;

namespace Spire1Revamped.Spire1RevampedCode.Relics;

[Pool(typeof(EventRelicPool))]
public class Monocle : Spire1RevampedRelic
{
    public override RelicRarity Rarity => RelicRarity.Ancient;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new EnergyVar(1)];

    private static bool _isBlockingCostSwap;

    public override bool TryModifyEnergyCostInCombatLate(CardModel card, decimal originalCost, out decimal modifiedCost)
    {
        modifiedCost = originalCost;
        if (_isBlockingCostSwap || card.Owner != Owner || originalCost <= 0M || !HasPositiveEnergyCostWithoutSwap(card)) return false;

        modifiedCost = originalCost - 1M;
        if (modifiedCost < 0M) modifiedCost = 0M;
        return true;
    }

    public override bool TryModifyStarCost(CardModel card, decimal originalCost, out decimal modifiedCost)
    {
        modifiedCost = originalCost;
        if (_isBlockingCostSwap || card.Owner != Owner || card.HasStarCostX || !HasPositiveEnergyCostWithoutSwap(card)) return false;

        modifiedCost = originalCost < 0M ? originalCost + 2M : originalCost + 1M;
        return true;
    }

    private static bool HasPositiveEnergyCostWithoutSwap(CardModel card)
    {
        if (_isBlockingCostSwap) return false;

        var previousValue = _isBlockingCostSwap;
        _isBlockingCostSwap = true;
        try
        {
            return card.EnergyCost.GetWithModifiers(CostModifiers.All) > 0M;
        }
        finally
        {
            _isBlockingCostSwap = previousValue;
        }
    }
}