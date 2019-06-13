using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WPFDemos
{
  /// <summary>
  /// Interaction logic for Calculator.xaml
  /// </summary>
  public partial class CalculatorDemo : Page
  {
    public CalculatorDemo()
    {
      InitializeComponent();
      ViewModel = new ViewModel();
      DataContext = ViewModel;
    }

    public ViewModel ViewModel { get; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (sender is Button button)
      {
        var glyph = (string)button.Content;
        switch (glyph)
        {
          case "0":
          case "1":
          case "2":
          case "3":
          case "4":
          case "5":
          case "6":
          case "7":
          case "8":
          case "9":
            ViewModel.Append(glyph);
            break;

          case "C":
            ViewModel.Clear();
            break;

          case "DEL":
            ViewModel.RemoveLast();
            break;

          case "ANS":
            ViewModel.LoadCachedValue();
            break;

          case "+":
          case "-":
          case "*":
          case "/":
          case "=":
            ViewModel.Operator = glyph[0];
            break;
        }
      }
    }
  }

  public class ViewModel : INotifyPropertyChanged
  {
    private double _cachedValue;
    private string _formulaString;
    private char _operator;
    private double _value;

    public ViewModel()
    {
      _operator = '\0';
      _cachedValue = 0;
      _formulaString = "";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public string FormulaString
    {
      get => _formulaString;
      private set
      {
        _formulaString = value;
        NotifyPropertyChanged();
      }
    }

    public char Operator
    {
      get => _operator;
      set
      {
        PreApplyFormula();
        _operator = value;
        NotifyPropertyChanged();
        PostApplyFormula();
      }
    }

    public double Value
    {
      get => _value;
      private set
      {
        _value = value;
        NotifyPropertyChanged();
      }
    }

    public void Append(string c)
    {
      Value = Value * 10 + int.Parse(c);
    }

    public void Clear()
    {
      Value = 0;
      Operator = '\0';
      FormulaString = "";
    }

    public void LoadCachedValue()
    {
      Value = _cachedValue;
    }

    public void RemoveLast()
    {
      Value = (int)(Value / 10);
    }

    private void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
    {
      if (propertyName != null)
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    private void PostApplyFormula()
    {
      switch (Operator)
      {
        case '=':
          Value = _cachedValue;
          break;
      }

      FormulaString += " " + Operator;
    }

    private void PreApplyFormula()
    {
      FormulaString += " " + Value;

      switch (Operator)
      {
        case '\0':
          _cachedValue = Value;
          Value = 0;
          break;

        case '=':
          _cachedValue = Value;
          Value = 0;
          FormulaString = FormulaString.Substring(FormulaString.IndexOf('=') + 2);
          break;

        case '+':
          _cachedValue += Value;
          Value = 0;
          break;

        case '-':
          _cachedValue -= Value;
          Value = 0;
          break;

        case '*':
          _cachedValue *= Value;
          Value = 0;
          break;

        case '/':
          _cachedValue /= Value;
          Value = 0;
          break;
      }
    }
  }
}