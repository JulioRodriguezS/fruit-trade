using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace fruittrade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitTradeController : ControllerBase
    {

        private List<FruitTrade> Summaries;

        private readonly ILogger<FruitTradeController> _logger;

        private readonly Uri serverUri = new Uri("ftp://filetransferftpfruit@files.000webhost.com/public_html/FileTradeFruit.json");

        public FruitTradeController(ILogger<FruitTradeController> logger)
        {
            _logger = logger;

            Summaries = new List<FruitTrade>();

            WebClient requestFTPFile = new WebClient();

            requestFTPFile.Credentials = new NetworkCredential("filetransferftpfruit", "Unpez_1234@\\");
            try
            {
                byte[] newFileData = requestFTPFile.DownloadData(serverUri.ToString());
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                var fruitList = JsonConvert.DeserializeObject<List<FruitTrade>>(fileString);

                foreach (var item in fruitList)
                    Summaries.Add(item);           
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [HttpGet]
        public IEnumerable<FruitTradeResponse> Get(string COMMODITY, decimal PRICE, decimal TONS )
        {
            /*Example get request: https://localhost:44375/fruittrade?COMMODITY=mango&PRICE=53&TONS=405*/

            var filterList = Summaries
                .Where(item => (item.COMMODITY == COMMODITY) && (item.VARIABLE_COST <= PRICE)).Select(x => x).ToList();
            var resList = new List<FruitTradeResponse>();
            foreach (var item in filterList)
            {
                resList.Add(new FruitTradeResponse
                {
                    COUNTRY = item.COUNTRY,
                    TOTAL_COST = (item.VARIABLE_COST * TONS) + item.TRADE_COST,
                    TRADE_COST = item.TRADE_COST,
                    VARIABLE_COST = item.VARIABLE_COST
                });
            }
            return resList.ToArray();
        }
    }
}
