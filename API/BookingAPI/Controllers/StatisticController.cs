using ApiApplication.Queries.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers;

[Tags("Statistic")]
public class StatisticController : BasicApiController
{
    [HttpGet]
    public async Task<ActionResult<StatsModel>> GetStats()
    {
        return await Mediator.Send(new GetStatisticsQuery());
    }
}