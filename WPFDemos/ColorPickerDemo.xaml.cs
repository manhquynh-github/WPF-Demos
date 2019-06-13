using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
  /// Interaction logic for ColorPickerPage.xaml
  /// </summary>
  public partial class ColorPickerDemo : Page
  {
    private ObservableCollection<ColorItem> items = new ObservableCollection<ColorItem>();
    //List<ColorItem> items = new List<ColorItem>();

    public ColorPickerDemo()
    {
      InitializeComponent();
      var red = Color.FromRgb(255, 0, 0);
      var green = Color.FromRgb(0, 255, 0);
      var blue = Color.FromRgb(0, 0, 255);
      items.Add(new ColorItem() { BackgroundColor = new SolidColorBrush(red) });
      items.Add(new ColorItem() { BackgroundColor = new SolidColorBrush(green) });
      items.Add(new ColorItem() { BackgroundColor = new SolidColorBrush(blue) });

      lbTodoList.ItemsSource = items;
    }

    private void rgbToHex(Color c)
    {
      var hexValue = string.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
      txtHex.Text = hexValue;
    }

    private void sldRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      var color = Color.FromRgb((byte)sldRed.Value, (byte)sldGreen.Value, (byte)sldBlue.Value);
      txtRed.Text = sldRed.Value.ToString();
      borderBG.Background = new SolidColorBrush(color);
      rgbToHex(color);
    }

    private void sldGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      var color = Color.FromRgb((byte)sldRed.Value, (byte)sldGreen.Value, (byte)sldBlue.Value);
      txtGreen.Text = sldGreen.Value.ToString();
      borderBG.Background = new SolidColorBrush(color);
      rgbToHex(color);
    }

    private void sldBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      var color = Color.FromRgb((byte)sldRed.Value, (byte)sldGreen.Value, (byte)sldBlue.Value);
      txtBlue.Text = sldBlue.Value.ToString();
      borderBG.Background = new SolidColorBrush(color);
      rgbToHex(color);
    }

    private bool IsNumber(string pText)
    {
      var regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
      return regex.IsMatch(pText);
    }

    private void txtRed_TextChanged(object sender, TextChangedEventArgs e)
    {
      var c = sender as TextBox;
      if (IsNumber(c.Text))
      {
        int n = short.Parse(c.Text);
        if (n >= 0 || n < 256)
        {
          sldRed.Value = n;
        }
      }
    }

    private void txtGreen_TextChanged(object sender, TextChangedEventArgs e)
    {
      var c = sender as TextBox;
      if (IsNumber(c.Text))
      {
        int n = short.Parse(c.Text);
        if (n >= 0 || n < 256)
        {
          sldGreen.Value = n;
        }
      }
    }

    private void txtBlue_TextChanged(object sender, TextChangedEventArgs e)
    {
      var c = sender as TextBox;
      if (IsNumber(c.Text))
      {
        int n = short.Parse(c.Text);
        if (n >= 0 || n < 256)
        {
          sldBlue.Value = n;
        }
      }
    }

    private void txtHex_TextChanged(object sender, TextChangedEventArgs e)
    {
      var c = sender as TextBox;
      if (c.Text.Length == 7)
      {
        try
        {
          var R = Convert.ToByte(c.Text.Substring(1, 2), 16);
          var G = Convert.ToByte(c.Text.Substring(3, 2), 16);
          var B = Convert.ToByte(c.Text.Substring(5, 2), 16);
          sldRed.Value = R;
          sldGreen.Value = G;
          sldBlue.Value = B;
          var scb = new SolidColorBrush(Color.FromRgb(R, G, B));
          borderBG.Background = scb;
        }
        catch
        {

        }
      }
    }

    public class ColorItem
    {
      public SolidColorBrush BackgroundColor { get; set; }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var color = Color.FromRgb((byte)sldRed.Value, (byte)sldGreen.Value, (byte)sldBlue.Value);
      //FavoritePanel.Children.Add(new Border
      //{
      //    Height = 40,
      //    Background = new SolidColorBrush(color)
      //});

      items.Add(new ColorItem() { BackgroundColor = new SolidColorBrush(color) });
    }
  }
}
