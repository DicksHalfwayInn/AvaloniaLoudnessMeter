using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using AvaloniaLoudnessMeter.ViewModels;
using System;

namespace AvaloniaLoudnessMeter.Views
{
    public partial class MainView : UserControl
    {
        #region Private Members

        private Control mChannelConfigPopup;
        private Control mChannelConfigButton;
        private Control mMainGrid;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MainView()
        {
            InitializeComponent();

            mChannelConfigButton = this.FindControl<Control>("ChannelConfigurationButton") ??
                throw new Exception("Could not locate the Channel Configuration Button by name");
            mChannelConfigPopup = this.FindControl<Control>("ChannelConfigurationPopup") ??
                throw new Exception("Could not find the Popup by name");
            mMainGrid = this.FindControl<Control>("MainGrid") ?? throw new Exception("Cannot find Main Grid by name");

        }


        public override void Render(DrawingContext context)
        {
            base.Render(context);


            // Get relative position of button, in relation to main grid
            var position = mChannelConfigButton.TranslatePoint(new Point(), mMainGrid) ??
                           throw new Exception("Cannot get TranslatePoint from Configuration Button");

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                // Set margin of popup so it appears bottom left of button
                mChannelConfigPopup.Margin = new Thickness(
                    position.X,
                    0,
                    0,
                    mMainGrid.Bounds.Height - position.Y - mChannelConfigButton.Bounds.Height);

            });




        }

        private void InputElement_OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            
            ((MainViewModel)DataContext).ChannelConfigurationButtonPressedCommand.Execute(null);
        }
    }
}