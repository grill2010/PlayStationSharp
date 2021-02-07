namespace PlayStationSharp.TestApp
{
    class ByteUtil
    {
        public static byte[] ToLittleEndian(long data)
        {
            byte[] b = new byte[8];
            b[0] = (byte)data;
            b[1] = (byte)(((ulong)data >> 8) & 0xFF);
            b[2] = (byte)(((ulong)data >> 16) & 0xFF);
            b[3] = (byte)(((ulong)data >> 24) & 0xFF);
            b[4] = (byte)(((ulong)data >> 32) & 0xFF);
            b[5] = (byte)(((ulong)data >> 40) & 0xFF);
            b[6] = (byte)(((ulong)data >> 48) & 0xFF);
            b[7] = (byte)(((ulong)data >> 56) & 0xFF);
            return b;
        }
    }
}
