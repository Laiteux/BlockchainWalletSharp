# BlockchainWalletSharp [![Latest release](https://img.shields.io/github/v/release/Laiteux/BlockchainWalletSharp?color=blue&style=flat-square)](https://github.com/Laiteux/BlockchainWalletSharp/releases) [![License](https://img.shields.io/github/license/Laiteux/BlockchainWalletSharp?color=blue&style=flat-square)](https://github.com/Laiteux/BlockchainWalletSharp/blob/master/LICENSE)

An unofficial asynchronous .NET Core library for interacting with the [Blockchain.info Wallet API V2](https://github.com/blockchain/service-my-wallet-v3).

## How to use

Example code for instancing a `BlockchainWallet`:
```cs
var blockchainWallet = new BlockchainWallet(new BlockchainWalletConfiguration()
{
    Host = "http://localhost:3000",
    Identifier = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    Password = "xXxXxXxXxXxXxXxX"
});
```

Example code for sending a payment:
```cs
var recipients = new Dictionary<string, long>()
{
    { "1LaiteuxHEH4GsMC9aVmnwgUEZyrG6BiTH", 1337 }
};

var payment = await blockchainWallet.SendPaymentAsync(recipients, feePerByte: 50);

if (payment.Success)
{
    Console.WriteLine($"Payment sent: {payment.TXID}");
}
else
{
    Console.WriteLine("An error occurred while sending the payment.");
}
```

## Contribute

Your help and ideas are welcome, feel free to fork this repo and submit a pull request.

However, please make sure to follow the current code base/style.

## Contact

Telegram: [@Matty](https://t.me/Matty)

Email: matt@laiteux.dev

## Donate

If you would like to support this project, please consider donating.

Donations are greatly appreciated and a motivation to keep improving.

- Bitcoin: `1LaiteuxHEH4GsMC9aVmnwgUEZyrG6BiTH`

## TODO
- [ ] Switch to POST requests or then use [Flurl](https://github.com/tmenier/Flurl)
- [ ] Handle Blockchain API errors & exceptions
