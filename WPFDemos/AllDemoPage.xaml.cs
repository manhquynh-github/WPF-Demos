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

namespace WPFDemos
{
  /// <summary>
  /// Interaction logic for AllDemoPage.xaml
  /// </summary>
  public partial class AllDemoPage : Page
  {
    public AllDemoPage()
    {
      InitializeComponent();
      DemoListBox.ItemsSource = new List<Page>()
      {
        new CalculatorDemo(),
        new ColorPickerDemo(),
      };
    }

    private void DemoListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      var page = (Page)DemoListBox.SelectedItem;
      if (page != null)
      {
        NavigationService.Navigate(page);
      }
    }
  }
}
