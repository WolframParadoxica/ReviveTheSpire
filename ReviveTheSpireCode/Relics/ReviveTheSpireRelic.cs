using BaseLib.Abstracts;
using BaseLib.Extensions;
using ReviveTheSpire.ReviveTheSpireCode.Extensions;
using Godot;

namespace ReviveTheSpire.ReviveTheSpireCode.Relics;

public abstract class ReviveTheSpireRelic : CustomRelicModel
{
    //ReviveTheSpire/images/relics
    public override string PackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".RelicImagePath();

    protected override string PackedIconOutlinePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}_outline.png".RelicImagePath();

    protected override string BigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigRelicImagePath();
}