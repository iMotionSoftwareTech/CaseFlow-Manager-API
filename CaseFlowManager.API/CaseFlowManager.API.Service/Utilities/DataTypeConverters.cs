namespace CaseFlowManager.API.Service.Utilities
{
    /// <summary>
    /// The DataTypeConverters
    /// </summary>
    public static class DataTypeConverters
    {
        /// <summary>
        /// Variables the binary string to bytes.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns>The <see cref="byte"</returns>
        public static byte[] VarBinaryStringToBytes(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return Array.Empty<byte>();

            // Remove leading "0x"
            if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                hex = hex[2..];

            int byteCount = hex.Length / 2;
            byte[] bytes = new byte[byteCount];

            for (int i = 0; i < byteCount; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);

            return bytes;
        }
    }
}