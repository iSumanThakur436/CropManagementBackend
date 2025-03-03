using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CropService.Models;

namespace CropService.Services
{
    public interface ICropService
    {
        Task<bool> IsFarmer(Guid userId);
        Task<Crop> AddCrop(Guid farmerId, Crop crop);
        Task<List<Crop>> GetCrops();
        Task<List<Crop>> GetCropsByFarmer(Guid farmerId);
    }
}
