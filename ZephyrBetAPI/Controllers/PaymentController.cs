using Microsoft.AspNetCore.Mvc;
using ZephyrBetAPI.Models.Stripe;
using ZephyrBetAPI.Services.StripeServices;

namespace ZephyrBetAPI.Controllers;

[Route("api/[controller]")]
public class PaymentController : Controller
{
    private readonly IStripeAppService _stripeService;

    public PaymentController(IStripeAppService stripeService)
    {
        _stripeService = stripeService;
    }

    [HttpPost("customer/add")]
    public async Task<ActionResult<StripeCustomer>> AddStripeCustomer(
        [FromBody] AddStripeCustomer customer,
        CancellationToken ct)
    {
        StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(
            customer,
            ct);

        return StatusCode(StatusCodes.Status200OK, createdCustomer);
    }

    [HttpPost("payment/add")]
    public async Task<ActionResult<StripePayment>> AddStripePayment(
        [FromBody] AddStripePayment payment,
        CancellationToken ct)
    {
        StripePayment createdPayment = await _stripeService.AddStripePaymentAsync(
            payment,
            ct);

        return StatusCode(StatusCodes.Status200OK, createdPayment);
    }
}