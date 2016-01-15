using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlData
{
    public class MyDtoske
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Id}\n{Comment}\n{Amount}\n{Date.Date}";
        }
    }
}
