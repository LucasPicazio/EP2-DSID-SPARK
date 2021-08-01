using EP2_Help;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Axis = LiveCharts.Wpf.Axis;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace EP2
{
    public partial class MainForm : Form
    {
        private ISparkController sparkController;
        private readonly IEnumerable<Station> stations;
        private readonly IEnumerable<Iventory> iventory;

        public MainForm()
        {
            InitializeComponent();
            var columns = new List<string> { "ID", "USAF", "WBAN", "Elevation", "Country_Code", "Latitude", "Longitude", "Date", "Year", "Month", "Day", "Mean_Temp", "Mean_Temp_Count", "Mean_Dewpoint", "Mean_Dewpoint_Count", "Mean_Sea_Level_Pressure", "Mean_Sea_Level_Pressure_Count", "Mean_Station_Pressure", "Mean_Station_Pressure_Count", "Mean_Visibility", "Mean_Visibility_Count", "Mean_Windspeed", "Mean_Windspeed_Count", "Max_Windspeed", "Max_Gust", "Max_Temp", "Max_Temp_Quality_Flag", "Min_Temp", "Min_Temp_Quality_Flag", "Precipitation", "Precip_Flag", "Snow_Depth", "Fog", "Rain_or_Drizzle", "Snow_or_Ice", "Hail", "Thunder", "Tornado" };
            var start = 1929;
            var end = 2016;
            var years = Enumerable.Range(start, end - start + 1).ToList();
            stations = GetStationsInfos();
            iventory = GetIventory();
            cbData1.Items.AddRange(columns.ToArray());
            cbData2.Items.AddRange(columns.ToArray());
            cbGroup.Items.AddRange(columns.ToArray());
            cbYears.DataSource = years;
            cbStations.DataSource = stations;
            ((ListBox)cbStations).DisplayMember = "Name";
            ((ListBox)cbStations).ValueMember = "WBAN";

            sparkController = new MockController();
        }

        private IEnumerable<Iventory> GetIventory()
        {
            var stationsYearsStr = File.ReadAllText("inventory.txt").Split('\n');
            var stationsYearsSplited = stationsYearsStr.Select(x => x.Split('-'));
            var iventory = stationsYearsSplited.Where(y => y.Length > 1).Select(x => new Iventory { ID = $"{x[0]}-{x[1]}", Year = int.Parse(x[2]) }).ToList();
            iventory.Sort();
            return iventory;
        }

        private IEnumerable<Station> GetStationsInfos()
        {
            var stationsStrings = File.ReadAllText("stations.txt").Split('\n');
            var stationsListStrings = stationsStrings.Select(x => x.Split('\t'));
            return stationsListStrings.Where(y => y.Length > 2).Select(x => new Station { USAF = x[0], WBAN = x[1], Name = x[2] }).ToList();
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            var data = cbData1.SelectedItem as string;
            var years = cbYears.SelectedItems.Cast<int>();
            var stations = cbStations.SelectedItems.Cast<Station>();
            var group = cbGroup.SelectedItem as string;

            var result = sparkController.calculaMedia(years, stations, data, group);
            //var result = new List<Tuple<string, float>>() { Tuple.Create("asd", 1f) };
            result = result.Where(x => !string.IsNullOrEmpty(x.Item1)).ToList();
            var values = new ChartValues<float>();
            foreach (var x in result)
            {
                values.Add(x.Item2 ?? 0);
            }

            chart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = values
                }
            };


            chart1.AxisX.Add(new Axis
            {
                Labels = result.Select(x => x.Item1).ToList()
            });

            chart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString("N")
            });



        }

        private void btnVariancia_Click(object sender, EventArgs e)
        {
            var data = cbData1.SelectedItem as string;
            var years = cbYears.SelectedItems.Cast<int>();
            var stations = cbStations.SelectedItems.Cast<Station>();
            var group = cbGroup.SelectedItem as string;

            var result = sparkController.calculaVar(years, stations, data, group);
        }

        private void btnDesvio_Click(object sender, EventArgs e)
        {
            var data = cbData1.SelectedItem as string;
            var years = cbYears.SelectedItems.Cast<int>();
            var stations = cbStations.SelectedItems.Cast<Station>();
            var group = cbGroup.SelectedItem as string;

            var result = sparkController.calculaDesvio(years, stations, data, group);
        }

        private void btnQuadrados_Click(object sender, EventArgs e)
        {
            var data = cbData1.SelectedItem as string;
            var years = cbYears.SelectedItems.Cast<int>();
            var stations = cbStations.SelectedItems.Cast<Station>();
            var data2 = cbData2.SelectedItem as string;

            var result = sparkController.calculaQuadrados(years, stations, data, data2);
        }


        private void cbYears_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var years = ((CheckedListBox)sender).SelectedItems.Cast<int>();
            var AvailableIventory = iventory.Where(x => years.Contains(x.Year)).ToList();
            AvailableIventory.Sort();
            var AvailableStations = stations.Where(x => AvailableIventory.BinarySearch(new Iventory { ID = $"{x.USAF}-{x.WBAN}" }) > 0).ToList();
            cbStations.DataSource = AvailableStations;
            ((ListBox)cbStations).DisplayMember = "Name";
            ((ListBox)cbStations).ValueMember = "WBAN";
        }
    }
}
