using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace fruittrade
{
    [DataContract]
    public class FruitTradeResponse
    {
        [DataMember]
        public string COUNTRY { get; set; }
        [DataMember]
        public decimal TRADE_COST { get; set; }
        [DataMember]
        public decimal VARIABLE_COST { get; set; }
        [DataMember]
        public decimal TOTAL_COST { get; set; }
    }
}
