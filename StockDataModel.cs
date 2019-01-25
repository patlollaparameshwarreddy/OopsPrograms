using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    public class StockDataModel
    {
        private int id;
        private string name;
        private int numberOfShares;
        private int pricePerShare;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int NumberOfShares { get => numberOfShares; set => numberOfShares = value; }
        public int PricePerShare { get => pricePerShare; set => pricePerShare = value; }
    }
}
