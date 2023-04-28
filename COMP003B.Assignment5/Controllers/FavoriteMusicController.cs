using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace COMP003B.Assignment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteMusicController : Controller
    {
        private List<Music> _fMusic = new List<Music>();
        public FavoriteMusicController() 
        {
            _fMusic.Add(new Music { Id = 1, Artist = "Frank Ocean", Album = "Single", Song = "Swim Good" });
            _fMusic.Add(new Music { Id = 2, Artist = "Don Toliver", Album = "Love Sick", Song = "Do It Right" });
            _fMusic.Add(new Music { Id = 3, Artist = "Kanye West", Album = "Donda", Song = "Praise God"});
            _fMusic.Add(new Music { Id = 4, Artist = "Future", Album = "Monster", Song = "Codeine Crazy" });
            _fMusic.Add(new Music { Id = 5, Artist = "Rauw Alejandro", Album = "SATURNO", Song = "LEJOS DEL CIELO" });

        }
        [HttpGet]
        public ActionResult<IEnumerable<Music>> GetallMusic()
        {
            return _fMusic;
        }
        //Read
        [HttpGet("{id}")]
        public ActionResult<Music> GetMusicById(int id)
        {
            var music = _fMusic.Find(s => s.Id==id);
            if (music == null)
            {
                return NotFound();
            }
            return music;
        }
        //Read
        [HttpPost]
        public ActionResult<Music> CreateMusic(Music music)
        {
            music.Id = _fMusic.Max(s => s.Id) + 1;
            _fMusic.Add(music);
            return CreatedAtAction(nameof(GetMusicById), new { id = music.Id, music });
        }
        [HttpPut]
        public IActionResult UpdateMusic(int id, Music updatedMusic)
        {
            var music = _fMusic.Find(s => s.Id == id);

            if (music== null)
            {
                return BadRequest();
            }
            music.Artist= updatedMusic.Artist;
            music.Album= updatedMusic.Album;
            music.Song= updatedMusic.Song;

            return NoContent();

        }
        //Delete
        [HttpDelete]
        public IActionResult DeleteMusic(int id)
        {
            var music= _fMusic.Find(s=>s.Id==id);    
            
            if(music == null)
            {
                return NotFound();
            }
            _fMusic.Remove(music);
            return NoContent();
        }
    }
}
