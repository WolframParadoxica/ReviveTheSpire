using BaseLib.Abstracts;
using BaseLib.Extensions;
using ReviveTheSpire.ReviveTheSpireCode.Extensions;
using Godot;

namespace ReviveTheSpire.ReviveTheSpireCode.Powers;

public abstract class ReviveTheSpirePower : CustomPowerModel
{
    //Loads from ReviveTheSpire/images/powers/your_power.png
    public override string CustomPackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
    public override string CustomBigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
}