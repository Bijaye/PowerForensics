﻿using System;

namespace PowerForensics.Ntfs
{
    class NonResidentHeader
    {
        #region Properties

        internal CommonHeader commonHeader;
        internal ulong StartVCN;		        // Starting VCN
        internal ulong LastVCN;		            // Last VCN
        internal ushort DataRunOffset;	        // Offset to the Data Runs
        internal ushort CompUnitSize;	        // Compression unit size
        internal readonly ulong AllocatedSize;    // Allocated size of the attribute
        internal readonly ulong RealSize;         // Real size of the attribute
        internal readonly ulong InitializedSize;  // Initialized data size of the stream 

        #endregion Properties

        #region Constructors

        internal NonResidentHeader(byte[] bytes, CommonHeader common)
        {
            commonHeader = common;
            StartVCN = BitConverter.ToUInt64(bytes, 0x00);
            LastVCN = BitConverter.ToUInt64(bytes, 0x08);
            DataRunOffset = BitConverter.ToUInt16(bytes, 0x10);
            CompUnitSize = BitConverter.ToUInt16(bytes, 0x12);
            AllocatedSize = BitConverter.ToUInt64(bytes, 0x18);
            RealSize = BitConverter.ToUInt64(bytes, 0x20);
            InitializedSize = BitConverter.ToUInt64(bytes, 0x28);
        }

        internal NonResidentHeader(byte[] bytes, CommonHeader common, int offset)
        {
            commonHeader = common;
            StartVCN = BitConverter.ToUInt64(bytes, 0x00 + offset);
            LastVCN = BitConverter.ToUInt64(bytes, 0x08 + offset);
            DataRunOffset = BitConverter.ToUInt16(bytes, 0x10 + offset);
            CompUnitSize = BitConverter.ToUInt16(bytes, 0x12 + offset);
            AllocatedSize = BitConverter.ToUInt64(bytes, 0x18 + offset);
            RealSize = BitConverter.ToUInt64(bytes, 0x20 + offset);
            InitializedSize = BitConverter.ToUInt64(bytes, 0x28 + offset);
        }

        #endregion Constructors
    }
}