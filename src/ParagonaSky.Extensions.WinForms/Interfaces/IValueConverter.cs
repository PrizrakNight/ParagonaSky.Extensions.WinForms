namespace ParagonaSky.Extensions.WinForms.Editor
{
    public interface IValueConverter
    {
        object Convert(object value);
        object ConvertBack(object value);
    }
}
