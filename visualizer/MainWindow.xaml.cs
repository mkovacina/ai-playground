using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;

namespace visualizer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Random r = new Random(13);

		public PlotModel PlotModel { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.All;
			PlotModel = GenerateRandomPlotModel(string.Format("Random plot '{0}'", 1));
			DataContext = PlotModel;
		}

		private PlotModel GenerateRandomPlotModel(string title, int numberOfPoints = 50)
		{
			var plotModel = new PlotModel
			{
				Title = title,
				TitleToolTip = title
			};
			var lineSeries = new LineSeries();

			for (int i = 0; i < numberOfPoints; i++)
			{
				lineSeries.Points.Add(new DataPoint(i, this.r.NextDouble()));
			}

			plotModel.Series.Add(lineSeries);

			return plotModel;
		}
	}
}
