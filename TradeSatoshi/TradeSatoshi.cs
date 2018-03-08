using TradeSatoshiAPI.Entities;
using TradeSatoshiAPI.Enum;
using System.Threading.Tasks;

namespace TradeSatoshiAPI
{
    public class TradeSatoshi
    {

        private TradeSatoshiApiWrapper tradeSatoshiApiWrapper;

        public TradeSatoshi(string baseURL, string apiKey, string apiSecret)
        {
            tradeSatoshiApiWrapper = new TradeSatoshiApiWrapper(baseURL, apiKey, apiSecret);
        }

        // GetCurrencies
        public async Task<CurrencyList[]> GetCurrencyList()
        {
            CurrencyList[] currencyList = await tradeSatoshiApiWrapper.GetCurrencies();

            return currencyList;
        }

        // GetTicker
        public async Task<Ticker> GetTicker(string currency, TradingPair tradingPair)
        {
            Ticker ticker = await tradeSatoshiApiWrapper.GetTicker(currency, tradingPair);

            return ticker;
        }

        // GetMarketHistory
        public async Task<MarketHistory[]> GetMarketHistory(string currency, TradingPair tradingPair, int numRecords)
        {
            MarketHistory[] marketHistory = await tradeSatoshiApiWrapper.GetMarketHistory(currency, tradingPair, numRecords);

            return marketHistory;
        }

        // GetMarketSummary
        public async Task<MarketSummary> GetMarketSummary(string currency, TradingPair tradingPair)
        {
            MarketSummary marketSummary = await tradeSatoshiApiWrapper.GetMarketSummary(currency, tradingPair);

            return marketSummary;
        }

        // GetMarketSummaries
        public async Task<MarketSummary[]> GetMarketSummaries()
        {
            MarketSummary[] marketSummaries = await tradeSatoshiApiWrapper.GetMarketSummaries();

            return marketSummaries;
        }

        // GetOrderBook
        public async Task<OrderBook> GetOrderBook(string currency, TradingPair tradingPair, OrderType orderType, int depth)
        {
            OrderBook orderBook = await tradeSatoshiApiWrapper.GetOrderBook(currency, tradingPair, orderType, depth);

            return orderBook;
        }

        // GetBalance
        public async Task<Balance> GetBalance(string currency)
        {
            Balance balance = await tradeSatoshiApiWrapper.GetBalance(currency);

            return balance;
        }

        // GetBalances
        public async Task<Balance[]> GetBalances()
        {

            Balance[] balances = await tradeSatoshiApiWrapper.GetBalances();

            return balances;
        }

        // GetOrder
        public async Task<Order> GetOrder(long orderID)
        {
            Order order = await tradeSatoshiApiWrapper.GetOrder(orderID);

            return order;
        }

        // GetOrders
        public async Task<Order[]> GetOrders(string currency, TradingPair tradingPair, int count)
        {
            Order[] order = await tradeSatoshiApiWrapper.GetOrders(currency, tradingPair, count);

            return order;
        }

        // SubmitOrder
        public async Task<SubmitOrder> SubmitOrder(string currency, TradingPair tradingPair, OrderType orderType, double amount, double price)
        {
            SubmitOrder submitOrder = await tradeSatoshiApiWrapper.SubmitOrder(currency, tradingPair, orderType, amount, price);

            return submitOrder;
        }

        // CancelOrder
        public async Task<CancelOrder> CancelOrder(CancelType cancelType, string orderID, string currency, TradingPair tradingPair)
        {
            CancelOrder cancelOrder = await tradeSatoshiApiWrapper.CancelOrder(cancelType, orderID, currency, tradingPair);

            return cancelOrder;
        }

        // GetTradeHistory
        public async Task<Order[]> GetTradeHistory(string currency, TradingPair tradingPair, int count, int pageNum)
        {
            Order[] order = await tradeSatoshiApiWrapper.GetTradeHistory(currency, tradingPair, count, pageNum);

            return order;
        }

        // GenerateAddress
        public async Task<GenerateAddress> GenerateAddress(string currency)
        {
            GenerateAddress generateAddress = await tradeSatoshiApiWrapper.GenerateAddress(currency);

            return generateAddress;
        }

        // SubmitWithdraw
        public async Task<SubmitWithdraw> SubmitWithdraw(string currency, string address, double amount)
        {
            SubmitWithdraw submitWithdraw = await tradeSatoshiApiWrapper.SubmitWithdraw(currency, address, amount);

            return submitWithdraw;
        }

        // GetDeposits
        public async Task<Deposit[]> GetDeposits(string currency, int count)
        {
            Deposit[] deposit = await tradeSatoshiApiWrapper.GetDeposits(currency, count);

            return deposit;
        }

        // GetWithdrawals
        public async Task<Withdrawl[]> GetWithdrawls(string currency, int count)
        {
            Withdrawl[] withdrawl = await tradeSatoshiApiWrapper.GetWithdrawls(currency, count);

            return withdrawl;
        }

        // SubmitTransfer
        public async Task<Transfer> SubmitTransfer(string currency, string username, double amount)
        {
            Transfer transfer = await tradeSatoshiApiWrapper.SubmitTransfer(currency, username, amount);

            return transfer;
        }


        // Internal API

        // GetTradePairChart
        public async Task<TradePairChart> GetTradePairChart(int tradePairID)
        {
            TradePairChart tradePairChart = await tradeSatoshiApiWrapper.GetTradePairChart(tradePairID);

            return tradePairChart;
        }


    }
}
