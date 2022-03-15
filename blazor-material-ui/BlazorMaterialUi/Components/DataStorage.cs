using MudBlazor;
using System.Collections.Generic;

namespace BlazorMaterialUi.Components
{
    public static class DataStorage
    {
        public static (List<ChartSeries> ChartData, string[] Labels) GetChartData(string productName)
        {
            var chartData = new List<ChartSeries>
            {
                new ChartSeries
                {
                    Name = productName,
                    Data = new double[] { 23, 35, 52, 46, 40, 50 }
                }
            };

            var labels = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };

            return (chartData, labels);
        }
    }
}
