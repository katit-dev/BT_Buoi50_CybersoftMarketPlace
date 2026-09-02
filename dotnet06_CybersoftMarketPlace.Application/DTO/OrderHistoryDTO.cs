namespace dotnet06_CybersoftMarketPlace.Application.DTOs;
public class OrderHistoryDTO
{
    public int OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Đang xử lý"; // bảng Order chưa có cột này, tự xử lý
    public List<OrderHistoryItemDTO> Items { get; set; } = new();
}
public class OrderHistoryItemDTO
{
    public int VariantId { get; set; }
    public string ProductName { get; set; } = null!; // đi từ Variant.Product.Name
    public string VariantName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubTotal { get; set; }
}