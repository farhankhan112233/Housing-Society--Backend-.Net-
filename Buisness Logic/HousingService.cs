using System.Runtime.Versioning;
using Housing_Society.Data_Access.UnitOfWork;
using Housing_Society.DTOs;
using Housing_Society.Models;

namespace Housing_Society.Buisness_Logic
{
    public class HousingService : IHousingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HousingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HouseResponseDto> SaveSociety(HouseRequestDto dto)
        {
            var stateEntity = new State
            {
                StateName = dto.state
            };
            await _unitOfWork.stateRepository.AddState(stateEntity);
            var cityEntity = new City
            {
                CityName = dto.city,
                State = stateEntity
            };
            await _unitOfWork.cityRepository.AddCity(cityEntity);
            var houseEntity = new House
            {
                Name = dto.name,
                AvailableUnits = dto.availableUnits,
                Wifi = dto.wifi,
                Laundry = dto.laundry,
                Description = dto.description,
                City = cityEntity
            };
            var house = await _unitOfWork.houseRepository.AddHouse(houseEntity);
            if (house == null)
            {
                return null;
            }
            if (dto.photo != null && dto.photo.Count > 0)
            {
                var folderName = Path.Combine("Resources", "AllFiles");
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                var photoEntities = new List<Photo>();
                foreach (var file in dto.photo)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var tempFilePath = Path.Combine(folderPath, fileName);

                        using (var stream = new FileStream(tempFilePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        photoEntities.Add(new Photo
                        {
                            Housing = houseEntity,
                            PhotoUrl = "/uploads/" + fileName
                        });
                    }

                }
                await _unitOfWork.photoRepository.AddPhotos(photoEntities);

            }
            else
            {
                return null;
            }
            await _unitOfWork.Complete();
            var response = new HouseResponseDto
            {
                name = houseEntity.Name,
                id = houseEntity.Id
            };
            return response;


        }
        public async Task<IEnumerable<HouseDto>> GetAllSocieties()
        {
            var Societies = await _unitOfWork.houseRepository.GetAll();

            var dto = Societies.Select(x => new HouseDto
            {
                id = x.Id,
                name = x.Name,
                city = x.City?.CityName ?? string.Empty,
                state = x.City?.State?.StateName ?? string.Empty,
                availableUnits = x.AvailableUnits,
                wifi = x.Wifi,
                laundry = x.Laundry,
                description = x.Description,
                photo = x.Photos.Select(p =>
                {
                    var filePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "Resources",
                        "AllFiles",
                        Path.GetFileName(p.PhotoUrl)
                    );

                    if (File.Exists(filePath))
                    {
                        var fileBytes = File.ReadAllBytes(filePath);
                        var extension = Path.GetExtension(filePath).ToLower();

                        string mimeType = extension switch
                        {
                            ".jpg" or ".jpeg" => "image/jpeg",
                            ".png" => "image/png",
                            ".gif" => "image/gif",
                            _ => "application/octet-stream"
                        };

                        return $"data:{mimeType};base64,{Convert.ToBase64String(fileBytes)}";
                    }

                    return null!;
                }).Where(p => p != null).ToList()
            }).ToList();
            return dto;
        }
        public async Task<HouseDto> GetHouseById(int id)
        {
            var HouseById = await _unitOfWork.houseRepository.GetById(id);
            if (HouseById == null)
            {
                return null;
            }

            var dto = new HouseDto
            {
                id = HouseById.Id,
                name = HouseById.Name,
                city = HouseById.City?.CityName ?? string.Empty,
                state = HouseById.City?.State?.StateName ?? string.Empty,
                availableUnits = HouseById.AvailableUnits,
                wifi = HouseById.Wifi,
                laundry = HouseById.Laundry,
                description = HouseById.Description,
                photo = (HouseById.Photos)
                    .Select(p =>
                    {
                        var filePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "Resources",
                            "AllFiles",
                            Path.GetFileName(p.PhotoUrl)
                        );

                        if (File.Exists(filePath))
                        {
                            var fileBytes = File.ReadAllBytes(filePath);
                            var extension = Path.GetExtension(filePath).ToLower();

                            string mimeType = extension switch
                            {
                                ".jpg" or ".jpeg" => "image/jpeg",
                                ".png" => "image/png",
                                ".gif" => "image/gif",
                                _ => "application/octet-stream"
                            };

                            return $"data:{mimeType};base64,{Convert.ToBase64String(fileBytes)}";
                        }

                        return null;
                    })
                    .Where(p => p != null)
                    .ToList()!
            };

            return dto;
        }

    }

}






