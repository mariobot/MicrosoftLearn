using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BFF.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileBFFController : ControllerBase
    {
        [HttpGet("GetAllCustomers")]
        public async Task<List<CustomerDTO>> GetAllCustomers()
        {
            return await GetAllCustomersAsync();
        }

        private async Task<List<CustomerDTO>>
        GetAllCustomersAsync()
        {
            string baseURL = "https://localhost:44324/api/";
            string url = baseURL + "Customer/GetAllCustomers";

            using (HttpClient client = new HttpClient())
            {
                List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

                using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var customers = JsonSerializer.Deserialize<List<CustomerDTO>>(data, options);

                        foreach (CustomerDTO? customer in customers)
                        {
                            CustomerDTO customerDTO = new CustomerDTO();
                            customerDTO.Id = customer.Id;
                            customerDTO.FirstName = customer.FirstName;
                            customerDTO.LastName = customer.LastName;
                            customerDTO.Phone = null;
                            customerDTO.Address = null;
                            customerDTO.EmailAddress = null;
                            customerDTOs.Add(customerDTO);
                        }

                        return customerDTOs;
                    }
                }
            }
        }
    }
}
