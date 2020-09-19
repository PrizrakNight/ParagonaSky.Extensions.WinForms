namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class IntToDecimalConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value is int integer)
                return (decimal)integer;

            return .0m;
        }

        public object ConvertBack(object value)
        {
            if (value is decimal @decimal)
                return (int)@decimal;

            return 0;
        }
    }
}
