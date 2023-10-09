using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P016_WeApi.Context;
using P016_WeApi.Dtos;
using P016_WeApi.Models;
using System.Text.Json.Serialization;

namespace P016_WeApi.Controllers
{
	[ApiController]
	[Route("Api/[controller]")]
	public class FilmController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public FilmController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		//Get, Post, Put, Delete (CRUD, DML)
		[HttpGet]
		public async Task<ActionResult<List<Film>>> Get()
		{
			//Tüm Film datasını geri dönen metod
			var data = await _dataContext.Film.Where(t => !t.IsDeleted).ToListAsync();
			return Ok(data);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Film>> GetById(int id)
		{
			//var data = await _dataContext.Film.FindAsync(id);
			var data = await _dataContext.Film.Where(t => !t.IsDeleted && t.Id == id).ToListAsync();
			if (data is null)
				return NotFound();
			else
				return Ok(data);
		}

		[HttpPost]
		public async Task<IActionResult> FilmAdd(Film model)
		{
			if (model == null)
				return BadRequest(model);

			if (!ModelState.IsValid)
				return BadRequest(model);

			await _dataContext.AddAsync(model);
			await _dataContext.SaveChangesAsync();

			return Ok("Başarılı.");
		}

		//Güncelleme işlemi
		[HttpPut]
		public async Task<IActionResult> FilmUpdate(FilmDto model)
		{
			if (model == null)
				return NotFound(model);

			if (!ModelState.IsValid)
				return BadRequest(model);

			var data = await _dataContext.Film.FindAsync(model.Id);
			if (data is null)
				return NotFound();

			if (!string.IsNullOrWhiteSpace(model.FilmAdi))
				data.FilmAdi = model.FilmAdi;

			if (!string.IsNullOrWhiteSpace(model.Basrol))
				data.Basrol = model.Basrol;

			if (model.CikisYili != 0)
				data.CikisYili = (int)model.CikisYili;

			if (!string.IsNullOrWhiteSpace(model.Yonetmen))
				data.Yonetmen = model.Yonetmen;

			_dataContext.Update(data);
			await _dataContext.SaveChangesAsync();

			return Ok(data);
		}

		[HttpDelete]
		public async Task<ActionResult<List<Film>>> FilmDelete(FilmDeleteViewModel model)
		{
			var data = await _dataContext.Film.FindAsync(model.Id);
			if (data is null)
				return NotFound();

			if (model.softDelete)
			{
				data.IsDeleted = true;

				_dataContext.Update(data);
				await _dataContext.SaveChangesAsync();
			}
			else
			{
				_dataContext.Remove(data);
				await _dataContext.SaveChangesAsync();
			}

			return (await Get());
		}
	}
}
