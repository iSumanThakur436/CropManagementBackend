using CropService.Data;
using CropService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CropService.Services
{
    public class CropinService : ICropService
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly string _authServiceUrl = "http://localhost:5119";  // AuthService base URL

        public CropinService(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        // ✅ Check if the user is a Farmer
        public async Task<bool> IsFarmer(Guid userId)
        {
            var response = await _httpClient.GetAsync($"{_authServiceUrl}/api/users/{userId}");

            if (!response.IsSuccessStatusCode) return false;

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return user.Role?.Name == "Farmer";
        }


        // ✅ Add a Crop (Only Farmers)
        public async Task<Crop> AddCrop(Guid farmerId, Crop crop)
        {
            if (!await IsFarmer(farmerId)) return null;  // ❌ Only Farmers can list crops

            crop.Id = Guid.NewGuid();
            crop.FarmerId = farmerId;
            _context.Crops.Add(crop);
            await _context.SaveChangesAsync();

            return crop;
        }

        // ✅ Get all Crops
        public async Task<List<Crop>> GetCrops()
        {
            return await _context.Crops.ToListAsync();
        }

        // ✅ Get Crops by Farmer
        public async Task<List<Crop>> GetCropsByFarmer(Guid farmerId)
        {
            return await _context.Crops.Where(c => c.FarmerId == farmerId).ToListAsync();
        }
    }
}
