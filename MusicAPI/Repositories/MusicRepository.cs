using System;
using System.Collections.Generic;
using System.Linq;
using MusicAPI.Models;

namespace MusicAPI.Repository
{
    public class MusicRepository : IMusicRepository
    {
        static List<Music> MusicList = new List<Music>();

        public void Add(Music item)
        {
            MusicList.Add(item);
        }

        public Music Find(Guid Id)
        {
            return MusicList.Find(m => m.Id.Equals(Id));
        }

        public IEnumerable<Music> GetAll()
        {
            return MusicList;
        }

        public void Remove(Guid Id)
        {
            var itemToRemove = MusicList.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                MusicList.Remove(itemToRemove);            
        }

        public void Update(Music item)
        {
            var itemToUpdate = MusicList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.AlbumName = item.AlbumName;
                itemToUpdate.BandName = item.BandName;
            }
        }
    }
}