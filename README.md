[![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/kundan2001/ColorThief.UWP?color=brightgreen&include_prereleases)](https://github.com/kundan2001/ColorThief.UWP/releases/latest)
[![GitHub](https://img.shields.io/github/license/kundan2001/ColorThief.UWP?label=license)](https://github.com/kundanhere/ColorThief.UWP/blob/master/LICENSE)
![GitHub repo size](https://img.shields.io/github/repo-size/kundan2001/ColorThief.UWP)

# Get Dominant Color

A code for grabbing the dominant color from an image. Uses [ColorThief](https://github.com/lokesh/color-thief/) for C# and .NET to make it happen.

## Compatibility:

| Operating System |     Architecture     | Supported |        Version |
| :--------------- | :------------------: | :-------: | -------------: |
| Windows 10       | x86, x64, ARM, ARM64 |    Yes    |16299 or higher |
| Windows 8.1      |       x86, x64       |    No     |                |
| Windows 8        |       x86, x64       |    No     |                |
| Windows 7        |       x86, x64       |    No     |                |               

## How to use ColorThief

### Get the dominant color from an image
```cs
var colorThief = new ColorThief();
colorThief.GetColor(sourceImage);
```

### Build a color palette from an image

In this example, we build an 8 color palette.

```cs
var colorThief = new ColorThief();
colorThief.GetPalette(sourceImage, 8);
```

For Xamarin.Forms

```cs
await CrossColorThief.Current.GetPalette(sourceImage);
```
## How to build and run the program

### Build

1. Start Microsoft Visual Studio and select **File > Open > Project/Solution**.
2. Go to the folder where you unzipped the sample. Double-click the Visual Studio Solution (.sln) file.
3. Press Ctrl+Shift+B, or select **Build > Build Solution**.

### Run

After opening the Visual Studio solution, set the architecture to x64 or x86. The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

1. Deploy

    - Select **Build > Deploy Solution**.

2. Deploy and run

    - To debug the sample and then run it, press F5 or select **Debug > Start Debugging**. 
    - To run the sample without debugging, press Ctrl+F5 or select **Debug > Start Without Debugging**.

## License 

ColorThief.UWP is a MIT-style licensed, as found in the [LICENSE](https://github.com/kundanhere/ColorThief.UWP/blob/master/LICENSE) file.
