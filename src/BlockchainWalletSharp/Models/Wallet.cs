namespace BlockchainWalletSharp.Models
{
    public class Wallet
    {
        /// <summary>
        ///     Blockchain Wallet Service host address (required)
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        ///     Wallet identifier (GUID) (required)
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///     Main wallet password (required)
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Second wallet password (required, only if second password is enabled)
        /// </summary>
        public string SecondPassword { get; set; }

        /// <summary>
        ///     Blockchain.info wallet API code (optional)
        /// </summary>
        public string ApiCode { get; set; }
    }
}
