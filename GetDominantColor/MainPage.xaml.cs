using ColorThiefDotNet;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace GetDominantColor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private Brush _bgColor;
        private string _fileName;

        public Brush BgColor
        {
            get => this._bgColor;
            set
            {
                if (value != this._bgColor)
                {
                    this._bgColor = value;
                    NotifyPropertyChanged("BgColor");
                }
            }
        }

        public string FileName
        {
            get => this._fileName;
            set
            {
                if (value != this._fileName)
                {
                    this._fileName = value;
                    NotifyPropertyChanged("FileName");
                }
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        // PropertyChanged logic
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Get storage file async
        private async Task<StorageFile> GetFileAsync()
        {
            StorageFile file = null;
            try
            {
                var picker = new FileOpenPicker();
                picker.ViewMode = PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".jpeg");
                picker.FileTypeFilter.Add(".png");

                file = await picker.PickSingleFileAsync();
            }
            catch { }
            return file;
        }

        private async void SelectImage(object sender, RoutedEventArgs e)
        {
            StorageFile file = await GetFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                fileName.Text = "Picked photo: " + file.Name;

                IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
                // Create the decoder from the stream
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);

                var colorThief = new ColorThief();
                var dominantColor = await colorThief.GetColor(decoder);
                var color = dominantColor.Color;

                Rect.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(color.A,
                                                                                color.R,
                                                                                color.G,
                                                                                color.B));
            }
        }
    }
}