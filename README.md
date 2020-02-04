# BlockchainWalletSharp
An unofficial C# library to interact with the Blockchain.info Wallet API V2.

## Documentation
Example code for initializing a `BlockchainWallet` instance
```cs
var blockchainWallet = new BlockchainWallet(new HttpClient(), new BlockchainWalletConfiguration
{
    Host = "http://localhost:3000",
    Identifier = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    Password = "xXxXxXxXxXxXxXxX"
});
```

Example code for sending a payment
```cs
var recipients = new Dictionary<string, long>
{
    { "1LaiteuxHEH4GsMC9aVmnwgUEZyrG6BiTH", 1337 }
};

var payment = await blockchainWallet.PaymentAsync(recipients, feePerByte: 50);

if (payment.Success)
{
    Console.WriteLine($"Payment successfully sent! TXID: {payment.TXID}");
}
else
{
    Console.WriteLine("An error occured while sending payment ...");
}
```

## Contribution
Your help is welcome, feel free to fork this repo and submit pull requests.

However, make sure to follow the current code base/style.

## Donation
If you would like to support this project, please consider donating. Thank you!

- Bitcoin: `1LaiteuxHEH4GsMC9aVmnwgUEZyrG6BiTH`

- Ethereum: `0xC500a6777dB9948c257e7841a987027D5E5d0E5B`

## Contact
Telegram: [@Laiteux](https://t.me/Laiteux)

Instagram: [@eagle](https://instagr.am/eagle)

Email: matt@laiteux.dev

## License
This code is licensed under the MIT License.

## To-Do
- [ ] Handle Blockchain API errors & exceptions
- [ ] Switch to POST requests
