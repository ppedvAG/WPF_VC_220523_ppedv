﻿using System;
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

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public CloseCommand CloseCmd { get; set; } = new CloseCommand();

        public CustomCommand OpenCmd { get; set; } = new CustomCommand
            (
                //parameter => new MainWindow().Show(),
                //parameter =>
                //{
                //    new MainWindow().Show();
                    //...
                //}

                OpenCmdExecute,

                //p => { return (p as string).Length >= 1; }

                OpenCmdCanExecute
            );



        private static void OpenCmdExecute(object parameter)
        {
            new MainWindow().Show();
        }

        private static bool OpenCmdCanExecute(object parameter)
        {
            return (parameter as String).Length >= 1;
        }
    }
}
