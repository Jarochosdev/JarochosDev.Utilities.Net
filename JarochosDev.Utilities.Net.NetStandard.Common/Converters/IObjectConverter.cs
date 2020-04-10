namespace JarochosDev.Utilities.Net.NetStandard.Common.Converters
{
    public interface IObjectConverter<TFrom, TTo>
    {
        TTo Convert(TFrom item);
    }
}
