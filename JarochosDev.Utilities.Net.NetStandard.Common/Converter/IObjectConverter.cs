namespace JarochosDev.Utilities.Net.NetStandard.Common.Converter
{
    public interface IObjectConverter<TFrom, TTo>
    {
        TTo Convert(TFrom item);
    }
}
