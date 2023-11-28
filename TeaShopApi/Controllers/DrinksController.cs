using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DtoLayer.DrinkDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public IActionResult DrinkList()
        {
            var values = _drinkService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDrink(CreateDrinkDto createdDrinkDto)
        {

            Drink drink = new Drink()
            {
                DrinkImageUrl = createdDrinkDto.DrinkImageUrl,
                DrinkName = createdDrinkDto.DrinkName,
                DrinkPrice = createdDrinkDto.DrinkPrice,
            };
            _drinkService.TInsert(drink);
            return Ok(drink);
        }
        [HttpDelete]
        public  IActionResult DeleteDrink(int id)
        {
            var value = _drinkService.TGetByID(id);
            _drinkService.TDelete(value);
            return Ok("İçerik silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDrink(int id)
        {
            var value=_drinkService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateDrink(UpdateDrinkDto updateDrinkDto)
        {
            Drink drink = new Drink()
            {
                DrinkID = updateDrinkDto.DrinkID,
                DrinkImageUrl = updateDrinkDto.DrinkImageUrl,
                DrinkName = updateDrinkDto.DrinkName,
                DrinkPrice = updateDrinkDto.DrinkPrice,
            };
            _drinkService.TUpdate(drink);
            return Ok("Başarılı bir şekilde güncellendi");
        }
    }
}
