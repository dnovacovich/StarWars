using Application.Exceptions;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StarWars.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        #region Field's
        private readonly CharacterManager _characterManager;
        #endregion

        #region Constructor
        public CharacterController(CharacterManager characterManager)
        {
            _characterManager = characterManager;
        }
        #endregion

        #region Public Method's / EndPoint's
        /// <summary>
        /// Retorna los datos de un personaje a partir de su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Domain.Entities.Character> Get(int id)
        {
            try
            {
                Domain.Entities.Character result = _characterManager.SearchCharacter(id);

                return Ok(result);
            }
            catch (CharacterNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Agrega una puntuación de un personaje
        /// </summary>
        /// <param name="score"></param>
        /// <param name="charId"></param>
        [HttpPost("{charId}/rating")]
        public ActionResult RateCharacter([FromBody] int score, int charId)
        {
            if (!(score >= 1 && score <= 5))
                return BadRequest("La puntuación debe ser un número del 1 al 5");

            try
            {
                _characterManager.RateCharacter(charId, score);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            

        } 
        #endregion
    }
}
