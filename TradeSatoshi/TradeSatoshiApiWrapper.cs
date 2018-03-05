using TradeSatoshiAPI.Entities;
using TradeSatoshiAPI.Enum;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Security.Cryptography;

namespace TradeSatoshiAPI
{  

    public class TradeSatoshiApiWrapper
    {

        private readonly string _BaseUrl;
        private readonly string _API_KEY;
        private readonly string _API_SECRET;

        private string _SuccessError = "Success message from the server returned false";
        private string _ParseError = "Unable to read server response. This can sometimes be the result of using an invalid 'API Key' or 'API Secret'.";


        public TradeSatoshiApiWrapper(string baseUrl, string apiKey, string apiSecret)
        {
            _BaseUrl = baseUrl;
            _API_KEY = apiKey;
            _API_SECRET = apiSecret;
        }


        // GetCurrencies
        public async Task<CurrencyList[]> GetCurrencies()
        {
            using (var client = new HttpClient())
            {
                SetHttpClientProperties(client);

                // create the URL string.
                var url = string.Format("api/public/getcurrencies");

                // make the request
                var response = await client.GetAsync(url);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                CurrencyListEntity currencyListEntity = new CurrencyListEntity();

                try
                {
                    currencyListEntity = JsonConvert.DeserializeObject<CurrencyListEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (currencyListEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return currencyListEntity.Result;
            }
        }

        // GetTicker
        public async Task<Ticker> GetTicker(string currency, TradingPair tradingPair)
        {

            string market = String.Format("{0}_{1}", currency, tradingPair.ToString());

            using (var client = new HttpClient())
            {
                SetHttpClientProperties(client);

                // create the URL string.
                var url = string.Format("api/public/getticker?market={0}", market);

                // make the request
                var response = await client.GetAsync(url);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                TickerEntity tickerEntity = new TickerEntity();

                try
                {
                    tickerEntity = JsonConvert.DeserializeObject<TickerEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (tickerEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return tickerEntity.Result;
            }
        }

        // GetMarketHistory
        public async Task<MarketHistory[]> GetMarketHistory(string currency, TradingPair tradingPair, int numRecords)
        {

            // Set up parameters
            string market = String.Format("{0}_{1}", currency, tradingPair.ToString());

            string count = numRecords.ToString();

            using (var client = new HttpClient())
            {
                SetHttpClientProperties(client);

                // create the URL string.
                var url = string.Format("api/public/getmarkethistory?market={0}&count={1}", market, count);

                // make the request
                var response = await client.GetAsync(url);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                MarketHistoryEntity marketHistoryEntity = new MarketHistoryEntity();

                try
                {
                    marketHistoryEntity = JsonConvert.DeserializeObject<MarketHistoryEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (marketHistoryEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return marketHistoryEntity.Result;
            }
        }

        // GetMarketSummary
        public async Task<MarketSummary> GetMarketSummary(string currency, TradingPair tradingPair)
        {

            string market = String.Format("{0}_{1}", currency, tradingPair.ToString());

            using (var client = new HttpClient())
            {
                SetHttpClientProperties(client);

                // create the URL string.
                var url = string.Format("api/public/getmarketsummary?market={0}", market);

                // make the request
                var response = await client.GetAsync(url);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                MarketSummaryEntity marketSummaryEntity = new MarketSummaryEntity();

                try
                {
                    marketSummaryEntity = JsonConvert.DeserializeObject<MarketSummaryEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (marketSummaryEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return marketSummaryEntity.Result;
            }
        }

        // GetMarketSummaries
        public async Task<MarketSummary[]> GetMarketSummaries()
        {

            using (var client = new HttpClient())
            {
                SetHttpClientProperties(client);

                // create the URL string.
                var url = string.Format("api/public/getmarketsummaries");

                // make the request
                var response = await client.GetAsync(url);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                MarketSummariesEntity marketSummariesEntity = new MarketSummariesEntity();

                try
                {
                    marketSummariesEntity = JsonConvert.DeserializeObject<MarketSummariesEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (marketSummariesEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return marketSummariesEntity.Result;
            }
        }

        // GetOrderBook
        public async Task<OrderBook> GetOrderBook(string currency, TradingPair tradingPair, OrderType orderType, int depth)
        {

            string market = String.Format("{0}_{1}", currency, tradingPair.ToString());

            using (var client = new HttpClient())
            {
                SetHttpClientProperties(client);

                // create the URL string.
                var url = string.Format("api/public/getorderbook?market={0}&type={1}&depth={2}", market, orderType.ToString(), depth);

                // make the request
                var response = await client.GetAsync(url);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                OrderBookEntity orderBook = new OrderBookEntity();

                try
                {
                    orderBook = JsonConvert.DeserializeObject<OrderBookEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (orderBook.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return orderBook.Result;
            }
        }

        //  GetBalance
        public async Task<Balance> GetBalance(string currency)
        {

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/getbalance";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Currency"] = currency;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                BalanceEntity balanceEntity = new BalanceEntity();

                try
                {
                    balanceEntity = JsonConvert.DeserializeObject<BalanceEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (balanceEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return balanceEntity.Result;
            }
        }


        // GetBalances
        public async Task<Balance[]> GetBalances()
        {

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/getbalances";

                // JSON POST parameters
                JObject jObject = new JObject();
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                BalancesEntity balancesEntity = new BalancesEntity();

                try
                {
                    balancesEntity = JsonConvert.DeserializeObject<BalancesEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (balancesEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return balancesEntity.Result;
            }
        }


        // GetOrder
        public async Task<Order> GetOrder(long orderID)
        {

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/getorder";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["OrderId"] = orderID;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                OrderEntity orderEntity = new OrderEntity();

                try
                {
                    orderEntity = JsonConvert.DeserializeObject<OrderEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (orderEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return orderEntity.Result;
            }
        }


        // GetOrders
        public async Task<Order[]> GetOrders(string currency, TradingPair tradingPair, int count)
        {

            string market = String.Format("{0}_{1}", currency, tradingPair.ToString());

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/getorders";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Market"] = market;
                jObject["Count"] = count;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                OrdersEntity ordersEntity = new OrdersEntity();

                try
                {
                    ordersEntity = JsonConvert.DeserializeObject<OrdersEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (ordersEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return ordersEntity.Result;
            }
        }


        // SubmitOrder
        public async Task<SubmitOrder> SubmitOrder(string currency, TradingPair tradingPair, OrderType orderType, double amount, double price)
        {

            string market = String.Format("{0}_{1}", currency, tradingPair.ToString());

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/submitOrder";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Market"] = market;
                jObject["Type"] = orderType.ToString();
                jObject["Amount"] = amount;
                jObject["Price"] = price;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                SubmitOrderEntity submitOrderEntity = new SubmitOrderEntity();

                try
                {
                    submitOrderEntity = JsonConvert.DeserializeObject<SubmitOrderEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (submitOrderEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return submitOrderEntity.Result;
            }
        }


        // CancelOrder
        public async Task<CancelOrder> CancelOrder(CancelType cancelType, string orderID, string currency, TradingPair tradingPair)
        {

            string market = String.Format("{0}_{1}", currency, tradingPair.ToString());

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/cancelorder";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Type"] = cancelType.ToString();
                jObject["OrderId"] = orderID;
                jObject["Market"] = market;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                CancelOrderEntity cancelOrderEntity = new CancelOrderEntity();

                try
                {
                    cancelOrderEntity = JsonConvert.DeserializeObject<CancelOrderEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (cancelOrderEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return cancelOrderEntity.Result;
            }
        }


        // GetTradeHistory
        public async Task<Order[]> GetTradeHistory(string currency, TradingPair tradingPair, int count, int pageNum)
        {

            string market = String.Format("{0}_{1}", currency, tradingPair.ToString());

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/gettradehistory";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Market"] = market;
                jObject["Count"] = count;
                jObject["PageNumber"] = pageNum;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                TradeHistoryEntity tradeHistoryEntity = new TradeHistoryEntity();

                try
                {
                    tradeHistoryEntity = JsonConvert.DeserializeObject<TradeHistoryEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (tradeHistoryEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return tradeHistoryEntity.Result;
            }
        }


        // GenerateAddress
        public async Task<GenerateAddress> GenerateAddress(string currency)
        {

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/generateaddress";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Currency"] = currency;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                GenerateAddressEntity generateAddressEntity = new GenerateAddressEntity();

                try
                {
                    generateAddressEntity = JsonConvert.DeserializeObject<GenerateAddressEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (generateAddressEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return generateAddressEntity.Result;
            }
        }


        // SubmitWithdraw
        public async Task<SubmitWithdraw> SubmitWithdraw(string currency, string address, double amount)
        {

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/submitwithdraw";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Currency"] = currency;
                jObject["Address"] = address;
                jObject["Amount"] = amount;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                SubmitWithdrawEntity submitWithdrawEntity = new SubmitWithdrawEntity();

                try
                {
                    submitWithdrawEntity = JsonConvert.DeserializeObject<SubmitWithdrawEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (submitWithdrawEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return submitWithdrawEntity.Result;
            }
        }


        // GetDeposits
        public async Task<Deposit[]> GetDeposits(string currency, int count)
        {

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/getdeposits";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Currency"] = currency;
                jObject["Count"] = count;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                DepositsEntity depositsEntity = new DepositsEntity();

                try
                {
                    depositsEntity = JsonConvert.DeserializeObject<DepositsEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (depositsEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return depositsEntity.Result;
            }
        }

        // GetWithdrawls
        public async Task<Withdrawl[]> GetWithdrawls(string currency, int count)
        {

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/getwithdrawls";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["Currency"] = currency;
                jObject["Count"] = count;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                WithdrawlsEntity withdrawlsEntity = new WithdrawlsEntity();

                try
                {
                    withdrawlsEntity = JsonConvert.DeserializeObject<WithdrawlsEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (withdrawlsEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return withdrawlsEntity.Result;
            }
        }


        //  SubmitTransfer
        public async Task<Transfer> SubmitTransfer(string currency, string username, double amount)
        {

            using (var client = new HttpClient())
            {

                // create the URL string.
                string endpoint = "api/private/submittransfer";

                // JSON POST parameters
                JObject jObject = new JObject();
                jObject["currency"] = currency; // Hmmmm, we switched to lowercase?
                jObject["username"] = username;
                jObject["Amount"] = amount;
                string postParams = jObject.ToString(Formatting.None, null);

                // Http Client params
                SetHttpClientPropertiesPrivate(client, endpoint, postParams);

                // make the request
                var content = new StringContent(postParams, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);

                // parse the response and return the data.
                var jsonResponseString = await response.Content.ReadAsStringAsync();

                TransferEntity transferEntity = new TransferEntity();

                try
                {
                    transferEntity = JsonConvert.DeserializeObject<TransferEntity>(jsonResponseString);
                }
                catch (Exception e)
                {
                    throw new Exception(_ParseError, e);
                }

                // Check success message from server
                if (transferEntity.Success == false)
                {
                    throw new Exception(_SuccessError);
                }

                return transferEntity.Result;
            }
        }

        private void SetHttpClientProperties(HttpClient client)
        {
            client.BaseAddress = new Uri(_BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void SetHttpClientPropertiesPrivate(HttpClient client, string endpoint, string jsonParams)
        {
            client.BaseAddress = new Uri(_BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Signature
            string nonce = DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + Guid.NewGuid().ToString("N");
            string signature = CreateSignature(endpoint, nonce, jsonParams);

            // Authorization Header
            string authorization = String.Format("{0}:{1}:{2}", _API_KEY, signature, nonce);
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + authorization);
            
        }

        private string CreateSignature(string endpoint, string nonce, string jsonParams)
        {
            string uri = String.Format("{0}{1}", _BaseUrl, endpoint);
            uri = Uri.EscapeDataString(uri).ToLower();

            string postParams = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonParams));

            string signature = String.Format("{0}POST{1}{2}{3}", _API_KEY, uri, nonce, postParams);

            var key = Convert.FromBase64String(_API_SECRET);

            using (var hmacsha512 = new HMACSHA512(key))
            {
                hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(signature));
                signature = Convert.ToBase64String(hmacsha512.Hash);
            }

            return signature;
        }

    }
}
