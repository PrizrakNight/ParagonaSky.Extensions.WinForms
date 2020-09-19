namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value is int integer)
                return integer.ToString();

            return string.Empty;
        }

        public object ConvertBack(object value)
        {
            if (value is string @string)
                return int.Parse(@string);

            return 0;
        }
    }
}
