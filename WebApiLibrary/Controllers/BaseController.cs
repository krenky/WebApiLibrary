﻿using Microsoft.AspNetCore.Mvc;
using WebApiLibrary.Interfaces;

namespace WebApiLibrary.Controllers
{
    /// <summary>
    /// Базовый CRUD контроллер
    /// </summary>
    /// <typeparam name="T">Модель для Entity Framework</typeparam>
    public class BaseController<T>:ControllerBase
    {
        public readonly ICRUD<T> _service;

        public BaseController(ICRUD<T> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/<GameServersController>
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return _service.GetList();
        }

        // GET api/<GameServersController>/5
        [HttpGet("{id}")]
        public T Get(string id)
        {
            return _service.Get(id);
        }

        // POST api/<GameServersController>
        [HttpPost]
        public void Post([FromBody] T value)
        {
            _service.Add(value);
        }

        // PUT api/<GameServersController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] T value)
        {
            _service.Change(id, value);
        }

        // DELETE api/<GameServersController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _service.Delete(id);
        }
    }
}
