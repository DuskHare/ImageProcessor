using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using ImageMagick;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using ImageSharpImage = SixLabors.ImageSharp.Image;

namespace ImageProcessing
{
    public class BlurSave
    {
        private const int Quality = 75;
        private const string ImageSharp = nameof(ImageSharp);

        // Set the quality for ImagSharp
        private readonly JpegEncoder imageSharpJpegEncoder = new JpegEncoder { Quality = Quality };

        public IEnumerable<string> Images { get; }
        private readonly string outputDirectory;

        public const int ImagesCount = 12;

        public BlurSave()
        {
            if (RuntimeInformation.OSArchitecture is Architecture.X86 or Architecture.X64)
            {
                // Workaround ImageMagick issue
                OpenCL.IsEnabled = false;
            }

            // Find the closest images directory
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

            // Get at most 20 images from there
            Images = Directory.EnumerateFiles(imageDirectory).Take(20);

            // Create the output directory next to the images directory
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

        internal void ImageSharpBlur()
        {
            throw new NotImplementedException();
        }
        
        public void ImageSharpBlurChoose()
        {
            foreach (string image in Images)
            {
                ImageSharpBlur(image);
                //image.Mutate(x => x.GaussianBlur(5, new CoreRectangle(o.BoundingBox.X - 10, o.BoundingBox.Y - 10, o.BoundingBox.Width + 20, o.BoundingBox.Height + 20)));
            }
        }

        public void ImageSharpBlur(string input)
        {
            using (var output = File.Open(OutputPath(input, ImageSharp), FileMode.Create))
            {              
                using (var image = ImageSharpImage.Load(input))
                {
                    image.Mutate(i => i.GaussianBlur(100));
                    // Reduce the size of the file
                    image.Metadata.ExifProfile = null;
                    // Save the results
                    image.Save(output, imageSharpJpegEncoder);
                }
            }
        }
    }




}

