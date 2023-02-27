﻿using AdonisUI.Controls;

namespace FMRookieScouter
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : AdonisWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
            banner.ShowAd(160, 600, "1t1w96rt04na");
        }
    }
}
