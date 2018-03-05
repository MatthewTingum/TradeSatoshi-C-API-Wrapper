using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSatoshiAPI;
using TradeSatoshiAPI.Entities;
using TradeSatoshiAPI.Enum;

namespace TradeSatoshiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "YourApiKey";
            string apiSecret = "yourApiSecret";
            TradeSatoshi tradeSatoshi = new TradeSatoshi("https://tradesatoshi.com/", apiKey, apiSecret);

            while (true)
            {

                // User Prompt
                Console.WriteLine("TradeSatoshi API Demo");
                Console.WriteLine("\t1: \\GetCurrencies");
                Console.WriteLine("\t2: \\GetTicker");
                Console.WriteLine("\t3: \\GetMarketHistory");
                Console.WriteLine("\t4: \\GetMarketSummary");
                Console.WriteLine("\t5: \\GetMarketSummaries");
                Console.WriteLine("\t6: \\GetOrderBook");
                Console.WriteLine("\t7: \\GetBalance");
                Console.WriteLine("\t8: \\GetBalances");
                Console.WriteLine("\t9: \\GetOrder");
                Console.WriteLine("\t10: \\GetOrders");
                Console.WriteLine("\t11: \\SubmitOrder");
                Console.WriteLine("\t12: \\CancelOrder");
                Console.WriteLine("\t13: \\GetTradeHistory");
                Console.WriteLine("\t14: \\GenerateAddress");
                Console.WriteLine("\t15: \\SubmitWithdraw");
                Console.WriteLine("\t16: \\GetDeposits");
                Console.WriteLine("\t17: \\GetWithdrawls");
                Console.WriteLine("\t18: \\SubmitTransfer");
                Console.Write("\n\tOption: ");
                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":   // GetCurrencies

                        CurrencyList[] currencyList = new CurrencyList[] { };

                        try
                        {
                            currencyList = tradeSatoshi.GetCurrencyList().Result;
                            Console.WriteLine(@"\GetCurrencies");
                            foreach (CurrencyList currency in currencyList)
                            {
                                Console.WriteLine(String.Format("\t\tCurrency:\t\t{0}", currency.Currency));
                                Console.WriteLine(String.Format("\t\tCurrencyLong:\t\t{0}", currency.CurrencyLong));
                                Console.WriteLine(String.Format("\t\tMinConfirmation:\t{0}", currency.MinConfirmation));
                                Console.WriteLine(String.Format("\t\ttxFee:\t\t\t{0}", currency.TxFee));
                                Console.WriteLine(String.Format("\t\tStatus:\t\t\t{0}", currency.Status));
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "2":   // GetTicker

                        Ticker ticker = new Ticker();

                        try
                        {
                            ticker = tradeSatoshi.GetTicker("ZCL", TradingPair.BTC).Result;
                            Console.WriteLine(@"\GetTicker");
                            Console.WriteLine(String.Format("\t\tBid:\t{0}", ticker.Bid));
                            Console.WriteLine(String.Format("\t\tAsk:\t{0}", ticker.Ask));
                            Console.WriteLine(String.Format("\t\tLast:\t{0}", ticker.Last));
                            Console.WriteLine(String.Format("\t\tMarket:\t{0}", ticker.Market));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "3":   // GetMarketHistory

                        MarketHistory[] marketHistory = new MarketHistory[] { };

                        try
                        {
                            marketHistory = tradeSatoshi.GetMarketHistory("ZCL", TradingPair.BTC, 5).Result;
                            Console.WriteLine(@"\GetMarketHistory");
                            foreach (MarketHistory history in marketHistory)
                            {
                                Console.WriteLine(String.Format("\t\tID:\t\t{0}", history.Id));
                                Console.WriteLine(String.Format("\t\tTimeStamp:\t{0}", history.TimeStamp));
                                Console.WriteLine(String.Format("\t\tQuantity:\t{0}", history.Quantity));
                                Console.WriteLine(String.Format("\t\tPrice:\t\t{0}", history.Price));
                                Console.WriteLine(String.Format("\t\tOrderType:\t{0}", history.OrderType));
                                Console.WriteLine(String.Format("\t\tTotal:\t\t{0}", history.Total));
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        break;

                    case "4":   // GetMarketSummary

                        MarketSummary marketSummary = new MarketSummary();

                        try
                        {
                            marketSummary = tradeSatoshi.GetMarketSummary("ZCL", TradingPair.BTC).Result;
                            Console.WriteLine(@"\GetMarketSummary");
                            Console.WriteLine(String.Format("\t\tMarket:\t\t{0}", marketSummary.Market));
                            Console.WriteLine(String.Format("\t\tHigh:\t\t{0}", marketSummary.High));
                            Console.WriteLine(String.Format("\t\tLow:\t\t{0}", marketSummary.Low));
                            Console.WriteLine(String.Format("\t\tBaseVolume:\t{0}", marketSummary.BaseVolume));
                            Console.WriteLine(String.Format("\t\tLast:\t\t{0}", marketSummary.Last));
                            Console.WriteLine(String.Format("\t\tBid:\t\t{0}", marketSummary.Bid));
                            Console.WriteLine(String.Format("\t\tAsk:\t\t{0}", marketSummary.Ask));
                            Console.WriteLine(String.Format("\t\tOpenBuyOrders:\t{0}", marketSummary.OpenBuyOrders));
                            Console.WriteLine(String.Format("\t\tOpenSellOrders:\t{0}", marketSummary.OpenSellOrders));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "5":   // GetMarketSummaries

                        MarketSummary[] marketSummaries = new MarketSummary[] { };

                        try
                        {
                            marketSummaries = tradeSatoshi.GetMarketSummaries().Result;
                            Console.WriteLine(@"\GetMarketSummaries");
                            foreach (MarketSummary market in marketSummaries)
                            {
                                Console.WriteLine(String.Format("\t\tMarket:\t\t{0}", market.Market));
                                Console.WriteLine(String.Format("\t\tHigh:\t\t{0}", market.High));
                                Console.WriteLine(String.Format("\t\tLow:\t\t{0}", market.Low));
                                Console.WriteLine(String.Format("\t\tBaseVolume:\t{0}", market.BaseVolume));
                                Console.WriteLine(String.Format("\t\tLast:\t\t{0}", market.Last));
                                Console.WriteLine(String.Format("\t\tBid:\t\t{0}", market.Bid));
                                Console.WriteLine(String.Format("\t\tAsk:\t\t{0}", market.Ask));
                                Console.WriteLine(String.Format("\t\tOpenBuyOrders:\t{0}", market.OpenBuyOrders));
                                Console.WriteLine(String.Format("\t\tOpenSellOrders:\t{0}", market.OpenSellOrders));
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "6":   // GetOrderBook

                        OrderBook orderBook = new OrderBook();

                        try
                        {
                            orderBook = tradeSatoshi.GetOrderBook("ZCL", TradingPair.BTC, OrderType.Both, 5).Result;
                            Console.WriteLine(@"\GetOrderBook");
                            Console.WriteLine("\t\tBuy:");
                            foreach (Buy buy in orderBook.Buy)
                            {
                                Console.WriteLine(String.Format("\t\t\tQuantity:\t{0}", buy.Quantity));
                                Console.WriteLine(String.Format("\t\t\tRate:\t\t{0}", buy.Rate));
                            }
                            Console.WriteLine("\t\tSell:");
                            foreach (Sell sell in orderBook.Sell)
                            {
                                Console.WriteLine(String.Format("\t\t\tQuantity:\t{0}", sell.Quantity));
                                Console.WriteLine(String.Format("\t\t\tRate:\t\t{0}", sell.Rate));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "7":   // GetBalance

                        Balance balance = new Balance();

                        try
                        {
                            balance = tradeSatoshi.GetBalance("GRLC").Result;
                            Console.WriteLine(@"\GetBalance");
                            Console.WriteLine(String.Format("\t\tCurrency:\t\t{0}", balance.Currency));
                            Console.WriteLine(String.Format("\t\tCurrencyLong:\t\t{0}", balance.CurrencyLong));
                            Console.WriteLine(String.Format("\t\tAvailable:\t\t{0}", balance.Avaliable));     // a typo!
                            Console.WriteLine(String.Format("\t\tTotal:\t\t\t{0}", balance.Total));
                            Console.WriteLine(String.Format("\t\tHeldForTrades:\t\t{0}", balance.HeldForTrades));
                            Console.WriteLine(String.Format("\t\tUnconfirmed:\t\t{0}", balance.Unconfirmed));
                            Console.WriteLine(String.Format("\t\tPendingWithdraw:\t{0}", balance.PendingWithdraw));
                            Console.WriteLine(String.Format("\t\tAddress:\t\t{0}", balance.PendingWithdraw));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "8":   // GetBalances

                        Balance[] balances = new Balance[] { };

                        try
                        {
                            balances = tradeSatoshi.GetBalances().Result;
                            Console.WriteLine(@"\GetBalances");
                            foreach (Balance individualBalance in balances)
                            {
                                Console.WriteLine(String.Format("\t\tCurrency:\t\t{0}", individualBalance.Currency));
                                Console.WriteLine(String.Format("\t\tCurrencyLong:\t\t{0}", individualBalance.CurrencyLong));
                                Console.WriteLine(String.Format("\t\tAvailable:\t\t{0}", individualBalance.Avaliable));     // a typo!
                                Console.WriteLine(String.Format("\t\tTotal:\t\t\t{0}", individualBalance.Total));
                                Console.WriteLine(String.Format("\t\tHeldForTrades:\t\t{0}", individualBalance.HeldForTrades));
                                Console.WriteLine(String.Format("\t\tUnconfirmed:\t\t{0}", individualBalance.Unconfirmed));
                                Console.WriteLine(String.Format("\t\tPendingWithdraw:\t{0}", individualBalance.PendingWithdraw));
                                Console.WriteLine(String.Format("\t\tAddress:\t\t{0}", individualBalance.PendingWithdraw));
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "9":   // GetOrder

                        Order order = new Order();

                        try
                        {
                            order = tradeSatoshi.GetOrder(00000000).Result;

                            Console.WriteLine(@"\GetOrder");
                            Console.WriteLine(String.Format("\t\tAmount:\t\t{0}", order.Amount));
                            Console.WriteLine(String.Format("\t\tId:\t\t{0}", order.Id));
                            Console.WriteLine(String.Format("\t\tIsApi:\t\t{0}", order.IsApi));
                            Console.WriteLine(String.Format("\t\tMarket:\t\t{0}", order.Market));
                            Console.WriteLine(String.Format("\t\tRate:\t\t{0}", order.Rate));
                            Console.WriteLine(String.Format("\t\tRemaining:\t{0}", order.Remaining));
                            Console.WriteLine(String.Format("\t\tTimestamp:\t{0}", order.Timestamp));
                            Console.WriteLine(String.Format("\t\tTotal:\t\t{0}", order.Total));
                            Console.WriteLine(String.Format("\t\tType:\t\t{0}", order.Type));
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "10":  // GetOrders

                        Order[] orders = new Order[] { };

                        try
                        {
                            orders = tradeSatoshi.GetOrders("GRLC", TradingPair.BTC, 5).Result;
                            Console.WriteLine(@"\GetOrders");
                            foreach (Order individualOrder in orders)
                            {
                                Console.WriteLine(String.Format("\t\tAmount:\t\t{0}", individualOrder.Amount));
                                Console.WriteLine(String.Format("\t\tId:\t\t{0}", individualOrder.Id));
                                Console.WriteLine(String.Format("\t\tIsApi:\t\t{0}", individualOrder.IsApi));
                                Console.WriteLine(String.Format("\t\tMarket:\t\t{0}", individualOrder.Market));
                                Console.WriteLine(String.Format("\t\tRate:\t\t{0}", individualOrder.Rate));
                                Console.WriteLine(String.Format("\t\tRemaining:\t{0}", individualOrder.Remaining));
                                Console.WriteLine(String.Format("\t\tTimestamp:\t{0}", individualOrder.Timestamp));
                                Console.WriteLine(String.Format("\t\tTotal:\t\t{0}", individualOrder.Total));
                                Console.WriteLine(String.Format("\t\tType:\t\t{0}", individualOrder.Type));
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "11":  // SubmitOrder

                        SubmitOrder submitOrder = new SubmitOrder();

                        try
                        {
                            submitOrder = tradeSatoshi.SubmitOrder("GRLC", TradingPair.BTC, OrderType.Sell, .5, .00002).Result;
                            Console.WriteLine(@"\SubmitOrder");
                            Console.WriteLine(String.Format("\t\tOrderID:\t{0}", submitOrder.OrderId));
                            Console.WriteLine(String.Format("\t\tFilled:"));
                            foreach (long fill in submitOrder.Filled)
                            {
                                Console.WriteLine(String.Format("\t\t\t{0}", fill));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "12":  // CancelOrder

                        CancelOrder cancelOrder = new CancelOrder();

                        try
                        {
                            cancelOrder = tradeSatoshi.CancelOrder(CancelType.Market, null, "GRLC", TradingPair.BTC).Result;
                            Console.WriteLine(@"\CancelOrder");
                            Console.WriteLine(String.Format("\t\tCancelledOrders:"));
                            foreach (long cancelledOrder in cancelOrder.CanceledOrders)
                            {
                                Console.WriteLine(String.Format("\t\t\t{0}", cancelledOrder));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "13":  // GetTradeHistory

                        Order[] tradeHistory = new Order[] { };

                        // TODO: Retest later.. server gives an error
                        try
                        {
                            tradeHistory = tradeSatoshi.GetTradeHistory("GRLC", TradingPair.BTC, 10, 0).Result;
                            Console.WriteLine(@"\GetTradeHistory");
                            Console.WriteLine(String.Format("\t\tCancelledOrders:"));
                            foreach (Order trade in tradeHistory)
                            {
                                Console.WriteLine(String.Format("\t\tAmount:\t\t{0}", trade.Amount));
                                Console.WriteLine(String.Format("\t\tId:\t\t{0}", trade.Id));
                                Console.WriteLine(String.Format("\t\tIsApi:\t\t{0}", trade.IsApi));
                                Console.WriteLine(String.Format("\t\tMarket:\t\t{0}", trade.Market));
                                Console.WriteLine(String.Format("\t\tRate:\t\t{0}", trade.Rate));
                                Console.WriteLine(String.Format("\t\tRemaining:\t{0}", trade.Remaining));
                                Console.WriteLine(String.Format("\t\tTimestamp:\t{0}", trade.Timestamp));
                                Console.WriteLine(String.Format("\t\tTotal:\t\t{0}", trade.Total));
                                Console.WriteLine(String.Format("\t\tType:\t\t{0}", trade.Type));
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "14":  // GenerateAddress

                        GenerateAddress generateAddress = new GenerateAddress();

                        try
                        {
                            generateAddress = tradeSatoshi.GenerateAddress("BCH").Result;
                            Console.WriteLine(@"\GenerateAddress");
                            Console.WriteLine(String.Format("\t\tCurrency:\t{0}", generateAddress.Currency));
                            Console.WriteLine(String.Format("\t\tAddress:\t{0}", generateAddress.Address));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "15":  // SubmitWithdraw

                        SubmitWithdraw submitWithdraw = new SubmitWithdraw();

                        // TODO: Test
                        try
                        {
                            submitWithdraw = tradeSatoshi.SubmitWithdraw("GRLC", "address", 10).Result;
                            Console.WriteLine(@"\SubmitWithdraw");
                            Console.WriteLine(String.Format("\t\tWithdrawalId:\t{0}", submitWithdraw.WithdrawalId));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "16":  // GetDeposits

                        Deposit[] deposits = new Deposit[] { };

                        try
                        {
                            deposits = tradeSatoshi.GetDeposits("GRLC", 5).Result;
                            Console.WriteLine(@"\GetDeposits");
                            foreach (Deposit deposit in deposits)
                            {
                                Console.WriteLine(String.Format("\t\tID:\t\t{0}", deposit.Id));
                                Console.WriteLine(String.Format("\t\tCurrency:\t{0}", deposit.Currency));
                                Console.WriteLine(String.Format("\t\tCurrencyLong:\t{0}", deposit.CurrencyLong));
                                Console.WriteLine(String.Format("\t\tAmount:\t\t{0}", deposit.Amount));
                                Console.WriteLine(String.Format("\t\tStatus:\t\t{0}", deposit.Status));
                                Console.WriteLine(String.Format("\t\tTxid:\t\t{0}", deposit.Txid));
                                Console.WriteLine(String.Format("\t\tConfirmations:\t{0}", deposit.Confirmations));
                                Console.WriteLine(String.Format("\t\tTimestamp:\t{0}", deposit.Timestamp));
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        break;

                    case "17":  // GetWithdrawls

                        Withdrawl[] withdrawls = new Withdrawl[] { };

                        // TODO: Test
                        try
                        {
                            withdrawls = tradeSatoshi.GetWithdrawls("GRLC", 5).Result;
                            Console.WriteLine(@"\GetWithdrawls");
                            foreach (Withdrawl withdrawl in withdrawls)
                            {
                                Console.WriteLine(String.Format("\t\tID:\t\t{0}", withdrawl.Id));
                                Console.WriteLine(String.Format("\t\tCurrency:\t{0}", withdrawl.Currency));
                                Console.WriteLine(String.Format("\t\tCurrencyLong:\t{0}", withdrawl.CurrencyLong));
                                Console.WriteLine(String.Format("\t\tAmount:\t\t{0}", withdrawl.Amount));
                                Console.WriteLine(String.Format("\t\tFee:\t\t{0}", withdrawl.Fee));
                                Console.WriteLine(String.Format("\t\tAddress:\t\t{0}", withdrawl.Address));
                                Console.WriteLine(String.Format("\t\tStatus:\t\t{0}", withdrawl.Status));
                                Console.WriteLine(String.Format("\t\tTxid:\t\t{0}", withdrawl.Txid));
                                Console.WriteLine(String.Format("\t\tConfirmations:\t{0}", withdrawl.Confirmations));
                                Console.WriteLine(String.Format("\t\tTimestamp:\t{0}", withdrawl.Timestamp));
                                Console.WriteLine(String.Format("\t\tIsApi:\t\t{0}", withdrawl.IsApi));
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case "18":  // SubmitTransfer

                        Transfer transfer = new Transfer();

                        try
                        {
                            transfer = tradeSatoshi.SubmitTransfer("GRLC", "username", 1).Result;
                            Console.WriteLine(@"\SubmitTransfer");
                            Console.WriteLine(String.Format("\t\tData:\t\t{0}", transfer.Data));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.WriteLine();
                        break;
                }
                

            }

        }
    }
}
