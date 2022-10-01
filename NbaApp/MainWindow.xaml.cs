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

namespace NbaApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Images _images = new();

    public MainWindow()
    {
        DataContext = _images;
        InitializeComponent();
    }

    private void Right(object sender, RoutedEventArgs e)
    {
        _images.Right();
    }

    private void Left(object sender, RoutedEventArgs e)
    {
        _images.Left();
    }
}