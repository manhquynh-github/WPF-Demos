using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFDemos.Themes
{
  public class IconButton : Button
  {
    public static readonly DependencyProperty CornerRadiusProperty =
         DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(IconButton), new PropertyMetadata(new CornerRadius()));

    public static readonly DependencyProperty IconFontProperty =
            DependencyProperty.Register("IconFont", typeof(FontFamily), typeof(IconButton), new PropertyMetadata(new FontFamily("Segoe MDL2 Assets")));

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(IconButton), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty IconSizeProperty =
        DependencyProperty.Register("IconSize", typeof(double), typeof(IconButton), new PropertyMetadata(16.0));

    public static readonly DependencyProperty ShowTextProperty =
        DependencyProperty.Register("ShowText", typeof(bool), typeof(IconButton), new PropertyMetadata(true));

    public static readonly DependencyProperty SpacingProperty =
        DependencyProperty.Register("Spacing", typeof(Thickness), typeof(IconButton), new PropertyMetadata(new Thickness(7, 0, 0, 0)));

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(IconButton), new PropertyMetadata(string.Empty));

    static IconButton()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
    }

    public CornerRadius CornerRadius
    {
      get => (CornerRadius)GetValue(CornerRadiusProperty);
      set => SetValue(CornerRadiusProperty, value);
    }

    public string Icon
    {
      get => (string)GetValue(IconProperty);
      set => SetValue(IconProperty, value);
    }

    public FontFamily IconFont
    {
      get => (FontFamily)GetValue(IconFontProperty);
      set => SetValue(IconFontProperty, value);
    }

    public double IconSize
    {
      get => (double)GetValue(IconSizeProperty);
      set => SetValue(IconSizeProperty, value);
    }

    public bool ShowText
    {
      get => (bool)GetValue(ShowTextProperty);
      set => SetValue(ShowTextProperty, value);
    }

    public Thickness Spacing
    {
      get => (Thickness)GetValue(SpacingProperty);
      set => SetValue(SpacingProperty, value);
    }

    public string Text
    {
      get => (string)GetValue(TextProperty);
      set => SetValue(TextProperty, value);
    }
  }
}