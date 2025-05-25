namespace gui_tesing_library
{
    public class Configuration
    {
        public enum IMAGE_COMPARER
        {
            PIEXEL_BY_PIXEL,
        }

        private static GtConfiguration_CS gtConfiguration_CS = new GtConfiguration_CS();
        public static long ProcesAwaitTime
        {
            get { return gtConfiguration_CS.GetTimeout(); }
            set { gtConfiguration_CS.SetTimeout((int)value); }
        }

        public static int ActionDelay
        {
            get { return gtConfiguration_CS.getActionDelay(); }
            set { gtConfiguration_CS.setActioNDelay(value); }
        }

        public static IMAGE_COMPARER ImageComparerType
        {
            get
            {
                return Helpers.CSImageComparerToImageComparer(
                    gtConfiguration_CS.GetImageComparerType()
                );
            }
            set
            {
                gtConfiguration_CS.setImageCompareType(
                    Helpers.ImageCompaererToCsImageComparer(value)
                );
            }
        }
    }
}
