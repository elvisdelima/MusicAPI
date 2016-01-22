using System;

namespace MusicAPI.Models
{
    public class Music
    {
        public Guid Id { get; set; }        
        public string Name { get; set; }        
		public string AlbumName { get; set;}
		public string BandName { get; set; }
    }
}