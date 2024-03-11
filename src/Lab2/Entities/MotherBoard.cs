using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoard : DetailBase
{
    public MotherBoard(
        string name,
        Socket socket,
        int pcieLinesAmount,
        int sataPortsAmount,
        ChipSet chipSet,
        StandardDdr standardDdr,
        int ramSlotsAmount,
        MotherBoardFormFactor motherBoardFormFactor,
        Bios bios,
        XmpProfile? xmpProfile = null)
        : base(name)
    {
        Socket = socket;
        PcieLinesAmount = pcieLinesAmount;
        SataPortsAmount = sataPortsAmount;
        ChipSet = chipSet;
        StandardDdr = standardDdr;
        RamSlotsAmount = ramSlotsAmount;
        MotherBoardFormFactor = motherBoardFormFactor;
        Bios = bios;
        XmpProfile = xmpProfile;
    }

    public Socket Socket { get; }
    public int PcieLinesAmount { get; }
    public int SataPortsAmount { get; }
    public ChipSet ChipSet { get; }
    public StandardDdr StandardDdr { get; }
    public int RamSlotsAmount { get; }
    public MotherBoardFormFactor MotherBoardFormFactor { get; }
    public Bios Bios { get; }

    public XmpProfile? XmpProfile { get; set; }

    public double GetHeightFromFormFactor =>
        MotherBoardFormFactor switch
        {
            MotherBoardFormFactor.ATX or MotherBoardFormFactor.EATX => 305,
            MotherBoardFormFactor.MiniATX => 284,
            MotherBoardFormFactor.MicroATX => 244,
            _ => 170,
        };

    public double GetWidthFromFormFactor =>
        MotherBoardFormFactor switch
        {
            MotherBoardFormFactor.EATX => 330,
            MotherBoardFormFactor.ATX or MotherBoardFormFactor.MicroATX => 244,
            MotherBoardFormFactor.MiniATX => 208,
            _ => 170,
        };
}