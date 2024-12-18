using FoodProject.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace FoodProject.Midllwares
{
    public class TransactionMiddlware
    {
        RequestDelegate _nextAction;
        Context _context;
        public TransactionMiddlware(RequestDelegate nextAction, Context context)
        {
            _context = context;

            _nextAction = nextAction;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            IDbContextTransaction transaction = default;
            try
            {
                transaction = _context.Database.BeginTransaction();
                await _nextAction(context);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                throw;
            }
        }

    }
}
