using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP2
{
    public class Iventory : IComparable<Iventory>
    {
        public string ID { get; set; }
        public int Year { get; set; }

        public int CompareTo(Iventory other)
        {

            if (other == null)
                return -1;

            return String.Compare(ID, other.ID);
        }
    }
}
