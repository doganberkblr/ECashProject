using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
    
        public async Task<IActionResult> Index()
        {

            #region
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "dfa2b84090msh775c24893cce8fap154e78jsn5f92f9fefb1b" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.USDtoTRY = Decimal.Parse(body.Replace(".", ",")).ToString("0.000");
            }
            #endregion

            #region
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "dfa2b84090msh775c24893cce8fap154e78jsn5f92f9fefb1b" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ViewBag.EURtoTRY = Decimal.Parse(body2.Replace(".", ",")).ToString("0.000");
            }
            #endregion

            #region
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "dfa2b84090msh775c24893cce8fap154e78jsn5f92f9fefb1b" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ViewBag.GBPtoTRY = Decimal.Parse(body3.Replace(".", ",")).ToString("0.000");
            }
            #endregion

            #region
            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=EUR&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "dfa2b84090msh775c24893cce8fap154e78jsn5f92f9fefb1b" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response4 = await client4.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                var body4 = await response4.Content.ReadAsStringAsync();
                ViewBag.USDtoEUR = Decimal.Parse(body4.Replace(".", ",")).ToString("0.000");
            }
            #endregion

            return View();
        }
    }
}

