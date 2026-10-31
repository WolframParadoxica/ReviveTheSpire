using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using ReviveTheSpire.ReviveTheSpireCode.Cards;
using ReviveTheSpire.ReviveTheSpireCode.Extensions;

namespace ReviveTheSpire.ReviveTheSpireCode.Powers;

public class DisarmedPower : TemporaryStrengthPower, ICustomPower
{
    public override AbstractModel OriginModel => ModelDb.Card<Disarm>();
    
    public string CustomPackedIconPath => "disarmed_power.png".PowerImagePath();
    public string CustomBigIconPath => "disarmed_power.png".BigPowerImagePath();

    protected override bool IsPositive => false;
}