using System;
using System.Runtime.Serialization;

namespace fruittrade
{
    [DataContract]
    public class FruitTrade
    {
        [DataMember]
        public string COUNTRY { get; set; }
        [DataMember]
        public decimal TRADE_COST { get; set; }
        [DataMember]
        public decimal VARIABLE_COST { get; set; }
        [DataMember]
        public string COMMODITY { get; set; }
    }
}
