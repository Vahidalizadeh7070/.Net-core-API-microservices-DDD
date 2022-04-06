using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaformServices.AsyncDataService;
using PlaformServices.SyncDataServices.http;
using PlatformService.Data;
using PlatformService.DTO;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController:ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public PlatformsController(IPlatformRepo repository,IMapper mapper,ICommandDataClient commandDataClient, IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient=commandDataClient;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms");
            var platformItem=_repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItem));
        }  

        [HttpGet("{id}",Name ="GetPlatformById")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            var platformItem=_repository.GetPlatformById(id);
            if (platformItem!=null)
            {
                return Ok(_mapper.Map<PlatformReadDTO>(platformItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDTO>> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel=_mapper.Map<Platforms>(platformCreateDTO);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDTO=_mapper.Map<PlatformReadDTO>(platformModel);

            // Synchronously 
            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDTO);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            // Asynchronously
            try
            {
                var PlatformPublishedDto=_mapper.Map<PlatformPublishedDto>(platformReadDTO);
                PlatformPublishedDto.Event="Platform_Publisher";
                _messageBusClient.PublishNewPlatform(PlatformPublishedDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }
            return CreatedAtRoute(nameof(GetPlatformById),new {Id=platformReadDTO.Id},platformReadDTO);
        }
    }
}