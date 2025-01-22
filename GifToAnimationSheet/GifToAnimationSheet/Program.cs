using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;

internal class Program
{
    [SupportedOSPlatform("windows")]
    private static void Main(string[] args)
    {
        // Prompt user for input file
        Console.WriteLine("Enter name of file to convert:");
        string? inputFileName = Console.ReadLine();

        if (inputFileName == null)
        {
            Console.WriteLine("No filename given. Press enter to exit");
            Console.ReadLine();
            return;
        }

        // Append .gif extension if not given
        if (!inputFileName.EndsWith(".gif"))
        {
            inputFileName += ".gif";
        }

        if (!File.Exists(inputFileName))
        {
            Console.WriteLine($"File {inputFileName} not found. Press enter to exit");
            Console.ReadLine();
            return;
        }

        // Prompt user for output file name
        Console.WriteLine("Enter name to use for output file:");
        string? outputFileName = Console.ReadLine();

        if (outputFileName == null)
        {
            Console.WriteLine("No filename given. Press enter to exit");
            Console.ReadLine();
            return;
        }

        // Append .png extension if not given
        if (!outputFileName.EndsWith(".png"))
        {
            outputFileName += ".png";
        }

        List<Image> frames = [];

        Image imageToConvert = Image.FromFile(inputFileName);

        int numberOfFrames = imageToConvert.GetFrameCount(FrameDimension.Time);

        for (int i = 0; i < numberOfFrames; i++)
        {
            imageToConvert.SelectActiveFrame(FrameDimension.Time, i);
            frames.Add(new Bitmap(imageToConvert));
        }

        int sheetRows = frames.Count / 5;

        if (frames.Count % 5 > 0)
        {
            sheetRows++;
        }

        var sheetImage = new Bitmap(imageToConvert.Width * 5, imageToConvert.Height * sheetRows);

        using (Graphics graphics = Graphics.FromImage(sheetImage))
        {
            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < numberOfFrames; i++)
            {
                graphics.DrawImage(frames[i], xPosition, yPosition);
                xPosition += frames[i].Width;

                if ((i + 1) % 5 == 0)
                {
                    yPosition += frames[i].Height;
                    xPosition = 0;
                }
            }
        }

        sheetImage.Save(outputFileName);

        Console.WriteLine($"Conversion finished. Animation sheet has been saved as {outputFileName}. Press enter to exit.");
        Console.ReadLine();
        return;
    }
}