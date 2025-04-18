using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library.Interfaces
{
    /// <summary>
    /// Returns simliarity between two images in in percentage. between 0 and 1
    /// </summary>
    public interface IImageComparer
    {
        double CompareImages(Stream image1, Stream image2);
    }
}
