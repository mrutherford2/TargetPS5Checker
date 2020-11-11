using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TargetAvailabilityChecker
{
    /// <summary>
    /// Simple App to check for PS5 availablility at Target
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter Zip Code: ");
            string zipCode = Console.ReadLine();

            Console.WriteLine("Enter Key: ");
            string key = Console.ReadLine();

            int checkInterval = 2000;
            bool inStock = false;
            const int digitalEditionProductId = 81114596;
            const int discEditionProductId = 81114595;

            using var digitalEditionClient = new HttpClient();
            string digitalEditionUri = $"https://api.target.com/fulfillment_aggregator/v1/fiats/{digitalEditionProductId}?key={key}&nearby={zipCode}&limit=20&requested_quantity=1&radius=50&fulfillment_test_mode=grocery_opu_team_member_test";

            using var discEditionClient = new HttpClient();
            string discEditionUri = $"https://api.target.com/fulfillment_aggregator/v1/fiats/{discEditionProductId}?key={key}&nearby={zipCode}&limit=20&requested_quantity=1&radius=50&fulfillment_test_mode=grocery_opu_team_member_test";
            while (!inStock)
            {
                Console.WriteLine("Checking for available stock");
                var digitalEditionResponseTask = digitalEditionClient.GetAsync(digitalEditionUri);
                var discEditionResponseTask = discEditionClient.GetAsync(discEditionUri);

                await Task.WhenAll(digitalEditionResponseTask, discEditionResponseTask);

                var digitalEditionResponse = digitalEditionResponseTask.Result;
                var discEditionResponse = discEditionResponseTask.Result;

                if (digitalEditionResponse.IsSuccessStatusCode)
                {
                    var digitalEditionData = JsonConvert.DeserializeObject<FullfillmentResponse>(await digitalEditionResponse.Content.ReadAsStringAsync());
                    var closestDigitalEditionInStock = digitalEditionData.Products?.FirstOrDefault()?.Locations?.OrderBy(x => x.Distance)?
                        .Where(x => x.Curbside.AvailabilityStatus != "UNAVAILABLE" || x.OrderPickup.AvailabilityStatus != "UNAVAILABLE" || x.ShipToStore.AvailabilityStatus != "UNAVAILABLE" || x.InStoreOnly.AvailabilityStatus != "UNAVAILABLE")?.FirstOrDefault();
                    if(closestDigitalEditionInStock != null)
                    {
                        Console.Beep();
                        Console.WriteLine($"Digital Edition Available at Store Name: {closestDigitalEditionInStock.StoreName} Store Address: {closestDigitalEditionInStock.StoreAddress} Amount Available: {closestDigitalEditionInStock.LocationAvailableToPromiseQuantity}");
                        inStock = true;
                    }
                }
                else
                {
                    Console.WriteLine("Got non-successful response back from Target API. Will attempt to check again.");
                }

                if (discEditionResponse.IsSuccessStatusCode)
                {
                    var discEditionData = JsonConvert.DeserializeObject<FullfillmentResponse>(await discEditionResponse.Content.ReadAsStringAsync());
                    var closestDiscEditionInStock = discEditionData.Products?.FirstOrDefault()?.Locations?.OrderBy(x => x.Distance)?
                        .Where(x => x.Curbside.AvailabilityStatus != "UNAVAILABLE" || x.OrderPickup.AvailabilityStatus != "UNAVAILABLE" || x.ShipToStore.AvailabilityStatus != "UNAVAILABLE" || x.InStoreOnly.AvailabilityStatus != "UNAVAILABLE")?.FirstOrDefault();
                    if(closestDiscEditionInStock != null)
                    {
                        Console.Beep();
                        Console.WriteLine($"Disc Edition Available at Store Name: {closestDiscEditionInStock.StoreName} Store Address: {closestDiscEditionInStock.StoreAddress} Amount Available: {closestDiscEditionInStock.LocationAvailableToPromiseQuantity}");
                        inStock = true;
                    }
                }
                else
                {
                    Console.WriteLine("Got non-successful response back from Target API. Will attempt to check again.");
                }

                Console.WriteLine("No stock available, trying again");
                Thread.Sleep(checkInterval);
            }

        }
    }
}
