using System.IO;
using CoenM.ImageHash;
using CoenM.ImageHash.HashAlgorithms;
using gui_tesing_library.Interfaces;

namespace gui_tesing_library_CS.Services;

internal class HashImageComparer : IImageComparer
{
    private readonly IImageHash hashAlgorithm = new AverageHash();

    public double CompareImages(Stream image1, Stream image2)
    {
        var hash1 = hashAlgorithm.Hash(image1);
        var hash2 = hashAlgorithm.Hash(image2);

        var percentageImageSimilarity = CompareHash.Similarity(hash1, hash2) / 100;
        return percentageImageSimilarity;
    }
}
