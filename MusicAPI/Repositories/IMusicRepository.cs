using MusicAPI.Models;
using System.Collections.Generic;
using System;

namespace MusicAPI.Repository
{
    public interface IMusicRepository
    {
        void Add(Music item);
        IEnumerable<Music> GetAll();
        Music Find(Guid Id);
        void Remove(Guid Id);
        void Update(Music item);
    }
}