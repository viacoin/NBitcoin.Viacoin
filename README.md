# NBitcoin.Viacoin

<img src="http://segwit.co/static/public/images/logo.png" width="100">

This project allows NBitcoin to support Viacoin.
NBitcoin.Viacoin is Viacoin libraty for the .NET platform. It implements all most relevant Bitcoin
Improvement Proposals (BIPs). It provides also low level access to Viacoin primitives so you can easily build
your application on top of it.

To register Viacoin extensions, run:

```
NBitcoin.Viacoin.Networks.Register();
```

You can then use NBitcoin with `NBitcoin.Viacoin.Networks.Mainnet` or `NBitcoin.Viacoin.Networks.Testnet`.
Alternatively you can use `NBitcoin.Network.GetNetwork("via-main")` to get the Network object.
You can then start using Viacoin in the same way you do with Bitcoin.


