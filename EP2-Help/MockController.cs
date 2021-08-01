using EP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP2_Help
{
    class MockController : ISparkController
    {
        public List<Tuple<string, float?>> calculaDesvio(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group)
        {
            throw new NotImplementedException();
        }

        public List<Tuple<string, float?>> calculaMedia(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group)
        {
            throw new NotImplementedException();
        }

        public Tuple<float, float, List<float>, List<float>> calculaQuadrados(IEnumerable<int> years, IEnumerable<Station> stations, string data, string data2)
        {
            throw new NotImplementedException();
        }

        public List<Tuple<string, float?>> calculaVar(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group)
        {
            throw new NotImplementedException();
        }
    }
}
