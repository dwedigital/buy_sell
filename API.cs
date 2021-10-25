using System;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;
namespace buy_sell{
class APICALL
{
  private static string API_KEY = "1a330d54-b0fd-417d-8be0-b383a5517ffd";

  public static double Api(string symbol)
  {
    try
    {
        string data = makeAPICall(symbol);
        JObject json = JObject.Parse(data);
        return Convert.ToDouble(json["data"][symbol]["quote"]["GBP"]["price"]);
    }
    catch (WebException e)
    {
    Console.WriteLine(e.Message);
    return 0.0;
    }
  }

  static string makeAPICall(string symbol)
  {
    var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest");

    var queryString = HttpUtility.ParseQueryString(string.Empty);
    queryString["symbol"] = symbol;
    queryString["convert"] = "GBP";


    URL.Query = queryString.ToString();

    var client = new WebClient();
    client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
    client.Headers.Add("Accepts", "application/json");
    return client.DownloadString(URL.ToString());

  }

}
}