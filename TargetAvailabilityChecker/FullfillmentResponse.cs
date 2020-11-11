using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TargetAvailabilityChecker
{
    public class OrderPickup
    {
        [JsonProperty("availability_status")]
        public string AvailabilityStatus { get; set; }
    }

    public class Curbside
    {
        [JsonProperty("availability_status")]
        public string AvailabilityStatus { get; set; }
    }

    public class ShipToStore
    {
        [JsonProperty("availability_status")]
        public string AvailabilityStatus { get; set; }
    }

    public class InStoreOnly
    {
        [JsonProperty("availability_status")]
        public string AvailabilityStatus { get; set; }
    }

    public class Location
    {
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("distance")]
        public string Distance { get; set; }

        [JsonProperty("store_name")]
        public string StoreName { get; set; }

        [JsonProperty("store_address")]
        public string StoreAddress { get; set; }

        [JsonProperty("location_available_to_promise_quantity")]
        public double LocationAvailableToPromiseQuantity { get; set; }

        [JsonProperty("order_pickup")]
        public OrderPickup OrderPickup { get; set; }

        [JsonProperty("curbside")]
        public Curbside Curbside { get; set; }

        [JsonProperty("ship_to_store")]
        public ShipToStore ShipToStore { get; set; }

        [JsonProperty("in_store_only")]
        public InStoreOnly InStoreOnly { get; set; }
    }

    public class Product
    {
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("street_date")]
        public DateTime StreetDate { get; set; }

        [JsonProperty("available_to_purchase_date_time")]
        public DateTime AvailableToPurchaseDateTime { get; set; }

        [JsonProperty("buy_unit_of_measure")]
        public string BuyUnitOfMeasure { get; set; }

        [JsonProperty("availability_unit_of_measure")]
        public string AvailabilityUnitOfMeasure { get; set; }

        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }
    }

    public class FullfillmentResponse
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}
