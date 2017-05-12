# NBitcoin.Viacoin

This project allows NBitcoin to support Viacoin.
To register Viacoin extensions, run:

```
NBitcoin.Viacoin.Networks.Register();
```

You can then use NBitcoin with `NBitcoin.Viacoin.Networks.Mainnet` or `NBitcoin.Viacoin.Networks.Testnet`.
Alternatively you can use `NBitcoin.Network.GetNetwork("via-main")` to get the Network object.
You can then start using Viacoin in the same way you do with Bitcoin.
