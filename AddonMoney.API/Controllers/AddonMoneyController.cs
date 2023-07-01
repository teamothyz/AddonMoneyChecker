using AddonMoney.API.Services;
using AddonMoney.Data.API;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AddonMoney.API.Controllers
{
    [Route("api/addonmoney")]
    [ApiController]
    public class AddonMoneyController : ControllerBase
    {
        private readonly string _logPrefix = "[AddonMoneyController]";
        private readonly MQProducer _producer;

        public AddonMoneyController(MQProducer producer)
        {
            _producer = producer;
        }

        [HttpPost("balance")]
        public async Task<IActionResult> UpdateBalance(UpdateBalanceRequest model)
        {
            try
            {
                await Task.Run(() => _producer.SendMessage(model));
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception when handling update balance request.", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("error")]
        public async Task<IActionResult> UpdateError(UpdateErrorRequest model)
        {
            try
            {
                await Task.Run(() => _producer.SendMessage(model));
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception when handling update error request.", ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
