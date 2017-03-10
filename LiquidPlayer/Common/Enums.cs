﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace LiquidPlayer
{
    // Enums.cs
    // Version 0.01
    // 2016-12-20

    // --------------------------------------------------------------------------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Explicit)]
    public struct SmartPointer
    {
        [FieldOffset(0)]
        public long Address;

        [FieldOffset(0)]
        public int LoAddress;
        [FieldOffset(4)]
        public int HiAddress;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct LiquidType
    {
        [FieldOffset(0)]
        public LiquidClass Class;
        [FieldOffset(4)]
        public LiquidClass Subclass;

        [FieldOffset(0)]
        public long Combo;

        public LiquidType(LiquidClass liquidClass, LiquidClass liquidSubclass = LiquidClass.None)
        {
            this.Combo = 0L;

            this.Class = liquidClass;
            this.Subclass = liquidSubclass;
        }
    }

    public delegate bool FunctionDelegate(LiquidClass liquidClass, int id, int[] stack, int sp, ref int a0, ref SmartPointer bx, ref long c0, ref double d0);

    #region AccessModifier enums
    public enum AccessModifier
    {
        None,
        Private,
        Protected,
        Public
    }
    #endregion

    #region LiquidClass enums
    public enum LiquidClass
    {
        None,

        Object,
        Message,
        Exception,
        Collection,
        Array,
        Matrix,
        Dictionary,
        Stack,
        Queue,
        List,
//      Tree,
        CommandLine,
//      Memory,                 // Databank?
        FileSystem,
        File,
        Internet,
        Stream,
        DataStream,
        FileStream,
        Pipe,
        TextReader,
        TextWriter,
        Keyboard,
        Mouse,
        Ortho,
        Perspective,
        Entity,
        GEL,
        GEL3D,
        Task,
        Program,
        App,
        Applet,
        Clock,
        Math,
        Random,
        RegularExpression,
        Color,
//      Palette,                // Color Array (e.g. C=64, Amiga, etc.)
        Bitmap,
        Image,
        Texture,
        Banner,
        Brush,
        Pen,
        Turtle,
        Filter,
        Font,
        CharacterSet,
        MonoSpacedFont,
//      WindowsFont,
        View,
        Console,
        TileMap,
        CopperBars,
        Canvas,
        FBO,
        FBO3D,
        Sprite,
        Text,
        Layer,
        Audio,
        Sound,
        Music,
        Voice,

        Null = -1,
        Subclass = -2,
        Boolean = -3,
        Byte = -4,
        Short = -5,
        Int = -6,
        Long = -7,
        Float = -8,
        Double = -9,
        Char = -10,
        String = -11
    }
    #endregion

    #region pCode enums
    public enum pCode
    {
        Halt,
        Info,
        IRQ,
        BufferA0,
        BufferD0Float,
        Unbuffer,
        Alloc,
        DecrSP,
        PackBX,
        UnpackBX,
        Unused,
        PointGlobal,
        PointMacro,
        PointBP,
        PointSP,
        PointMicro,
        PointBX,
        BFree,
        BFreeA1,
        Iterator,
        This,
        Task,
        New,
        Hook,
        Copy,
        Adopt,
        Assign,
        Free,
        FreeA1,
        FreeOnErr,
        ClassA0,
        ConstA0,
        ConstA1,
        LoadA0,
        LoadA1,
        Boolean,
        StoreA0,
        StoreA1,
        MoveA0A1,
        MoveA1A0,
        PushA0,
        PushA1,
        PopA0,
        PopA1,
        MoveA0D0,
        MoveA1D1,
        NotUsed,
        NegA0,
        NegA1,
        NotA0,
        NotA1,
        IncA0,
        IncA1,
        DecA0,
        DecA1,
        Abs,
        Sgn,
        Add,
        Sub,
        Mod,
        Mult,
        Div,
        Power,
        Shl,
        Shr,
        ShlConst,
        ShrConst,
        Equal,
        NotEqual,
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        And,
        Or,
        Xor,
        LNot,
        LAnd,
        LOr,
        LXor,
        DConstD0Float,
        DConstD1Float,
        DLoadD0Float,
        DLoadD0Int,
        DLoadD1Float,
        DLoadD1Int,
        DStoreD0Float,
        DStoreD1Float,
        MoveD0D1,
        MoveD1D0,
        DPushD0Float,
        DPushD1Float,
        DPopD0Float,
        DPopD1Float,
        MoveD0A0,
        MoveD1A1,
        DNegD0,
        DNegD1,
        DIncD0,
        DIncD1,
        DDecD0,
        DDecD1,
        DInt,
        DAbs,
        DSgn,
        DVal,
        DFrac,
        DCeil,
        DFix,
        DRound,
        DTan,
        DAtn,
        DCos,
        DSin,
        DExp,
        DExp2,
        DExp10,
        DLog,
        DLog2,
        DLog10,
        DSqr,
        DAdd,
        DSub,
        DMod,
        DMult,
        DDiv,
        DPower,
        DEqual,
        DNotEqual,
        DLess,
        DLessEqual,
        DGreater,
        DGreaterEqual,
        WConstA0,
        WConstA1,
        WCloneA0,
        WCloneA1,
        WJoin,
        WStrA0,
        WStrD0Float,
        WHook,
        WAssign,
        WFree,
        WFreeA1,
        WEqual,
        WNotEqual,
        WLess,
        WGreater,
        Jump,
        JumpFalse,
        JumpTrue,
        JumpIteratorEnd,
        Gosub,
        Return,
        Native,
        Call,
        VTable,
        NativeClass,
        WaitClass,
        CallClass,
        VTableClass,
        API,
        EndFunc,
        Throw,
        Byte,
        ByteA1,
        Short,
        ShortA1,
        BufferC0,
        MoveA0C0,
        MoveA1C1,
        MoveC0A0,
        MoveC1A1,
        MoveD0C0,
        MoveD1C1,
        MoveC0D0,
        MoveC1D1,
        MoveC0C1,
        MoveC1C0,
        WStrC0,
        QPack,
        QUnpack,
        QConstC0,
        QConstC1,
        QLoadC0,
        QLoadC0Int,
        QLoadC1,
        QLoadC1Int,
        QPushC0,
        QPushC1,
        QPopC0,
        QPopC1,
        QNegC0,
        QNegC1,
        QNotC0,
        QNotC1,
        QIncC0,
        QIncC1,
        QDecC0,
        QDecC1,
        QAbs,
        QSgn,
        QAdd,
        QSub,
        QMod,
        QMult,
        QDiv,
        QPower,
        QShl,
        QShr,
        QShlConst,
        QShrConst,
        QEqual,
        QNotEqual,
        QLess,
        QLessEqual,
        QGreater,
        QGreaterEqual,
        QAnd,
        QOr,
        QXor,
        QAssign,
        QFree,
        QFreeA1,
        QBoolean,
        QByte,
        QShort,
        QInt,
        BufferD0,
        WStrD0,
        DPack,
        DUnpack,
        DConstD0,
        DConstD1,
        DLoadD0,
        DLoadD0Int64,
        DLoadD1,
        DLoadD1Int64,
        DPushD0,
        DPushD1,
        DPopD0,
        DPopD1,
        DAssign,
        DFree,
        DFreeA1,
        XChg,

        None = 0
    }
    #endregion
}
