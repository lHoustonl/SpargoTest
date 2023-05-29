namespace SpargoTest.ApiClient.Models.Response;

public sealed class GetGoodsResponse
{
    public string? RefId { get; init; }
    public string Code { get; init; } = null!;
    public string? Name { get; init; }
    public string? Producer { get; init; }
    public string? Country { get; init; }
    public List<string?> Barcodes { get; init; } = null!;
    public string? GoodsGroupCodes { get; init; }
    public string? MnnEn { get; init; }
    public string? MnnRu { get; init; }
    public string? Rv { get; init; }
    public DateTimeOffset Created { get; init; }
}