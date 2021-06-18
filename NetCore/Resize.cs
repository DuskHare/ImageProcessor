using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using ImageSharpImage = SixLabors.ImageSharp.Image;


namespace ImageProcessing
{
    public class Resize
    {
        private const int Width = 1280;
        private const int Height = 853;
        private const int ResizedWidth = 150;
        private const int ResizedHeight = 99;
        private const int Quality = 75;
        private const string ImageSharp = nameof(ImageSharp);
        private readonly JpegEncoder imageSharpJpegEncoder = new JpegEncoder { Quality = Quality };
        public IEnumerable<string> Images { get; }
        private readonly string outputDirectory;

        public const int ImagesCount = 12;

        public Resize()
        {
            
            string imageDirectory = Path.GetFullPath(".");
            while (!Directory.Exists(Path.Combine(imageDirectory, "images")))
            {
                imageDirectory = Path.GetDirectoryName(imageDirectory);
                if (imageDirectory == null)
                {
                    throw new FileNotFoundException("Could not find an image directory.");
                }
            }

            imageDirectory = Path.Combine(imageDirectory, "images");
            Images = Directory.EnumerateFiles(imageDirectory).Take(20);
            this.outputDirectory = Path.Combine(Path.GetDirectoryName(imageDirectory), "output");
            if (!Directory.Exists(this.outputDirectory))
            {
                Directory.CreateDirectory(this.outputDirectory);
            }
        }

        private string OutputPath(string inputPath, string postfix)
        {
            return Path.Combine(
                this.outputDirectory,
                Path.GetFileNameWithoutExtension(inputPath)
                + "-" + postfix
                + Path.GetExtension(inputPath));
        }

        
        public void ResizeImageSharpChoose()
        {
            foreach (string image in Images)
            {
                ResizeImageSharp(image);
            }
        }

        public void ResizeImageSharp(string input)
        {
            using (var output = File.Open(OutputPath(input, ImageSharp), FileMode.Create))
            {
                using (var image = ImageSharpImage.Load(input))
                {
                    image.Mutate(i => i.Resize(ResizedWidth, ResizedHeight, KnownResamplers.Bicubic));
                    image.Metadata.ExifProfile = null;
                    image.Save(output, imageSharpJpegEncoder);
                }
            }
        }

        
    }
}