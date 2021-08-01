using System;
using System.Collections.Generic;

namespace EP2
{
    public interface ISparkController
    {
        List<Tuple<string, float?>> calculaDesvio(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group);
        List<Tuple<string, float?>> calculaMedia(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group);
        Tuple<float, float, List<float>, List<float>> calculaQuadrados(IEnumerable<int> years, IEnumerable<Station> stations, string data, string data2);
        List<Tuple<string, float?>> calculaVar(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group);
    }
}