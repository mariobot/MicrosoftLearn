using Newtonsoft.Json;

public class User
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("userId")]
    public string UserId { get; set; }
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("dividend")]
    public string Dividend { get; set; }
    [JsonProperty("OrderHistory")]
    public OrderHistory[] OrderHistory { get; set; }
    [JsonProperty("ShippingPreference")]
    public ShippingPreference[] ShippingPreference { get; set; }
    [JsonProperty("CouponsUsed")]
    public CouponsUsed[] Coupons { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}