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
using System.Windows.Shapes;

namespace eggstore.src.Boxes
{
    /// <summary>
    /// Interaction logic for Ingresar.xaml
    /// </summary>
    public partial class Ingresar : Window
    {
        public Ingresar()
        {
            InitializeComponent();
            tbcantidad.Focus();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            bool esnumerico = decimal.TryParse(tbcantidad.Text, out _);

            if (esnumerico)
            {
                Total = decimal.Parse(tbcantidad.Text);
                Efectivo = decimal.Parse(tbcantidad.Text);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        public decimal Total { get; set; }
        public decimal Efectivo { get; set; }
        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
