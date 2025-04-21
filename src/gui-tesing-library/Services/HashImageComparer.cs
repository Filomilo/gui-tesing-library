using CoenM.ImageHash;
using CoenM.ImageHash.HashAlgorithms;
using gui_tesing_library.Interfaces;
using System.IO;

namespace gui_tesing_library.Services
{
    class HashImageComparer : IImageComparer
    {
        IImageHash hashAlgorithm = new AverageHash();
        public double CompareImages(Stream image1, Stream image2)
        {

            ulong hash1 = hashAlgorithm.Hash(image1);
            ulong hash2 = hashAlgorithm.Hash(image2);

            double percentageImageSimilarity = CompareHash.Similarity(hash1, hash2) / 100;
            return percentageImageSimilarity;
        }
    }
}
