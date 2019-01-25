using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
   public class CustomerModel
    {
        private int id;
        private string name;
        private int valuation;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Valuation { get => valuation; set => valuation = value; }
    }
}
