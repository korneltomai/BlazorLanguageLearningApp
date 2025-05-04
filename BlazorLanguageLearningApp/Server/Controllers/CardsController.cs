﻿using BlazorLanguageLearningApp.Server.Data;
using BlazorLanguageLearningApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorLanguageLearningApp.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : Controller
    {
        private readonly DataContext _context;

        public CardsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{cardId}")]
        public async Task<ActionResult<Card>> GetCardById(int cardId)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            if (card is null)
                return NotFound("This card does not exist!");
            return Ok(card);
        }

        [HttpPost("{setId}")]
        public async Task<ActionResult> CreateCard(int setId, Card card)
        {
            _context.Cards.Add(card);

            var set = await _context.Sets.FindAsync(setId);
            if (set is null)
                return NotFound("This folder does not exist!");
            set.Cards.Add(card);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCard(Card card)
        {
            var dbCard = await _context.Cards.FindAsync(card.Id);
            if (dbCard is null)
                return NotFound("This card does not exist!");

            _context.Entry(dbCard).CurrentValues.SetValues(card);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{cardId}")]
        public async Task<ActionResult> DeleteCard(int cardId)
        {
            var dbCard = await _context.Cards.FindAsync(cardId);
            if (dbCard is null)
                return NotFound("This card does not exist!");

            _context.Cards.Remove(dbCard);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
