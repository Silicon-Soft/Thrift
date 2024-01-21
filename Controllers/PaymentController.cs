using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Thrift_Us.Models;

[ApiController]
[Route("api/payment")]
public class PaymentController : ControllerBase
{
    [HttpPost("verify")]
    public async Task<IActionResult> VerifyPayment([FromBody] PaymentVerificationRequest request)
    {
        var secretKey = "c1db680689c747af8a1be783f04322bb";
        var url = "https://khalti.com/api/v2/payment/verify/";

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", "Key " + secretKey);

            var payload = new Dictionary<string, string>
            {
                { "token", request.Token },
                { "amount", request.Amount.ToString() }
            };

            var response = await client.PostAsync(url,
               new FormUrlEncodedContent(payload));
            var responseString = await response.Content.ReadAsStringAsync();

        
           if (response.IsSuccessStatusCode)
            {
               
                return Ok(responseString); 
            }
            else
            {
              
                return BadRequest(responseString); 
            }
        }
    }
}

