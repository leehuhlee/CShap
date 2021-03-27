using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Controllers
{
    // REST (Representational State Transfer)
    // Not the public spec
    // Reusing features from the original HTTP communication to create a data transmission rule

    // CRUD
    // Create
    // POST / api/ranking
    // -- Create item(real data in Body)

    // Read
    // GET/ api/ ranking
    // get all items
    // GET/ api/ ranking/1
    // get item which is id=1

    // Update
    // PUT /api/ ranking(not used in web because of PUT authority problem)
    // request update item(real data in Body)

    // Delete
    // DELETE /api/ranking/1(not used in web because of DELETE authority problem)
    // delete item which is id=1

    // ApiController feature
    // can return C# object
    // if return null, then 204 Response(No Content) in cli
    // string -> text/plain
    // rest(int, bool) -> application/json

    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create
        [HttpPost]
        public GameResult AddGameResult([FromBody]GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return gameResult;
        }

        // Read
        [HttpGet]
        public List<GameResult> GetGameResults()
        {
            List<GameResult> results = _context.GameResults
                 .OrderByDescending(item => item.Score)
                 .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public GameResult GetGameResults(int id)
        {
            GameResult result = _context.GameResults
                 .Where(item => item.Id == id)
                 .FirstOrDefault();

            return result;
        }

        // Update
        [HttpPut]
        public bool UpdateGameResult([FromBody] GameResult gameResult)
        {
            var findResult = _context.GameResults
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findResult == null)
                return false;

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            _context.SaveChanges();

            return true;
        }

        // Delete
        [HttpDelete("{id}")]
        public bool DeleteGameResult(int id)
        {
            var findResult = _context.GameResults
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (findResult == null)
                return false;

            _context.GameResults.Remove(findResult);
            _context.SaveChanges();

            return true;
        }
    }
}
