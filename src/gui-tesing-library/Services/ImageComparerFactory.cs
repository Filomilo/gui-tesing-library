using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Interfaces;
using Lombok.NET;

namespace gui_tesing_library.Services
{

    public static partial class ImageComparerFactory
    {
        public enum IMAGE_COMPARER_TYPE
        {
            HASH_COMPARER,
        }

        public static IImageComparer GetComparer()
        {
            switch (Configuration.ImageComparerType)
            {
                case IMAGE_COMPARER_TYPE.HASH_COMPARER:
                    return new HashImageComparer();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}
