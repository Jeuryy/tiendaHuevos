using Capa_Negocio;
using eggstore.src.Boxes;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        Error error;
        public ChartValues<decimal> Values { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            try
            {
                CN_Dashboard dash = new CN_Dashboard();
                lbltotales.Content = dash.CantidadVentas().ToString();
                lblartdisponibles.Content = dash.Articulos().ToString();

                Values = new ChartValues<decimal>();

                foreach (DataRow row in dash.Grafico().Rows)
                {
                    decimal i = decimal.Parse(row["Monto_Total"].ToString());
                    Values.Add(i);
                }

                DataContext = this;
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
    }
}
