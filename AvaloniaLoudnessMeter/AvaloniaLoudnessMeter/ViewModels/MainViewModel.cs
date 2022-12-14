﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaLoudnessMeter.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string boldTitle = "AVALONIA";

        [ObservableProperty]
        private string regularTitle = "LOUDNESS METER";

        [ObservableProperty]
        private bool channelConfigurationListIsOpen = false;

        [RelayCommand]
        private void ChannelConfigurationButtonPressed()
        {
            ChannelConfigurationListIsOpen ^= true;
        }

        public MainViewModel()
        {
          
        }
    }
}
