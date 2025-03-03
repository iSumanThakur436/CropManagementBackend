using CropService.Models;
using CropService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace CropService.Controllers
{
    [ApiController]
    [Route("api/crops")]
    public class CropController : ControllerBase
    {
        private readonly ICropService _cropService;

        public CropController(ICropService cropService)
        {
            _cropService = cropService;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCrop(Guid farmerId, [FromBody] Crop crop)
        {

            var check = await _cropService.IsFarmer(farmerId);
            if(!check)
            {
                return BadRequest(new { message = "Only Farmers can add crops" });
            }
            var newCrop = await _cropService.AddCrop(farmerId, crop);

            if (newCrop == null)
            {
                return BadRequest(new { message = "Only Farmers can add crops" });
            }

            return CreatedAtAction(nameof(GetCropsByFarmer), new { farmerId = farmerId }, newCrop);
        }

        [HttpGet]
        public async Task<IActionResult> GetCrops()
        {
            var crops = await _cropService.GetCrops();
            return Ok(crops);
        }

        // ✅ Get Crops by Farmer
        [HttpGet("farmer/{farmerId}")]
        public async Task<IActionResult> GetCropsByFarmer(Guid farmerId)
        {
            var crops = await _cropService.GetCropsByFarmer(farmerId);
            return Ok(crops);
        }
    }
}
