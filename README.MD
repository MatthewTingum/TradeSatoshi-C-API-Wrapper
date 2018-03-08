<h1>TradeSatoshi C# API Wrapper</h1>

This solution contains both a TradeSatoshi API Wrapper library and a program to test the library. The wrapper supports both public and private endpoints.


## Getting Started

0. Enable API usage on your TradeSatoshi account.
1. Build the TradeSatoshi library. 
2. Add a reference to either the API Wrapper project or the compiled library.
3. Create a `TradeSatoshiAPI.TradeSatoshi` object using your `API Key` and `API Secret`.
4. Use the `TradeSatoshi` object to make API calls.


## Warning

Use the API Wrapper Libary and Test program at your own risk. Look at the code and understand what it is doing before using any part of this project. Consider the risks of undiscovered bugs. What if a parameter is incorrectly passed to the API? The test program contains actual examples of using the TradeSatoshi API to place buy and sell orders. Using the test program could place orders on your account if used as is. This project is not affiliated with TradeSatoshi.

## Undocumented API

Includes `GetTradePairChart` API to get candle data. This endpoint is not publicly documented. TradePairID's still need to be documented. For documentation purposes only. Don't use this.

Thanks to `elcattivo` for the [CloudFlare bypass](https://github.com/elcattivo/CloudFlareUtilities)
