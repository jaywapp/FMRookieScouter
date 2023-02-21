using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMRookyScouter
{
    public enum ePosition
    {
        ST,
        AMR,
        AML,
        AMC
    }

    public enum eFoot
    {
        Right,
        Left,
        Both,
    }

    public enum eRole
    {
        [Simply("G")]
        GoalKeeper,
        [Simply("SK")]
        SweeperKeeper,
        [Simply("CD")]
        CentralDefender,
        [Simply("L")]
        Libero,
        [Simply("BPD")]
        BallPlayingDefender,
        [Simply("NCB")]
        NoNonsenseCentreBack,
        [Simply("WCB")]
        WideCentreBack,
        [Simply("DM")]
        DefensiveMidfielder,
        [Simply("DLP")]
        DeepLyingPlaymaker,
        [Simply("BWM")]
        BallWinningMidfielder,
        [Simply("A")]
        AnchorMan,
        [Simply("HB")]
        HalfBack,
        [Simply("RGA")]
        Regista,
        [Simply("RPM")]
        RoamingPlaymaker,
        [Simply("VOL")]
        SegundoVolante,
        [Simply("CM")]
        CentralMidfielder,
        [Simply("BBM")]
        BoxToBoxMidfielder,
        [Simply("MEZ")]
        Mezzala,
        [Simply("CAR")]
        Carrilero,
        [Simply("FB")]
        FullBack,
        [Simply("WB")]
        WingBack,
        [Simply("NFB")]
        NoNonsenseFullBack,
        [Simply("CWB")]
        CompleteWingBack,
        [Simply("IWB")]
        InvertedWingBack,
        [Simply("WM")]
        WideMidfielder,
        [Simply("W")]
        Winger,
        [Simply("DW")]
        DefensiveWinger,
        [Simply("WP")]
        WidePlaymaker,
        [Simply("IW")]
        InvertedWinger,
        [Simply("IF")]
        InsideForward,
        [Simply("WT")]
        WideTargetForward,
        [Simply("RMD")]
        Raumdeuter,
        [Simply("AM")]
        AttackingMidfielder,
        [Simply("AP")]
        AdvancedPlaymaker,
        [Simply("T")]
        Trequartista,
        [Simply("EG")]
        Enganche,
        [Simply("SS")]
        ShadowStriker,
        [Simply("DLF")]
        DeepLyingForward,
        [Simply("AF")]
        AdvancedForward,
        [Simply("TF")]
        TargetForward,
        [Simply("P")]
        Poacher,
        [Simply("CF")]
        CompleteForward,
        [Simply("PF")]
        PressingForward,
        [Simply("F9")]
        FalseNine,
    }
}
