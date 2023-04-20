using ZephyrBetAPI.Models.Stripe;

namespace ZephyrBetAPI.Services.StripeServices;

public interface IStripeAppService
{
    Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
    Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
}